using System;
using System.Collections.Generic;
using Cs2Py.CodeVisitors;
using Cs2Py.Emit;

namespace Cs2Py.Source
{
    public class PyBinaryOperatorExpression : PyValueBase
    {

        public override string GetPyCode(PyEmitStyle style)
        {
            if (style == null || style.Compression == EmitStyleCompression.Beauty)
                return string.Format("{0} {1} {2}", Left.GetPyCode(style), Operator, Right.GetPyCode(style));
            return string.Format("{0}{1}{2}",       Left.GetPyCode(style), Operator, Right.GetPyCode(style));
        }

        public override IEnumerable<ICodeRequest> GetCodeRequests()
        {
            return PyStatementBase.GetCodeRequests(Left, Right);
        }
   

        /// <summary>
        /// Helper method
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        public static IPyValue ConcatStrings(params IPyValue[] items)
        {
            if (items == null) return null;
            IPyValue result = null;
            foreach (var i in items)
            {
                if (result == null)
                    result = i;
                else
                    result = new PyBinaryOperatorExpression(".", result, i);
            }
            if (result != null)
            {
                var simplifier = new ExpressionSimplifier(new OptimizeOptions());
                result         = simplifier.Simplify(result);
            }
            return result;
        }


        /// <summary>
        /// Tworzy instancję obiektu
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="operator_"></param>
        /// </summary>
        public PyBinaryOperatorExpression(string operator_, IPyValue left, IPyValue right)
        {
            if (left == null) throw new ArgumentNullException(nameof(left));
            if (right == null) throw new ArgumentNullException(nameof(right));
            Left          = left;
            Right         = right;
            Operator = operator_;
        }

        /// <summary>
        /// Własność jest tylko do odczytu.
        /// </summary>
        public IPyValue Left { get; }

        /// <summary>
        /// Własność jest tylko do odczytu.
        /// </summary>
        public IPyValue Right { get; }

        /// <summary>
        /// Własność jest tylko do odczytu.
        /// </summary>
        public string Operator { get; } = string.Empty;
    }
}