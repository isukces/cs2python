using System;
using Cs2Py.CSharp;
using Cs2Py.Source;

namespace Cs2Py.NodeTranlators
{
    public class SystemMathNodeTranslator : IPyNodeTranslator<CsharpMethodCallExpression>
    {
        public int GetPriority()
        {
            return 1;
        }

        public IPyValue TranslateToPython(IExternalTranslationContext ctx, CsharpMethodCallExpression src)
        {
            if (src.MethodInfo.DeclaringType != typeof(Math)) return null;
            var fn = src.MethodInfo.ToString();

            IPyValue SingleArg()
            {
                if (src.Arguments.Length != 1)
                    throw new Exception("Only one argument expected for " + src.MethodInfo.Name);
                var arg0     = src.Arguments[0];
                var pyValue0 = ctx.TranslateValue(arg0.MyValue);
                return pyValue0;
            }

            IPyValue SingleArgumentMathFunction(string name)
            {
                var moduleExpression = new PyModuleExpression(PyModules.Math, name);
                return new PyMethodCallExpression(moduleExpression, name, SingleArg());
            }

            switch (fn)
            {
                case "Double Sin(Double)":
                    return SingleArgumentMathFunction("sin");
                case "Double Cos(Double)":
                    return SingleArgumentMathFunction("cos");
            }

            throw new NotImplementedException($"{nameof(SystemMathNodeTranslator)}->{fn}");
        }
    }
}