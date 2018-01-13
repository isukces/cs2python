using System;
using System.Collections.Generic;
using Cs2Py.Emit;
using Cs2Py.Source;

namespace Cs2Py
{
    public abstract class PyValueBase : PySourceBase, IPyValue
    {
        // Public Methods 

        public abstract IEnumerable<ICodeRequest> GetCodeRequests();
        public abstract string GetPyCode(PyEmitStyle style);

        public virtual IPyValue Simplify(IPyExpressionSimplifier s)
        {
            return this;
        }

        public override string ToString()
        {
            return GetPyCode(null);
        }
        // Protected Methods 

        protected static IPyValue SimplifyForFieldAcces(IPyValue src, IPyExpressionSimplifier s)
        {
            src = s.Simplify(src);
            if (!(src is PyParenthesizedExpression)) return src;
            var inside = (src as PyParenthesizedExpression).Expression;
            if (inside is PyVariableExpression)
                return inside;
            if (inside is PyMethodCallExpression)
                return (inside as PyMethodCallExpression).IsConstructorCall ? src : inside;
            if (inside is PyBinaryOperatorExpression || inside is PyConditionalExpression)
                return src;
            throw new NotSupportedException();
        }

        protected IPyValue StripBracketsAndSimplify(IPyValue value, IPyExpressionSimplifier s)
        {
            value = PyParenthesizedExpression.Strip(value);
            value = s.Simplify(value);
            return value;
        }
    }
}