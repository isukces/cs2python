using System.Collections.Generic;
using Cs2Py.Emit;

namespace Cs2Py.Source
{
    public class PyParenthesizedExpression : PyValueBase
    {
        /// <summary>
        ///     Tworzy instancję obiektu
        ///     <param name="expression"></param>
        /// </summary>
        public PyParenthesizedExpression(IPyValue expression)
        {
            Expression = expression;
        }
        // Public Methods 

        public static IPyValue Strip(IPyValue x)
        {
            if (x is PyParenthesizedExpression)
                return Strip((x as PyParenthesizedExpression).Expression);
            return x;
        }

        // Public Methods 

        public override IEnumerable<ICodeRequest> GetCodeRequests()
        {
            return Expression == null ? new ICodeRequest[0] : Expression.GetCodeRequests();
        }

        public override string GetPyCode(PyEmitStyle style)
        {
            return string.Format("({0})", Expression.GetPyCode(style));
        }


        /// <summary>
        ///     Własność jest tylko do odczytu.
        /// </summary>
        public IPyValue Expression { get; }
    }
}