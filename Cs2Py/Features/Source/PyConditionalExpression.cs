using System.Collections.Generic;
using System.Diagnostics;
using Cs2Py.Emit;

namespace Cs2Py.Source
{
    public class PyConditionalExpression : PyValueBase
    {
        /// <summary>
        ///     Tworzy instancję obiektu
        ///     <param name="condition"></param>
        ///     <param name="whenTrue"></param>
        ///     <param name="whenFalse"></param>
        /// </summary>
        public PyConditionalExpression(IPyValue condition, IPyValue whenTrue, IPyValue whenFalse)
        {
            Condition = condition;
            WhenTrue  = whenTrue;
            WhenFalse = whenFalse;
        }

        public override IEnumerable<ICodeRequest> GetCodeRequests()
        {
            return PyStatementBase.GetCodeRequests(Condition, WhenTrue, WhenFalse);
        }

        public override string GetPyCode(PyEmitStyle style)
        {
            var form = style == null || style.Compression == EmitStyleCompression.Beauty
                ? "{0} ? {1} : {2}"
                : "{0}?{1}:{2}";
            return string.Format(form, Condition.GetPyCode(style), WhenTrue.GetPyCode(style),
                WhenFalse.GetPyCode(style));
        }

        public override IPyValue Simplify(IPyExpressionSimplifier s)
        {
            Debug.Assert(Condition != null, "Condition != null");
            var condition = SimplifyForFieldAcces(Condition, s);
            var whenTrue  = SimplifyForFieldAcces(WhenTrue,  s);
            var whenFalse = SimplifyForFieldAcces(WhenFalse, s);
            var newNode   = new PyConditionalExpression(condition, whenTrue, whenFalse);
            return EqualCode(this, newNode) ? this : newNode;
        }

        /// <summary>
        /// </summary>
        public IPyValue Condition { get; set; }

        /// <summary>
        /// </summary>
        public IPyValue WhenTrue { get; set; }

        /// <summary>
        /// </summary>
        public IPyValue WhenFalse { get; set; }
    }
}