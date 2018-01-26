using System;
using System.Linq;
using System.Reflection;
using Cs2Py.CSharp;

namespace Cs2Py.NodeTranslators
{
    public abstract class CsharpMethodCallExpressionTranslatorBase : IPyNodeTranslator<CsharpMethodCallExpression>
    {
        protected CsharpMethodCallExpressionTranslatorBase(int priority)
        {
            _priority = priority;
        }

        protected static Info MapNamedParameters(CsharpMethodCallExpression src)
        {
            var args             = src.Arguments ?? new FunctionArgument[0];
            var methodParameters = src.MethodInfo.GetParameters();
            var callArguments    = new FunctionArgument[methodParameters.Length];
            var nameToIdxMap     = Enumerable.Range(0, methodParameters.Length)
                .ToDictionary(q => methodParameters[q].Name, q => q);
            var needExplicitName = false;

            int FindIdx(int argumentIdx)
            {
                var a            = args[argumentIdx];
                var explicitName = a.ExplicitName;
                if (string.IsNullOrEmpty(explicitName))
                {
                    if (needExplicitName)
                        throw new Exception($"argument idx={argumentIdx} requires parameter name");
                    return argumentIdx;
                }

                if (explicitName == methodParameters[argumentIdx].Name)
                    return argumentIdx;
                needExplicitName = true;
                if (!nameToIdxMap.TryGetValue(explicitName, out var idx))
                    throw new Exception($"Method {src.MethodInfo} doesn\'t have parameter {explicitName}");
                return idx;
            }

            for (var i = 0; i < args.Length; i++)
            {
                var idx            = FindIdx(i);
                callArguments[idx] = args[i];
            }

            return new Info(callArguments, methodParameters);
        }

        public int GetPriority()
        {
            return _priority;
        }

        public abstract  IPyValue TranslateToPython(IExternalTranslationContext ctx, CsharpMethodCallExpression src);
        private readonly int      _priority;

        public class Info
        {
            public Info(FunctionArgument[] callArguments, ParameterInfo[] methodParameters)
            {
                CallArguments    = callArguments;
                MethodParameters = methodParameters;
            }

            public IValue GetArgumentValue(int idx)
            {
                if (idx < 0 || idx >= CallArguments.Length)
                    throw new ArgumentException("Out of range");
                var tmp = CallArguments[idx];
                if (tmp != null)
                    return tmp.MyValue;
                var p = MethodParameters[idx];
                if (p.HasDefaultValue)
                    return new ConstValue(p.DefaultValue);
                throw new Exception("Parameter " + p.Name + " doesn't have default value");
            }

            public FunctionArgument[] CallArguments    { get; private set; }
            public ParameterInfo[]    MethodParameters { get; private set; }
        }
    }
}