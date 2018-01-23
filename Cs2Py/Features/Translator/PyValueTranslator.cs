using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using Cs2Py.CodeVisitors;
using Cs2Py.Compilation;
using Cs2Py.CSharp;
using Cs2Py.Source;
using Lang.Python;

namespace Cs2Py.Translator
{
    internal class PyValueTranslator : CSharpBaseVisitor<IPyValue>
    {
        public PyValueTranslator(TranslationState state)
        {
            _state = state;
        }

        // Public Methods 

        public static IPyValue GetValueForExpression(IPyValue pyTargetObject, string valueAsString)
        {
            valueAsString = (valueAsString ?? "").Trim();
            if (valueAsString.ToLower() == "this")
                return pyTargetObject;
            if (valueAsString == "false")
                return new PyConstValue(false);
            if (valueAsString == "true")
                return new PyConstValue(true);
            if (int.TryParse(valueAsString, out var i))
                return new PyConstValue(i);

            if (double.TryParse(valueAsString, NumberStyles.Float, CultureInfo.InvariantCulture, out var d))
                return new PyConstValue(d);
            {
                if (PyValues.TryGetPyStringValue(valueAsString, out var x))
                    return new PyConstValue(x);
            }
            throw new Exception(string.Format("bald boa, Unable to convert {0} into Py value", valueAsString));
        }
        // Private Methods 

        private static IPyValue SimplifyPyExpression(IPyValue v)
        {
            var s = new ExpressionSimplifier(new OptimizeOptions());
            if (v is PySourceBase)
                return s.Visit(v as PySourceBase);
            return v;
        }
        // Private Methods 

        private static void WriteWarning(string x)
        {
            var tmp                 = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Warning");
            Console.ForegroundColor = tmp;
            Console.WriteLine(" " + x);
        }

        // Public Methods 

        public IPyValue ConvertValueToPredefined(object o)
        {
            if (!(o is double)) return new PyConstValue(o);
            if ((double)o == Math.PI)
                return new PyMethodCallExpression("pi");
            return new PyConstValue(o);
        }

        public void CopyArguments(IEnumerable<FunctionArgument> srcParameters, PyMethodCallExpression dstMethod)
        {
            foreach (var functionArgument in srcParameters)
                dstMethod.Arguments.Add(VisitFunctionArgument(functionArgument) as PyMethodInvokeValue);
        }

        public PyMethodInvokeValue TransFunctionArgument(FunctionArgument a)
        {
            var r = new PyMethodInvokeValue(TransValue(a.MyValue));
            return r;
        }

        public IPyValue TransValue(IValue value)
        {
            if (value == null)
                return null;
            if (value is CSharpBase)
            {
                var tmp = Visit(value as CSharpBase);
                return SimplifyPyExpression(tmp);
            }

            throw new NotSupportedException();
        }
        // Protected Methods 

        protected override IPyValue VisitArgumentExpression(ArgumentExpression src)
        {
            return PyVariableExpression.MakeLocal(src.Name, true);
        }

        protected override IPyValue VisitArrayCreateExpression(ArrayCreateExpression src)
        {
            var a = new PyArrayCreateExpression();
            if (src.Initializers != null && src.Initializers.Any())
                a.Initializers = src.Initializers.Select(TransValue).ToArray();
            return SimplifyPyExpression(a);
        }

        protected override IPyValue VisitAssignExpression(CsharpAssignExpression src)
        {
            var l  = TransValue(src.Left);
            var r  = TransValue(src.Right);
            var op = src.OptionalOperator;
            if (op == "+")
            {
                var vt = (src as IValue).ValueType;
                if (vt == typeof(string))
                    op = ".";
            }

            var a = new PyAssignExpression(l, r, op);
            return SimplifyPyExpression(a);
        }

