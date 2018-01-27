using System;
using System.Collections.Generic;
using System.Linq;
using Cs2Py.Emit;

namespace Cs2Py.Source
{
    public class PyDictionaryCreateExpression : PyValueBase
    {
        public override IEnumerable<ICodeRequest> GetCodeRequests()
        {
            var result = new List<ICodeRequest>();
            foreach (var pair in Initializers)
            {
                var q = from p in new[] {pair.Key, pair.Value} where p != null from r in p.GetCodeRequests() select r;
                result.AddRange(q);
            }

            return result;
        }

        public override string GetPyCode(PyEmitStyle style)
        {
            if (Initializers.Count == 0)
                return "dict()";
            var initializers = Initializers.Select(a => a.Key.GetPyCode(style) + ":" + a.Value.GetPyCode(style));
            var code = string.Join(", ", initializers);
            return "{" + code + "}";
        }

        public List<KeyValuePair<IPyValue, IPyValue>> Initializers { get; } =
            new List<KeyValuePair<IPyValue, IPyValue>>();
    }
}