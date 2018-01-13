using System.Collections.Generic;
using Cs2Py.Emit;

namespace Cs2Py.Source
{
    public class PyLambdaExpression : ICodeRelated, IPyValue
    {
        /// <summary>
        ///     Tworzy instancję obiektu
        ///     <param name="methodDefinition"></param>
        /// </summary>
        public PyLambdaExpression(PyMethodDefinition methodDefinition)
        {
            MethodDefinition = methodDefinition;
        }

        public IEnumerable<ICodeRequest> GetCodeRequests()
        {
            return MethodDefinition.GetCodeRequests();
        }

        public string GetPyCode(PyEmitStyle style)
        {
            /*
             echo preg_replace_callback('~-([a-z])~', function ($match) {
    return strtoupper($match[1]);
}, 'hello-world');
// outputs helloWorld
             */
            var s           = PyEmitStyle.xClone(style);
            s.AsIncrementor = true;
            var e           = new PySourceCodeEmiter();
            var wde         = new PySourceCodeWriter();
            wde.Clear();
            MethodDefinition.Emit(e, wde, s);
            var code = wde.GetCode(true).Trim();
            return code;
        }

        /// <summary>
        /// </summary>
        public PyMethodDefinition MethodDefinition { get; set; }
    }
}