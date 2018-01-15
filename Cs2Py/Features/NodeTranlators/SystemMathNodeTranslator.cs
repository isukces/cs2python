using System;
using Cs2Py.CSharp;
using Cs2Py.Source;

namespace Cs2Py.NodeTranlators
{
    public class SystemMathNodeTranslator : IPyNodeTranslator<CsharpMethodCallExpression>
    {
        private static IPyValue SingleArg(IExternalTranslationContext ctx, CsharpMethodCallExpression src)
        {
            if (src.Arguments.Length != 1)
                throw new Exception("Only one argument expected for " + src.MethodInfo.Name);
            var arg0     = src.Arguments[0];
            var pyValue0 = ctx.TranslateValue(arg0.MyValue);
            return pyValue0;
        }

        private static IPyValue SingleArgumentMathFunction(
            string                      name,
            IExternalTranslationContext ctx,
            CsharpMethodCallExpression  src)
        {
            var moduleExpression = new PyModuleExpression(PyModules.Math, name);
            return new PyMethodCallExpression(moduleExpression, name, SingleArg(ctx, src));
        }

        public int GetPriority()
        {
            return 1;
        }

        public IPyValue TranslateToPython(IExternalTranslationContext ctx, CsharpMethodCallExpression src)
        {
            if (src.MethodInfo.DeclaringType == typeof(Math))
            {
                // https://docs.python.org/3/library/math.html
                var fn = src.MethodInfo.ToString();
                switch (fn)
                {
                    case "Double Sin(Double)":
                    case "Double Cos(Double)":
                    case "Double Tan(Double)":
                        return SingleArgumentMathFunction(src.MethodInfo.Name.ToLower(), ctx, src);
                }

                throw new NotImplementedException($"{nameof(SystemMathNodeTranslator)}->{fn}");
            }             
            if (src.MethodInfo.DeclaringType == typeof(double))
            {
                var fn = src.MethodInfo.ToString();
                switch (fn)
                {
                    case "Boolean IsNaN(Double)":
                        return SingleArgumentMathFunction("isnan", ctx, src);
                    case "Boolean IsInfinity(Double)":
                        return SingleArgumentMathFunction("isinf", ctx, src);
                }
            }

            return null;
        }

 
    }
}