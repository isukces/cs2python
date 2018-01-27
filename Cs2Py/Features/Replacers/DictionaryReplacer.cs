using System;
using System.Collections.Generic;
using System.Linq;
using Cs2Py.CSharp;
using Cs2Py.Source;
using Lang.Python;

namespace Cs2Py.Replacers
{
   [Replace(typeof(Dictionary<,>))]
    class DictionaryReplacer<TKey, TValue>
    {
        // Public Methods 

        
        [Translator]
        public static object __Translate(IExternalTranslationContext ctx, object src)
        {
            if (!(src is CallConstructor x)) 
                return null;
            if (x.Arguments.Length != 0)
                throw new NotSupportedException();
            if (x.Initializers.Length == 0)
                return new PyMethodCallExpression("dict");

            var d = new PyDictionaryCreateExpression(); 
            foreach(var i in x.Initializers)
            {
                if (i is CsharpAssignExpression ae)
                {
                    if (ae.Left is FunctionArguments_PseudoValue pv)
                    {
                        if (pv.Arguments.Length!=1)
                            throw new NotSupportedException("Key is multivalue");
                        var key = ctx.TranslateValue(pv.Arguments[0].MyValue);
                        var value = ctx.TranslateValue(ae.Right);
                        var item = new KeyValuePair<IPyValue, IPyValue>(key, value);
                        d.Initializers.Add(item);
                        
                    } else
                        throw new NotSupportedException(ae.Left?.GetType().ToString());
                }
                else
                    throw new NotSupportedException(i?.GetType().ToString());
            }

            return d;
            /*
             
             cmap =  {'US':'USA','GB':'Great Britain'}
            var g = new PhpArrayCreateExpression();
            var a = x.Initializers.Cast<IValueTable_PseudoValue>().ToArray();
            List<IPhpValue> o = new List<IPhpValue>();
            foreach (var i in a)
            {
                var a1 = i as IValueTable_PseudoValue;
                var a2 = a1.Items[0];
                var a3 = a1.Items[1];
                var key = ctx.TranslateValue(a2);
                var value = ctx.TranslateValue(a3);
                var t = new PhpAssignExpression(key, value);
                o.Add(t);
            }
            g.Initializers = o.ToArray();
            return g;            
            */
            return null;
        }
        

#if OLD
    // Public Methods 

        [DirectCall("array_key_exists", "0,this")]
        public bool ContainsKey(TKey key)
        {
            throw new MockMethodException();
        }

        [DirectCall("array_key_exists", "0,this")]
        public bool ContainsKey(object key)
        {
            //  bool array_key_exists ( mixed $key , array $array )
            throw new MockMethodException();
        }
#endif
        [DirectCall("len", "this")]
        public int Count{get;set;}

        
        [DirectCall("->clear", "")]
        public void Clear()
        {
            
        }

       
    }
}