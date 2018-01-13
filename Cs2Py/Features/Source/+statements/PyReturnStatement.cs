using System.Collections.Generic;
using Cs2Py.Emit;

namespace Cs2Py.Source
{
    public class PyReturnStatement : PyStatementBase
    {
        /// <summary>
        ///     Tworzy instancję obiektu
        ///     <param name="returnValue"></param>
        /// </summary>
        public PyReturnStatement(IPyValue returnValue)
        {
            ReturnValue = returnValue;
        }
        // Public Methods 

        public override void Emit(PySourceCodeEmiter emiter, PySourceCodeWriter writer, PyEmitStyle style)
        {
            if (ReturnValue == null)
                writer.WriteLn("return;");
            else
                writer.WriteLnF("return {0};", ReturnValue.GetPyCode(style));
        }

        public override IEnumerable<ICodeRequest> GetCodeRequests()
        {
            return GetCodeRequests(ReturnValue);
        }

        public override IPyStatement Simplify(IPySimplifier s)
        {
            if (ReturnValue == null)
                return this;
            var newReturnValue = s.Simplify(ReturnValue);
            return ReturnValue == newReturnValue ? this : new PyReturnStatement(newReturnValue);
        }

        /// <summary>
        ///     Własność jest tylko do odczytu.
        /// </summary>
        public IPyValue ReturnValue { get; }
    }
}