        protected override IPyValue VisitBinaryOperatorExpression(BinaryOperatorExpression src)
        {
            var leftType  = src.Left.ValueType;
            var rightType = src.Right.ValueType;
            if (src.OperatorMethod != null)
            {
                if (!src.OperatorMethod.IsStatic)
                    throw new NotSupportedException("Operator method is not static??!!");
                var a = new CsharpMethodCallExpression(
                    src.OperatorMethod, null,
                    new[] {new FunctionArgument("", src.Left, null), new FunctionArgument("", src.Right, null)},
                    new Type[0], false);
                var trans = TransValue(a);
                return trans;
            }

            var leftValue = TransValue(src.Left);
            if (src.Operator == "as")
                return leftValue;

            var rightValue = TransValue(src.Right);

            var ss1     = leftValue as PyConstValue;
            var ss2     = rightValue as PyConstValue;
            var isConst = ss1 != null && ss2 != null;

            //            if (isConst)
            //                return new PyBinaryOperatorExpression(src.Operator, leftValue, rightValue);

            if (leftType == typeof(string) || rightType == typeof(string))
            {
                var pyOperator = src.Operator == "+" ? "." : src.Operator;
                return src.Operator == "+" && isConst
                    ? (IPyValue)new PyConstValue(ss1.Value as string + ss2.Value)
                    : new PyBinaryOperatorExpression(pyOperator, leftValue, rightValue);
            }

            if (isConst)
            {
                if (leftType == typeof(int) && rightType == typeof(int))
                {
                    var s1 = (int)ss1.Value;
                    var s2 = (int)ss2.Value;
                    switch (src.Operator)
                    {
                        case "+":
                            return new PyConstValue(s1 + s2);
                        case "-":
                            return new PyConstValue(s1 - s2);
                        case "*":
                            return new PyConstValue(s1 * s2);
                        case "/":
                            return new PyConstValue(s1 / s2);
                    }
                }

                if (leftType.IsEnum && rightType.IsEnum && src.Operator == "|")
                {
                    var s1 = (int)ss1.Value;
                    var s2 = (int)ss2.Value;
                    return new PyConstValue(Enum.ToObject(leftType, s1 | s2));
                }
            }

            return new PyBinaryOperatorExpression(src.Operator, leftValue, rightValue);
        }

        protected override IPyValue VisitCallConstructor(CallConstructor src)
        {
            var tmp = _state.Principles.NodeTranslators.Translate(_state, src);
            if (tmp != null)
                return SimplifyPyExpression(tmp);

            var r = new PyMethodCallExpression(PyMethodCallExpression.ConstructorMethodName);
            if (src.Info.ReflectedType != src.Info.DeclaringType)
                throw new NotSupportedException();

            // we can use "state.Principles.CurrentType" as third parameter if we prefer "new self()" or "new parent()" contructor calls
            r.SetClassName(
                _state.Principles.GetPyType(src.Info.ReflectedType, true, null),
                _state.Principles.GetOrMakeTranslationInfo(src.Info)
            ); // class name for constructor
            {
                // var a = src.Info.GetCustomAttribute();
            }

            var cti = _state.Principles.GetTi(src.Info.ReflectedType, true);
            if (cti.DontIncludeModuleForClassMembers)
                r.DontIncludeClass = true;
            if (cti.IsArray)
                if (src.Initializers != null && src.Initializers.Any())
                {
                    var ggg = src.Initializers.Select(TransValue).ToArray();
                    var h   = new PyArrayCreateExpression(ggg);
                    return SimplifyPyExpression(h);
                }
                else
                {
                    var h = new PyArrayCreateExpression();
                    return SimplifyPyExpression(h);
                }

            {
                // cti = state.Principles.GetTi(src.Info.ReflectedType);
                if (cti.IsReflected)
                {
                    var replacer = _state.FindOneClassReplacer(src.Info.ReflectedType);
                    if (replacer != null)
                    {
                        var translationMethods = replacer.ReplaceBy
                            .GetMethods(BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic)
                            .Where(m => m.IsDefined(typeof(TranslatorAttribute))).ToArray();
                        foreach (var m in translationMethods)
                        {
                            var translated = m.Invoke(null, new object[] {_state, src});
                            if (translated is IPyValue)
                                return translated as IPyValue;
                        }

                        throw new Exception(string.Format("Klasa {0} nie umie przetłumaczyć konstruktora {1}",
                            replacer.ReplaceBy.FullName, replacer.SourceType.FullName));
                    }
                }
            }
            foreach (var functionArgument in src.Arguments)
                r.Arguments.Add(TransFunctionArgument(functionArgument));
            return r;
        }

        protected override IPyValue VisitCastExpression(CastExpression src)
        {
            var a = TransValue(src.Expression);
            return SimplifyPyExpression(a);
        }

