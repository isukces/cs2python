using System;
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
            if (src.MethodInfo.DeclaringType == typeof(Console))
            {
                var info = MapNamedParameters(src);

                if (src.MethodInfo.Name == nameof(Console.WriteLine))
                    if (info.MethodParameters.Length == 1)
                    {
                        var v                       = ctx.TranslateValue(info.CallArguments[0].MyValue);
                        var result                  = new PyMethodCallExpression(null, "print", v);
                        // In Python 3, print is a function, whereas it used to be a statement in previous versions.
                        /*
                        result.OnSkipBracketRequest += (mce, args) =>
                        {
                            args.CanSkipBrackets = GeneralRulesForMetodBrackets.Bla(mce);
                        };
                        */
                        return result;
                    }

                var mn = src.MethodInfo.ToString();
                throw new NotImplementedException(mn);
            }

            return null;
        }
    }
}