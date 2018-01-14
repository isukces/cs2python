using System.Collections.Generic;
using Cs2Py.Emit;

namespace Cs2Py.Source
{
    public class PyThisExpression : PyValueBase
    {
        public override string GetPyCode(PyEmitStyle style)
        {
            return "self";
        }

        public override IEnumerable<ICodeRequest> GetCodeRequests()
        {
            return new ICodeRequest[0];
        }
    }
}