        protected override IPyValue VisitClassFieldAccessExpression(ClassFieldAccessExpression src)
        {
            var tmp = _state.Principles.NodeTranslators.Translate(_state, src);
            if (tmp != null)
                return SimplifyPyExpression(tmp);

            var isStatic            = src.IsStatic;
            var member              = src.Member;
            var memberName          = member.Name;
            var memberDeclaringType = member.DeclaringType;

            {
                var tInfo = _state.Principles.GetOrMakeTranslationInfo(src.Member);
                if (tInfo.IsDefinedInNonincludableModule)
                {
                    var b = _state.Principles.GetTi(_state.Principles.CurrentType, true);
                    if (tInfo.IncludeModule != b.ModuleName)
                        throw new Exception(
                            string.Format(
                                "Unable to reference to field {1}.{0} from {2}.{3}. Containing module is page and cannot be included.",
                                memberName,
                                memberDeclaringType == null
                                    ? "?"
                                    : (memberDeclaringType.FullName ?? memberDeclaringType.Name),
                                _state.Principles.CurrentType.FullName,
                                _state.Principles.CurrentMethod
                            ));
                }

                var fieldDeclaringType = memberDeclaringType;
                if (fieldDeclaringType == null)
                    throw new Exception("fieldDeclaringType");
                _state.Principles.GetTi(fieldDeclaringType, false);
                {
                    if (fieldDeclaringType.IsEnum)
                    {
                        if (!isStatic)
                            throw new NotSupportedException();
                        var asDefinedConstAttribute = member.GetCustomAttribute<AsDefinedConstAttribute>();
                        if (asDefinedConstAttribute != null)
                        {
                            var definedExpression =
                                new PyDefinedConstExpression(asDefinedConstAttribute.DefinedConstName,
                                    tInfo.IncludeModule);
                            return SimplifyPyExpression(definedExpression);
                        }

                        var renderValueAttribute = member.GetCustomAttribute<RenderValueAttribute>();
                        if (renderValueAttribute != null)
                            if (PyValues.TryGetPyStringValue(renderValueAttribute.Name, out var strCandidate))
                            {
                                var valueExpression = new PyConstValue(strCandidate);
#if DEBUG
                                {
                                    var a1 = renderValueAttribute.Name.Trim();
                                    var a2 = valueExpression.ToString();
                                    if (a1 != a2)
                                        throw new InvalidOperationException();
                                }
#endif
                                return SimplifyPyExpression(valueExpression);
                            }
                            else
                            {
                                var valueExpression = new PyFreeExpression(renderValueAttribute.Name);
                                return SimplifyPyExpression(valueExpression);
                            }

                        {
                            // object v1 = ReadEnumValueAndProcessForPy(member);
                            var v1 = member.GetValue(null);
                            var g  = new PyConstValue(v1);
                            return SimplifyPyExpression(g);
                        }
                        //throw new NotSupportedException();
                    }
                }

                var principles = _state.Principles;
                switch (tInfo.Destination)
                {
                    case FieldTranslationDestionations.DefinedConst:
                        if (!member.IsStatic)
                            throw new NotSupportedException("Unable to convert instance field into Py defined const");
                        if (tInfo.IsScriptNamePyEncoded)
                            throw new Exception("Encoded Py values are not supported");
                        var definedExpression = new PyDefinedConstExpression(tInfo.ScriptName, tInfo.IncludeModule);
                        return SimplifyPyExpression(definedExpression);
                    case FieldTranslationDestionations.GlobalVariable:
                        if (!member.IsStatic)
                            throw new NotSupportedException(
                                "Unable to convert instance field into Py global variable");
                        if (tInfo.IsScriptNamePyEncoded)
                            throw new Exception("Encoded Py values are not supported");
                        var globalVariable = PyVariableExpression.MakeGlobal(tInfo.ScriptName);
                        return SimplifyPyExpression(globalVariable);
                    case FieldTranslationDestionations.JustValue:
                        if (!member.IsStatic)
                            throw new NotSupportedException("Unable to convert instance field into compile-time value");
                        var constValue   = member.GetValue(null);
                        var pyConstValue = new PyConstValue(constValue, tInfo.UsGlueForValue);
                        return SimplifyPyExpression(pyConstValue);
                    case FieldTranslationDestionations.NormalField:
                        if (tInfo.IsScriptNamePyEncoded)
                            throw new Exception("Encoded Py values are not supported");
                        var rr = new PyClassFieldAccessExpression
                        {
                            FieldName = tInfo.ScriptName,
                            IsConst   = tInfo.Destination == FieldTranslationDestionations.ClassConst
                        };
                        rr.SetClassName(
                            principles.GetPyType(memberDeclaringType, true, principles.CurrentType),
                            principles.GetOrMakeTranslationInfo(memberDeclaringType)
                        );
                        return SimplifyPyExpression(rr);
                    case FieldTranslationDestionations.ClassConst:
                        if (tInfo.IsScriptNamePyEncoded)
                            throw new Exception("Encoded Py values are not supported");
                        rr = new PyClassFieldAccessExpression
                        {
                            FieldName = tInfo.ScriptName,
                            IsConst   = true
                        };
                        rr.SetClassName(
                            principles.GetPyType(memberDeclaringType, true, principles.CurrentType),
                            principles.GetOrMakeTranslationInfo(memberDeclaringType));

                        return SimplifyPyExpression(rr);
                    default:
                        throw new NotSupportedException(string.Format(
                            "Unable to translate class field with destination option equal {0}", tInfo.Destination));
                }
            }
        }

