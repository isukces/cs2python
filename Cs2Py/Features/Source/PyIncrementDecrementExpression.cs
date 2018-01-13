using System.Collections.Generic;
using Cs2Py.Emit;

namespace Cs2Py.Source
{
    public class PyIncrementDecrementExpression : PyValueBase
    {
        // Public Methods 

        public override string GetPyCode(PyEmitStyle style)
        {
            var o = Increment ? "++" : "--";
            return string.Format("{0}{1}{2}",
                Pre ? o : "",
                Operand.GetPyCode(style),
                Pre ? "" : o);
        }

        public override IEnumerable<ICodeRequest> GetCodeRequests()
        {
            return PyStatementBase.GetCodeRequests(Operand);
        }

        /// <summary>
        /// Tworzy instancję obiektu
        /// <param name="operand">,</param>
        /// <param name="increment"></param>
        /// <param name="pre"></param>
        /// </summary>
        public PyIncrementDecrementExpression(IPyValue operand, bool increment, bool pre)
        {
            Operand = operand;
            Increment = increment;
            Pre = pre;
        }


        /// <summary>
        /// ,
        /// </summary>
        public IPyValue Operand { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool Increment { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool Pre { get; set; }
    }
}
