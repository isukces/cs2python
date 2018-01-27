using System;
using System.Linq;
using System.Reflection;
using Cs2Py.CSharp;
using Lang.Python.Numpy;

namespace Cs2Py.NodeTranslators
{
    public class LinqTranslators : BaseCsharpMethodCallExpressionTranslator
    {
        public LinqTranslators() : base(100)
        {
        }

        private static IPyValue Translate_Enumerable_Range(IExternalTranslationContext ctx,
            CsharpMethodCallExpression                                                 src)
        {
            var info = MapNamedParameters(src);
            // mapujemy na arange
            var methods = typeof(Np).GetMethods(BindingFlags.Public | BindingFlags.Static)
                .ToDictionary(a => a.ToString(), a => a);
            var tmp = methods["System.Collections.Generic.List`1[System.Int32] ARange(Int32, Int32, Int32)"];

            var v1 = info.GetArgumentValue(0);
            var v2 = info.GetArgumentValue(1);

            var max = new BinaryOperatorExpression(v1, v2, "+", typeof(int), null);

            var newCall = new CsharpMethodCallExpression(tmp, null, new[]
            {
                new FunctionArgument(v1),
                new FunctionArgument(max)
            }, null, false);
            return ctx.TranslateValue(newCall);
        }


        public override IPyValue TranslateToPython(IExternalTranslationContext ctx, CsharpMethodCallExpression src)
        {
            var mi   = src.MethodInfo;
            var type = mi.DeclaringType;
            if (mi.IsGenericMethod)
                mi = mi.GetGenericMethodDefinition();

            if (type == typeof(Enumerable))
            {
                switch (mi.Name)
                {
                    case "ToArray":
                    case "ToList":
                        return ctx.TranslateValue(src.Arguments[0]);
                }

                var mn = mi.ToString();
                switch (mn)
                {
                    case "System.Collections.Generic.IEnumerable`1[System.Int32] Range(Int32, Int32)":
                        return Translate_Enumerable_Range(ctx, src);
                    default:
                        throw new NotImplementedException(mn);
                }
            }

            return null;
        }
    }
}