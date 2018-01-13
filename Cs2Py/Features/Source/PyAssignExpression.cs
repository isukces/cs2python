using System.Collections.Generic;
using System.Linq;
using Cs2Py.Emit;

namespace Cs2Py.Source
{

    public class PyAssignExpression : PyValueBase
    {
        // Public Methods 

        public override IEnumerable<ICodeRequest> GetCodeRequests()
        {
            var a = PyStatementBase.GetCodeRequests(Left, Right).ToArray();
            return a;
        }

        public override string GetPyCode(PyEmitStyle style)
        {
            if (style == null || style.Compression == EmitStyleCompression.Beauty)
                return string.Format("{0} {1}= {2}", Left.GetPyCode(style), _optionalOperator, Right.GetPyCode(style));
            return string.Format("{0}{1}={2}", Left.GetPyCode(style), _optionalOperator, Right.GetPyCode(style));
        }

        public override IPyValue Simplify(IPyExpressionSimplifier s)
        {
            var right = StripBracketsAndSimplify(Right, s);
            var left = s.Simplify(Left);
            if (left is PyPropertyAccessExpression)
            {
                var e = left as PyPropertyAccessExpression;
                var a = e.MakeSetValueExpression(right);
                if (a is PyAssignExpression && (a as PyAssignExpression).Left is PyPropertyAccessExpression)
                    if (EqualCode(a, this))
                        return this;
                return a;

            }
            if (EqualCode(left, Left) && EqualCode(right, Right))
                return this;
            return new PyAssignExpression(left, right, _optionalOperator);
        }


        /// <summary>
        /// Tworzy instancję obiektu
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="optionalOperator"></param>
        /// </summary>
        public PyAssignExpression(IPyValue left, IPyValue right, string optionalOperator)
        {
            Left = left;
            Right = right;
            OptionalOperator = optionalOperator;
        }

        /// <summary>
        /// Tworzy instancję obiektu
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// </summary>
        public PyAssignExpression(IPyValue left, IPyValue right)
        {
            Left = left;
            Right = right;
        }


        /// <summary>
        /// 
        /// </summary>
        public IPyValue Left { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public IPyValue Right { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string OptionalOperator
        {
            get => _optionalOperator;
            set => _optionalOperator = (value ?? string.Empty).Trim();
        }
        private string _optionalOperator = string.Empty;
    }
}
