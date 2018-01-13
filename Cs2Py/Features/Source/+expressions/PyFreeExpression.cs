using System.Collections.Generic;
using Cs2Py.Emit;

namespace Cs2Py.Source
{
    public class PyFreeExpression : PyValueBase
    {
        /// <summary>
        ///     Tworzy instancję obiektu
        ///     <param name="expression"></param>
        /// </summary>
        public PyFreeExpression(string expression)
        {
            Expression = expression;
        }

        public override IEnumerable<ICodeRequest> GetCodeRequests()
        {
            return new ICodeRequest[0];
        }

        public override string GetPyCode(PyEmitStyle style)
        {
            return _expression;
        }

        /// <summary>
        /// </summary>
        public string Expression
        {
            get => _expression;
            set => _expression = (value ?? string.Empty).Trim();
        }

        private string _expression = string.Empty;
    }
}