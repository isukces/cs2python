using System;
using System.Collections.Generic;
using Cs2Py.Emit;

namespace Cs2Py.Source
{
    public class PyMethodInvokeValue : PyValueBase
    {
        /// <summary>
        ///     Tworzy instancję obiektu
        ///     <param name="Expression"></param>
        /// </summary>
        public PyMethodInvokeValue(IPyValue Expression)
        {
            this.Expression = Expression;
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
                a = "&" + a;
            return a;
        }

        /// <summary>
        /// </summary>
        public IPyValue Expression { get; set; }

        /// <summary>
        /// </summary>
        public bool ByRef { get; set; }

        /// <summary>
        ///     Nazwa własności Expression;
        /// </summary>
        public const string PROPERTYNAME_EXPRESSION = "Expression";

        /// <summary>
        ///     Nazwa własności ByRef;
        /// </summary>
        public const string PROPERTYNAME_BYREF = "ByRef";
    }
}