        protected override IPyValue VisitClassPropertyAccessExpression(ClassPropertyAccessExpression src)
        {
            var tmp = _state.Principles.NodeTranslators.Translate(_state, src);
            if (tmp != null)
                return SimplifyPyExpression(tmp);
            throw new NotSupportedException();
        }

        protected override IPyValue VisitConditionalExpression(ConditionalExpression src)
        {
            var condition = TransValue(src.Condition);
            var whenTrue  = TransValue(src.WhenTrue);
            var whenFalse = TransValue(src.WhenFalse);
            var result    = new PyConditionalExpression(condition, whenTrue, whenFalse);
            return SimplifyPyExpression(result);
        }

        protected override IPyValue VisitConstValue(ConstValue src)
        {
            return new PyConstValue(src.MyValue);
        }

        protected override IPyValue VisitElementAccessExpression(ElementAccessExpression src)
        {
            var expression = TransValue(src.Expression);
            var arg        = src.Arguments.Select(i => TransValue(i)).ToArray();
            var a          = new PyElementAccessExpression(expression, arg);
            return SimplifyPyExpression(a);
        }

        protected override IPyValue VisitFunctionArgument(FunctionArgument src)
        {
            var expression = TransValue(src.MyValue);
            var a          = expression.GetPyCode(null);
            var result     = new PyMethodInvokeValue(expression);
            if (!string.IsNullOrEmpty(src.RefOrOutKeyword))
                result.ByRef = true;
            return SimplifyPyExpression(result);
        }

        protected override IPyValue VisitIncrementDecrementExpression(IncrementDecrementExpression src)
        {
            var o = TransValue(src.Operand);
            var r = new PyIncrementDecrementExpression(o, src.Increment, src.Pre);
            return SimplifyPyExpression(r);
        }

        protected override IPyValue VisitInstanceFieldAccessExpression(InstanceFieldAccessExpression src)
        {
            var fti = _state.Principles.GetOrMakeTranslationInfo(src.Member);
            var to  = TransValue(src.TargetObject);
            if (src.Member.DeclaringType.IsDefined(typeof(AsArrayAttribute)))
                switch (fti.Destination)
                {
                    case FieldTranslationDestionations.NormalField:
                        IPyValue index;
                        if (fti.IsScriptNamePyEncoded)
                            index = PyConstValue.FromPyValue(fti.ScriptName);
                        else
                            index = new PyConstValue(fti.ScriptName);
                        var tmp   = new PyArrayAccessExpression(to, index);
                        return SimplifyPyExpression(tmp);
                    case FieldTranslationDestionations.DefinedConst:
                        break; // obsłużę to dalej jak dla zwykłej klasy
                    default:
                        throw new NotSupportedException();
                }
            var a = new PyInstanceFieldAccessExpression(fti.ScriptName, to, fti.IncludeModule);
            return a;
        }

        protected override IPyValue VisitInstanceMemberAccessExpression(InstanceMemberAccessExpression src)
        {
            if (src.Member == null)
                throw new NotSupportedException();
            if (!(src.Member is MethodInfo)) throw new NotSupportedException();
            var mi = src.Member as MethodInfo;
            if (mi.IsStatic)
                throw new Exception("Metoda nie może być statyczna");
            var mmi = _state.Principles.GetOrMakeTranslationInfo(mi); // MethodTranslationInfo.FromMethodInfo(mi);
            var a   = new PyConstValue(TransValue(src.Expression));
            var b   = new PyConstValue(mmi.ScriptName);
            var o   = new PyArrayCreateExpression(a, b);
            return o;
        }

