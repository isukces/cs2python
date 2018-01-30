using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using Cs2Py.Compilation;
using Cs2Py.CSharp;
using Cs2Py.Source;
using Cs2Py.Translator;
using Lang.Python;


namespace Cs2Py.NodeTranslators
{
    public class DotnetMethodCallTranslator : IPyNodeTranslator<CsharpMethodCallExpression>
    {
        // Private Methods 

        private static IPyValue TranspileDelegateToPyton(IExternalTranslationContext ctx, CsharpMethodCallExpression src)
        {
            if (src.TargetObject == null)
                throw new NotSupportedException();
            var args = new List<IPyValue> { ctx.TranslateValue(src.TargetObject) };
            foreach (var i in src.Arguments)
                args.Add(ctx.TranslateValue(i.MyValue));

            var a = new PyMethodCallExpression("call_user_func", args.ToArray());
            return a;
        }


        // Public Methods 
 

        public int GetPriority()
        {
            return 999;
        }

        public IPyValue TranslateToPython(IExternalTranslationContext ctx, CsharpMethodCallExpression src)
        {
            if (src.IsDelegate)
                return TranspileDelegateToPyton(ctx, src);

           
            var principles = ctx.GetTranslationInfo();
            src = SubstituteByReplacerMethod(ctx, src);
            {
                var value = Try_DirectCallAttribute(ctx, src);
                if (value != null)
                    return value;
                value = Try_UseExpressionAttribute(ctx, src);
                if (value != null)
                    return value;
            }

            ctx.GetTranslationInfo().CheckAccesibility(src);
            var declaringType = src.MethodInfo.DeclaringType;
            if (declaringType.IsGenericType)
                declaringType = declaringType.GetGenericTypeDefinition();
            var cti = principles.FindClassTranslationInfo(declaringType);
            if (cti == null)
                throw new NotSupportedException();
            var mti = principles.GetOrMakeTranslationInfo(src.MethodInfo);
            {
                var pyMethod = new PyMethodCallExpression(mti.ScriptName);
                if (src.MethodInfo.IsStatic)
                {
                    var a = principles.GetPyType(src.MethodInfo.DeclaringType, true, principles.CurrentType);
                    pyMethod.SetClassName(a, mti);
                }
                pyMethod.TargetObject = ctx.TranslateValue(src.TargetObject);
                CopyArguments(ctx, src.Arguments, pyMethod, null);

                if (cti.DontIncludeModuleForClassMembers)
                    pyMethod.DontIncludeClass = true;
                return pyMethod;
            }

            throw new Exception(string.Format("bright cow, {0}", src.MethodInfo.DeclaringType.FullName));
        }

        private static IPyValue Try_UseExpressionAttribute(IExternalTranslationContext ctx, CsharpMethodCallExpression src)
        {
            var ats = src.MethodInfo.GetCustomAttribute<UseBinaryExpressionAttribute>(true);
            if (ats == null)
                return null;
            IPyValue l, r;
            var re = new Regex("^\\s*\\$(\\d+)\\s*$");
            var m = re.Match(ats.Left);
            if (m.Success)
                l = ctx.TranslateValue(src.Arguments[int.Parse(m.Groups[1].Value)].MyValue);
            else
                l = PyValueTranslator.GetValueForExpression(null, ats.Left);

            m = re.Match(ats.Right);
            if (m.Success)
                r = ctx.TranslateValue(src.Arguments[int.Parse(m.Groups[1].Value)].MyValue);
            else
                r = PyValueTranslator.GetValueForExpression(null, ats.Right);
            var method = new PyBinaryOperatorExpression(ats.Operator, l, r);
            return method;
        }
        // Private Methods 

        private static void CopyArguments(IExternalTranslationContext ctx, IEnumerable<FunctionArgument> srcParameters, PyMethodCallExpression dstMethod, List<int> skipRefIndexList)
        {
            var parameterIdx = 0;
            foreach (var functionArgument in srcParameters)
            {
                var a = ctx.TranslateValue(functionArgument);
                if (!(a is PyMethodInvokeValue b))
                    throw new NotImplementedException();
                if (b.Expression is PyParenthesizedExpression)
                    Debug.Write("");
                if (skipRefIndexList != null && skipRefIndexList.Contains(parameterIdx))
                    b.ByRef = false;
                dstMethod.Arguments.Add(b);
                parameterIdx++;
            }
        }

        /// <summary>
        /// Jeśli dla klasy deklarującej metodę jest znana klasa 'replacera' to podmieniam wywołanie metody na wywołanie metody z klasy replacera jeden do jeden
        /// </summary>
        /// <param name="src"></param>
        /// <returns></returns>
        private static CsharpMethodCallExpression SubstituteByReplacerMethod(IExternalTranslationContext ctx, CsharpMethodCallExpression src)
        {
            var classReplacer = ctx.FindOneClassReplacer(src.MethodInfo.DeclaringType);
            if (classReplacer == null)
                return src;
            var otherClass = classReplacer.ReplaceBy;
            var flags = src.MethodInfo.IsStatic ? BindingFlags.Static : BindingFlags.Instance;
            var search = src.MethodInfo.ToString();
            var found = otherClass.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | flags).FirstOrDefault(i => i.ToString() == search);
            if (found == null)

