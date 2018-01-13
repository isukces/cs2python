using System.Collections.Generic;
using Cs2Py.Emit;

namespace Cs2Py.Source
{
    public class PyUnaryOperatorExpression : PyValueBase
    {
        /// <summary>
        ///     Tworzy instancję obiektu
        ///     <param name="operand"></param>
        ///     <param name="_operator"></param>
        /// </summary>
        public PyUnaryOperatorExpression(IPyValue operand, string _operator)
        {
            Operand  = operand;
            Operator = _operator;
        }
        // Public Methods 

        public override IEnumerable<ICodeRequest> GetCodeRequests()
        {
            return Operand == null ? new ICodeRequest[0] : Operand.GetCodeRequests();
        }

        public override string GetPyCode(PyEmitStyle style)
        {
            return string.Format("{0}{1}", Operator, Operand.GetPyCode(style));
        }


        /// <summary>
        ///     Własność jest tylko do odczytu.
        /// </summary>
        public IPyValue Operand { get; }

        /// <summary>
        ///     Własność jest tylko do odczytu.
        /// </summary>
        public string Operator { get; } = string.Empty;
    }
}