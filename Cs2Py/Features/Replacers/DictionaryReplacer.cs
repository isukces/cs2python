using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Cs2Py.CSharp;
using Cs2Py.Source;
using Lang.Python;

namespace Cs2Py.Replacers
{
    [Replace(typeof(Dictionary<,>))]
    [Replace(typeof(IDictionary<,>))]
    [Replace(typeof(IReadOnlyDictionary<,>))]
    internal class DictionaryReplacer<TKey, TValue>
    {
        [Translator]
        public static object __Translate(IExternalTranslationContext ctx, object src)
        {
            switch (src)
            {
                case CallConstructor callConstructor:
                    return __Translate_CallConstructor(callConstructor, ctx);

                case MethodCallExpression mce:
                    return _Translate_MethodCallExpression(mce, ctx);
            }

            return null;
        }

        private static object __Translate_CallConstructor(CallConstructor x, IExternalTranslationContext ctx)
        {
            if (x.Arguments.Length != 0)
                throw new NotSupportedException();
            if (x.Initializers.Length == 0)
                return new PyMethodCallExpression("dict");

            var d = new PyDictionaryCreateExpression();
            foreach (var i in x.Initializers)
                if (i is CsharpAssignExpression ae)
                    if (ae.Left is FunctionArguments_PseudoValue pv)
                    {
                        if (pv.Arguments.Length != 1)
                            throw new NotSupportedException("Key is multivalue");
                        var key   = ctx.TranslateValue(pv.Arguments[0].MyValue);
                        var value = ctx.TranslateValue(ae.Right);
                        var item  = new KeyValuePair<IPyValue, IPyValue>(key, value);
                        d.Initializers.Add(item);
                    }
                    else
                    {
                        throw new NotSupportedException(ae.Left?.GetType().ToString());
                    }
                else
                    throw new NotSupportedException(i?.GetType().ToString());

            return d;
        }

        private static object _Translate_MethodCallExpression(MethodCallExpression mce,
            IExternalTranslationContext                                             ctx)
        {
            if (mce.Method.Name == nameof(Remove))
            {
                throw new NotSupportedException();
            }

            return null;
        }

        [DirectCall("->clear", "")]
        public void Clear()
        {
        }
       
        [DirectCall("->has_key")]
        public bool ContainsKey(TKey key)
        {
            throw new NotImplementedException();
        }


        public bool Remove(TKey key)
        {
            // del dict['Name'];
            throw new NotImplementedException();
        }


        [DirectCall("len", "this")]
        public int Count { get; set; }

        [DirectCall("->keys", "")]
        public IEnumerable<TKey> Keys => throw new NotImplementedException();

        [DirectCall("->values", "")]
        public IEnumerable<TValue> Values => throw new NotImplementedException();
    }
}