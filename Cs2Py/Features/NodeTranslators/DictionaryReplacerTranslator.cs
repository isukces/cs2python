using System;
using System.Collections.Generic;
using Cs2Py.CSharp;
using Cs2Py.Replacers;
using Cs2Py.Source;

namespace Cs2Py.NodeTranslators
{
    public class DictionaryReplacerTranslator : BaseCsharpMethodCallExpressionTranslator
    {
        public DictionaryReplacerTranslator() : base(-100)
        {
        }
        

        public override IPyValue TranslateToPython(IExternalTranslationContext ctx, CsharpMethodCallExpression src)
        {
            var dt = src.GenericDeclaringType;
            if (dt == typeof(DictionaryReplacer<,>) || dt == typeof(Dictionary<,>))
                if (src.MethodName == nameof(DictionaryReplacer<int, int>.Remove))
                {
                    // del myDict['key']
                    var args = MapNamedParameters(src);
                    var key = ctx.TranslateValue(args.GetArgumentValue(0));
                    var target = ctx.TranslateValue(src.TargetObject);
                    IPyValue arg = new PyArrayAccessExpression(target,key);
                    var m = new PyMethodCallExpression("del", arg)
                    {
                        SkipBrackets = true
                    };
                    return m;

                }
                    

            return null;
        }
    }
}