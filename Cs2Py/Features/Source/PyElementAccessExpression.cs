using System.Collections.Generic;
using System.Linq;
using Cs2Py.Emit;

namespace Cs2Py.Source
{
    public class PyElementAccessExpression : PyValueBase
    {
        /// <summary>
        ///     Tworzy instancję obiektu
        ///     <param name="expression"></param>
        ///     <param name="arguments"></param>
        /// </summary>
        public PyElementAccessExpression(IPyValue expression, IPyValue[] arguments)
        {
            Expression = expression;
            Arguments  = arguments;
        }

        public override IEnumerable<ICodeRequest> GetCodeRequests()
        {
            var a = PyStatementBase.GetCodeRequests<IPyValue>(Arguments);
            var b = PyStatementBase.GetCodeRequests(Expression);
            return a.Union(b).ToArray();
        }

        public override string GetPyCode(PyEmitStyle style)
        {
            var a = Arguments.Select(u => u.GetPyCode(style));
            return string.Format("{0}[{1}]", Expression.GetPyCode(style), string.Join(",", a));
        }

        public override IPyValue Simplify(IPyExpressionSimplifier s)
        {
            var expression = SimplifyForFieldAcces(Expression, s);
            if (Arguments == null || Arguments.Length == 0)
            {
                if (EqualCode(expression, Expression))
                    return this;
                return new PyElementAccessExpression(expression, null);
            }

            var arguments = Arguments.Select(i => StripBracketsAndSimplify(i, s)).ToArray();
            var candidate = new PyElementAccessExpression(expression, arguments);
            if (EqualCode(candidate, this))
                return this;
            return candidate;
        }

        /// <summary>
        ///     Własność jest tylko do odczytu.
        /// </summary>
        public IPyValue Expression { get; }

        /// <summary>
        ///     Własność jest tylko do odczytu.
        /// </summary>
        public IPyValue[] Arguments { get; }
    }
}