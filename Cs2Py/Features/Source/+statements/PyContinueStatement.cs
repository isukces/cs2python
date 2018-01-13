using System.Collections.Generic;
using Cs2Py.Emit;

namespace Cs2Py.Source
{
    public class PyContinueStatement : PyStatementBase
    {
        // Public Methods 

        public override void Emit(PySourceCodeEmiter emiter, PySourceCodeWriter writer, PyEmitStyle style)
        {
            var s = style?.Compression ?? EmitStyleCompression.Beauty;
            if (s == EmitStyleCompression.NearCrypto)
                writer.Write("continue;");
            else
                writer.WriteLn("continue;");
        }

        public override IEnumerable<ICodeRequest> GetCodeRequests()
        {
            return new ICodeRequest[0];
        }
    }
}
