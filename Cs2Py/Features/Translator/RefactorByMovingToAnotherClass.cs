using System;
using Cs2Py.CodeVisitors;
using Cs2Py.Source;

namespace Cs2Py.Translator
{
    /// <summary>
    /// Making this is too complicated at the beginning of cs2py
    /// </summary>
    internal class RefactorByMovingToAnotherClass : PyBaseVisitor<IPyValue>
    {
        public IPyValue ConvertAndRefactor(IPyValue value)
        {
            return Visit(value as PySourceBase);
        }

        protected override IPyValue VisitPyBinaryOperatorExpression(PyBinaryOperatorExpression node)
        {
            var v1 = ConvertAndRefactor(node.Left);
            var v2 = ConvertAndRefactor(node.Right);
            return node;
        }

        protected override IPyValue VisitPyClassFieldAccessExpression(PyClassFieldAccessExpression node)
        {
            throw new NotSupportedException();
        }
    }
}