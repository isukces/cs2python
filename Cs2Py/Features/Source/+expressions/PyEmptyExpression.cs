using System.Collections.Generic;
using Cs2Py.Emit;

namespace Cs2Py.Source
{
    public class PyEmptyExpression : IPyValue
    {
        public IEnumerable<ICodeRequest> GetCodeRequests()
        {
            return new ICodeRequest[0];
        }

        public string GetPyCode(PyEmitStyle style)
        {
            return null;
        }
    }
}