        protected override IPyValue VisitInstancePropertyAccessExpression(CsharpInstancePropertyAccessExpression src)
        {
            var pri       = PropertyTranslationInfo.FromPropertyInfo(src.Member);
            var ownerInfo = _state.Principles.GetOrMakeTranslationInfo(src.Member.DeclaringType);
            if (src.TargetObject == null)
                throw new NotImplementedException("statyczny");
            var translatedByExternalNodeTranslator = _state.Principles.NodeTranslators.Translate(_state, src);
            if (translatedByExternalNodeTranslator != null)
                return SimplifyPyExpression(translatedByExternalNodeTranslator);

            var pyTargetObject = TransValue(src.TargetObject);
            if (ownerInfo.IsArray)
            {
                var idx       = new PyConstValue(pri.FieldScriptName);
                var arrayExpr = new PyArrayAccessExpression(pyTargetObject, idx);
                return arrayExpr;
            }

            {
                var propertyInfo  = src.Member;
                var classReplacer = _state.FindOneClassReplacer(propertyInfo.DeclaringType);
                if (classReplacer != null)
                {
                    var newPropertyInfo = classReplacer.ReplaceBy.GetProperty(src.Member.Name,
                        BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
                    if (newPropertyInfo == null)
                        throw new Exception(string.Format("Klasa {0} nie zawiera własności {1}",
                            classReplacer.ReplaceBy, src.Member));
                    if (newPropertyInfo.GetIndexParameters().Length > 0)
                        throw new NotSupportedException("energetic gecko, Property with index");
                    propertyInfo = newPropertyInfo;
                }

                {
                    var ats = propertyInfo.GetCustomAttribute<DirectCallAttribute>(true);
                    if (ats != null)
                    {
                        if (string.IsNullOrEmpty(ats.Name))
                        {
                            var tmp = ats.MapArray;
                            if (tmp == null || tmp.Length <= 0)
                                return pyTargetObject;
                            if (tmp.Length > 1 || tmp[0] != DirectCallAttribute.This)
                                throw new NotSupportedException(string.Format(
                                    "Property {1}.{0} has invalid 'Map' parameter in DirectCallAttribute",
                                    propertyInfo.Name, propertyInfo.DeclaringType));
                            return pyTargetObject;
                        }

                        switch (ats.MemberToCall)
                        {
                            case ClassMembers.Method:
                                if (ats.Name == "this")
                                    return pyTargetObject;

                                var method = new PyMethodCallExpression(ats.Name);
                                switch (ats.CallType)
                                {
                                    case MethodCallStyles.Procedural:
                                        method.Arguments.Add(new PyMethodInvokeValue(pyTargetObject));
                                        return method;
                                    //    case MethodCallStyles.:
                                    //        method.Arguments.Add(new PyMethodInvokeValue(PyTargetObject));
                                    //        return method;
                                    //    default:
                                    //        throw new NotSupportedException();
                                }

                                throw new NotImplementedException();
                            case ClassMembers.Field:
                                switch (ats.CallType)
                                {
                                    case MethodCallStyles.Instance:
                                        if (ats.Name == "this")
                                            return pyTargetObject;
                                        var includeModule = ownerInfo.IncludeModule;
                                        var field         = new PyInstanceFieldAccessExpression(ats.Name,
                                            pyTargetObject,
                                            includeModule);
                                        return field;
                                    default:
                                        throw new NotSupportedException();
                                }
                            //var f = new PyMethodCallExpression(ats.Name);
                            //method.Arguments.Add(new PyMethodInvokeValue(PyTargetObject));
                            //return method;
                            default:
                                throw new NotSupportedException();
                        }
                    }
                }

                {
                    var ats = propertyInfo.GetCustomAttribute<UseBinaryExpressionAttribute>(true);
                    if (ats != null)
                    {
                        var left   = GetValueForExpression(pyTargetObject, ats.Left);
                        var right  = GetValueForExpression(pyTargetObject, ats.Right);
                        var method = new PyBinaryOperatorExpression(ats.Operator, left, right);
                        return method;
                    }
                }
                {
                    pri    = PropertyTranslationInfo.FromPropertyInfo(src.Member);
                    var to = TransValue(src.TargetObject);
                    var a  = new PyPropertyAccessExpression(pri, to);
                    return a;
                }
            }
        }

        protected override IPyValue VisitLambdaExpression(LambdaExpression src)
        {
            var T = new Translator(_state);
            var a = new PyMethodDefinition("");
            a.Statements.AddRange(T.TranslateStatement(src.Body));
            foreach (var p in src.Parameters)
            {
                var pyParameter = new PyMethodArgument {Name = p.Name};
                a.Arguments.Add(pyParameter);
            }

            var b = new PyLambdaExpression(a);
            return SimplifyPyExpression(b);
        }

        protected override IPyValue VisitLocalVariableExpression(LocalVariableExpression src)
        {
            if (_state.Principles.CurrentMethod == null)
                return PyVariableExpression.MakeLocal(src.Name, false);
            var isArgument = _state.Principles.CurrentMethod.GetParameters().Any(u => u.Name == src.Name);
            return PyVariableExpression.MakeLocal(src.Name, isArgument);
        }

        protected override IPyValue VisitMethodCallExpression(CsharpMethodCallExpression src)
        {
            var x = _state.Principles.NodeTranslators.Translate(_state, src);
            if (x is PyMethodCallExpression)
            {
                var t = (PyMethodCallExpression)x;
                if (t.Arguments != null && t.Arguments.Any())
                    foreach (var i in t.Arguments)
                        if (i.Expression == null)
                            throw new Exception("Invalid translation");
            }

            if (x != null)
                return SimplifyPyExpression(x);
            _state.Principles.NodeTranslators.Translate(_state, src);
            throw new NotSupportedException(src.ToString());
        }

        protected override IPyValue VisitMethodExpression(MethodExpression src)
        {
            if (src.Method.IsStatic)
            {
                var pyClassName =
                    _state.Principles.GetPyType(src.Method.DeclaringType, true, _state.Principles.CurrentType);
                if (pyClassName.IsEmpty)
                    throw new Exception("PyClassName cannot be null");
                pyClassName               = pyClassName.MakeAbsolute();
                var className             = new PyConstValue(pyClassName.FullName);
                var methodTranslationInfo = _state.Principles.GetOrMakeTranslationInfo(src.Method);
                if (!src.Method.IsPublic)
                    WriteWarning(string.Format("Using not public method {0}.{1} as expression",
                        src.Method.DeclaringType, src.Method.Name));
                var methodName    = new PyConstValue(methodTranslationInfo.ScriptName);
                var arrayCreation = new PyArrayCreateExpression(className, methodName);
                return SimplifyPyExpression(arrayCreation);
            }

            {
                // ryzykuję z this
                var targetObject          = new PyThisExpression();
                var methodTranslationInfo = _state.Principles.GetOrMakeTranslationInfo(src.Method);
                var methodName            = new PyConstValue(methodTranslationInfo.ScriptName);
                var arrayCreation         = new PyArrayCreateExpression(targetObject, methodName);
                return SimplifyPyExpression(arrayCreation);
            }
        }

        protected override IPyValue VisitParenthesizedExpression(ParenthesizedExpression src)
        {
            var e = TransValue(src.Expression);
            var a = new PyParenthesizedExpression(e);
            return SimplifyPyExpression(a);
        }

        protected override IPyValue VisitStaticMemberAccessExpression(StaticMemberAccessExpression src)
        {
            var yy  = src.Expression.DotnetType;
            var mem = yy.GetMembers(BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).ToArray()
                .Where(i => i.Name == src.MemberName).ToArray();
            if (mem.Length == 1)
            {
                var g = mem[0];
                if (g is FieldInfo)
                    return ConvertValueToPredefined(((FieldInfo)g).GetValue(null));
            }

            throw new NotSupportedException();
        }

        protected override IPyValue VisitThisExpression(ThisExpression src)
        {
            return new PyThisExpression();
        }

        protected override IPyValue VisitTypeOfExpression(TypeOfExpression src)
        {
            return new PyConstValue(src.DotnetType.Name);
        }

        protected override IPyValue VisitTypeValue(TypeValue src)
        {
            throw new NotSupportedException("Uzupełnij VisitTypeValue");
        }

        protected override IPyValue VisitUnaryOperatorExpression(UnaryOperatorExpression src)
        {
            var v = TransValue(src.Operand);
            var a = new PyUnaryOperatorExpression(v, src.Operator);
            return SimplifyPyExpression(a);
        }

        private readonly TranslationState _state;
    }
}