using System.Collections.Generic;
using Cs2Py.Emit;

namespace Cs2Py.Source
{
    public class PyArrayAccessExpression : PyValueBase
    {
        /// <summary>
        ///     Tworzy instancję obiektu
        ///     <param name="PyArray"></param>
        ///     <param name="index"></param>
        /// </summary>
        public PyArrayAccessExpression(IPyValue PyArray, IPyValue index)
        {
            PyArray = PyArray;
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