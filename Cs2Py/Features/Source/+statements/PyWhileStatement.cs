using System.Collections.Generic;
using Cs2Py.Emit;

namespace Cs2Py.Source
{
    public class PyWhileStatement : PyStatementBase
    {
        /// <summary>
        ///     Tworzy instancję obiektu
        ///     <param name="condition"></param>
        ///     <param name="statement"></param>
        /// </summary>
        public PyWhileStatement(IPyValue condition, IPyStatement statement)
        {
            Condition = condition;
            Statement = statement;
        }

        // Public Methods 

        public override void Emit(PySourceCodeEmiter emiter, PySourceCodeWriter writer, PyEmitStyle style)
        {
            style      = style ?? new PyEmitStyle();
            var header = string.Format("while({0})", Condition.GetPyCode(style));
            EmitHeaderStatement(emiter, writer, style, header, Statement);
        }

        public override IEnumerable<ICodeRequest> GetCodeRequests()
        {
            return GetCodeRequests(Condition, Statement);
        }

        public override IPyStatement Simplify(IPySimplifier s)
        {
            var newCondition = s.Simplify(Condition);
            var newStatement = s.Simplify(Statement);
            if (newCondition == Condition && newStatement == Statement)
                return this;
            return new PyWhileStatement(newCondition, newStatement);
        }

        /// <summary>
        /// </summary>
        public IPyValue Condition { get; set; }

        /// <summary>
        /// </summary>
        public IPyStatement Statement { get; set; }
    }
}