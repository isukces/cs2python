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

        private static bool IsDictionary(Type dt)
        {
            return dt == typeof(DictionaryReplacer<,>) || dt == typeof(Dictionary<,>);
        }


        public override IPyValue TranslateToPython(IExternalTranslationContext ctx, CsharpMethodCallExpression src)
        {
            var dt = src.GenericDeclaringType;
            if (!IsDictionary(dt)) return null;
            switch (src.MethodName)
            {
                case nameof(DictionaryReplacer<int, int>.Remove):
                    // del myDict['key']
                    var      args          = MapNamedParameters(src);
                    var      key           = ctx.TranslateValue(args.GetArgumentValue(0));
                    var      target        = ctx.TranslateValue(src.TargetObject);
                    IPyValue arg           = new PyArrayAccessExpression(target, key);
                    var      m             = new PyMethodCallExpression("del", arg);
                    m.OnSkipBracketRequest += (mce, args2) =>
                    {
                        args2.CanSkipBrackets = GeneralRulesForMetodBrackets.Bla(mce);
                    };
                    return m;
            }

            return null;
        }
    }
}