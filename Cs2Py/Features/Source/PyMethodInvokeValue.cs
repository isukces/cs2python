using System;
using System.Collections.Generic;
using Cs2Py.Emit;

namespace Cs2Py.Source
{
    public class PyMethodInvokeValue : PyValueBase
    {
        /// <summary>
        ///     Tworzy instancję obiektu
        ///     <param name="expression"></param>
        /// </summary>
        public PyMethodInvokeValue(IPyValue expression)
        {
            Expression = expression;
        }

        public override IEnumerable<ICodeRequest> GetCodeRequests()
        {
            return Expression == null ? new ICodeRequest[0] : Expression.GetCodeRequests();
        }

        public override string GetPyCode(PyEmitStyle style)
        {
            if (Expression == null)
                throw new Exception("Unable to get code from empty expression");
            var ex = PyParenthesizedExpression.Strip(Expression);
            var a  = Expression.GetPyCode(style);
            if (ByRef)
                throw new NotSupportedException("'By ref' argument is not supported");
            if (!string.IsNullOrEmpty(Name))
                a = Name + "=" + a;
            return a;
        }

        /// <summary>
        /// </summary>
        public IPyValue Expression { get; set; }

        /// <summary>
        /// </summary>
        public bool ByRef { get; set; }

        public string Name { get; set; }
    }
}