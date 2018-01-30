using System.Collections.Generic;
using Cs2Py.Emit;

namespace Cs2Py.Source
{
    public class PyArrayAccessExpression : PyValueBase
    {
        /// <summary>
        ///     Tworzy instancję obiektu
        ///     <param name="pyArray"></param>
        ///     <param name="index"></param>
        /// </summary>
        public PyArrayAccessExpression(IPyValue pyArray, IPyValue index)
        {
            PyArray = pyArray;
            Index = index;
        }


        public override IEnumerable<ICodeRequest> GetCodeRequests()
        {
            return PyStatementBase.GetCodeRequests(PyArray, Index);
        }

        public override string GetPyCode(PyEmitStyle style)
        {
            return string.Format("{0}[{1}]", PyArray.GetPyCode(style), Index.GetPyCode(style));
        }

        /// <summary>
        ///     Własność jest tylko do odczytu.
        /// </summary>
        public IPyValue PyArray { get; }

        /// <summary>
        ///     Własność jest tylko do odczytu.
        /// </summary>
        public IPyValue Index { get; }
    }
}