                throw new Exception(string.Format("Klasa {0} nie zawiera metody lustrzanej {1}\r\nDodaj\r\n{2}", otherClass, search, src.MethodInfo.GetMethodHeader()));
            src = new CsharpMethodCallExpression(found, src.TargetObject, src.Arguments, src.GenericTypes, false);
            return src;
        }

        /// <summary>
        /// Jeśli metoda .NET ma zdefiniowany argument <see cref="DirectCallAttribute">DirectCall</see> to tworzy odpowiednie wywołanie funkcji Py
        /// </summary>
        /// <param name="ctx"></param>
        /// <param name="src"></param>
        /// <returns></returns>
        private static IPyValue Try_DirectCallAttribute(IExternalTranslationContext ctx, CsharpMethodCallExpression src)
        {
            var directCallAttribute = src.MethodInfo.GetDirectCallAttribute();
            if (directCallAttribute == null)
                return null;
            return CreateExpressionFromDirectCallAttribute(ctx, directCallAttribute, src.TargetObject, src.Arguments, src.MethodInfo);

        }


        /// <summary>
        /// Creates expression based on DirectCallAttribute
        /// </summary>
        /// <param name="ctx"></param>
        /// <param name="directCallAttribute"></param>
        /// <param name="targetObject"></param>
        /// <param name="arguments"></param>
        /// <returns></returns>
        public static IPyValue CreateExpressionFromDirectCallAttribute(IExternalTranslationContext ctx, DirectCallAttribute directCallAttribute, IValue targetObject, FunctionArgument[] arguments, MethodBase methodInfo)
        {

            if (directCallAttribute.CallType == MethodCallStyles.Static)
                throw new NotSupportedException();
            if (directCallAttribute.MemberToCall != ClassMembers.Method)
                throw new NotSupportedException();

            if (string.IsNullOrEmpty(directCallAttribute.Name))
            {
                var ma = directCallAttribute.MapArray;
                if (ma.Length != 1)
                    throw new NotSupportedException("gray horse 1");
                if (ma[0] == DirectCallAttribute.This)
                {
                    if (targetObject == null)
                        throw new NotSupportedException("gray horse 2");
                    return ctx.TranslateValue(targetObject);
                }
                //  return PyMethod.Arguments[ma[0]].Expression
                return ctx.TranslateValue(arguments[ma[0]].MyValue);
            }
            var name = directCallAttribute.Name;


            var PyMethod = new PyMethodCallExpression(name);
            if (directCallAttribute.CallType == MethodCallStyles.Instance)
            {
                if (targetObject == null)
                    throw new NotSupportedException("gray horse 3");
                PyMethod.TargetObject = ctx.TranslateValue(targetObject);
            }

            {
                List<int> skipRefIndexList = null;
                if (methodInfo != null)
                {
                    var skipRefOrOutArray = directCallAttribute.SkipRefOrOutArray;
                    if (skipRefOrOutArray.Any())
                    {
                        var parameters = methodInfo.GetParameters();
                        for (var index = 0; index < parameters.Length; index++)
                        {
                            if (!skipRefOrOutArray.Contains(parameters[index].Name)) continue;
                            if (skipRefIndexList == null)
                                skipRefIndexList = new List<int>();
                            skipRefIndexList.Add(index);
                        }
                    }
                }
                CopyArguments(ctx, arguments, PyMethod, skipRefIndexList);
            }

            if (directCallAttribute.HasMapping)
            {
                var PyArguments = PyMethod.Arguments.ToArray();
                PyMethod.Arguments.Clear();
                foreach (var argNr in directCallAttribute.MapArray)
                {
                    if (argNr == DirectCallAttribute.This)
                    {
                        if (targetObject == null)
                            throw new NotSupportedException();
                        var v = ctx.TranslateValue(targetObject);
                        PyMethod.Arguments.Add(new PyMethodInvokeValue(v));
                    }
                    else
                    {
                        if (argNr < PyArguments.Length)
                            PyMethod.Arguments.Add(PyArguments[argNr]);
                    }
                }

            }

            if (directCallAttribute.OutNr >= 0)
            {
                var nr = directCallAttribute.OutNr;
                var movedExpression = PyMethod.Arguments[nr].Expression;
                PyMethod.Arguments.RemoveAt(nr);
                var a = new PyAssignExpression(movedExpression, PyMethod);
                return a;
            }

            return PyMethod;
        }
    }
}