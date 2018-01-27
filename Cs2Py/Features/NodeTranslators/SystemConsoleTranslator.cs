using System;
using Cs2Py.Compilation;
using Cs2Py.CSharp;
using Cs2Py.Source;

namespace Cs2Py.NodeTranslators
{
    public class SystemConsoleTranslator : BaseCsharpMethodCallExpressionTranslator
    {
        public SystemConsoleTranslator() : base(10)
        {
        }

        public override IPyValue TranslateToPython(IExternalTranslationContext ctx, CsharpMethodCallExpression src)
        {
            if (src.MethodInfo.DeclaringType == typeof(System.Console))
            {
                var info = MapNamedParameters(src);

                if (src.MethodInfo.Name == nameof(Console.WriteLine))
                {
                    if (info.MethodParameters.Length == 1)
                    {
                        var v = ctx.TranslateValue(info.CallArguments[0].MyValue);
                        var a =new PyMethodCallExpression(null, "print", v);
                        a.SkipBrackets = true;
                        return a;
                    }
                }
                var mn = src.MethodInfo.ToString();
                
                throw new NotImplementedException(mn);
            }

            return null;
        }
    }
}