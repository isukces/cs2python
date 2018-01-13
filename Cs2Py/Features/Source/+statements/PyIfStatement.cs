using System.Collections.Generic;
using Cs2Py.Emit;

namespace Cs2Py.Source
{
    public class PyIfStatement : PyStatementBase
    {
        /// <summary>
        ///     Tworzy instancję obiektu
        ///     <param name="condition"></param>
        ///     <param name="ifTrue"></param>
        ///     <param name="ifFalse"></param>
        /// </summary>
        public PyIfStatement(IPyValue condition, IPyStatement ifTrue, IPyStatement ifFalse)
        {
            Condition = condition;
            IfTrue    = ifTrue;
            IfFalse   = ifFalse;
        }
        // Public Methods 

        public override void Emit(PySourceCodeEmiter emiter, PySourceCodeWriter writer, PyEmitStyle style)
        {
            var isBeauty = style == null || style.Compression == EmitStyleCompression.Beauty;

            var ifTrueAny  = PyCodeBlock.HasAny(_ifTrue);
            var ifFalseAny = PyCodeBlock.HasAny(_ifFalse);
            if (!ifTrueAny && !ifFalseAny) return;

            writer.OpenLnF("if{1}({0}){2}",
                Condition.GetPyCode(style),
                isBeauty ? " " : "",
                ifTrueAny ? "" : "{}");
            if (ifTrueAny)
            {
                var iStyle = PyEmitStyle.xClone(style, ShowBracketsEnum.IfManyItems_OR_IfStatement);
                if (style != null && style.UseBracketsEvenIfNotNecessary)
                    iStyle.Brackets = ShowBracketsEnum.Always;
                var bound           = PyCodeBlock.Bound(_ifTrue);
                bound.Emit(emiter, writer, iStyle);
            }

            writer.DecIndent();
            if (!ifFalseAny) return;
            var oneLine   = _ifFalse is PyIfStatement;
            var oldIndent = writer.Intent;
            {
                if (oneLine)
                {
                    writer.Write("else ");
                    writer.SkipIndent = true;
                }
                else
                {
                    writer.OpenLn("else");
                }

                var myBracket = style != null && style.UseBracketsEvenIfNotNecessary;

                var iStyle = PyEmitStyle.xClone(style,
                    myBracket
                        ? ShowBracketsEnum.Never
                        : ShowBracketsEnum.IfManyItems_OR_IfStatement);

                if (!myBracket)
                {
                    var gf = _ifFalse.GetStatementEmitInfo(iStyle);
                    if (gf != StatementEmitInfo.NormalSingleStatement)
                        myBracket = true;
                }

                if (myBracket)
                {
                    iStyle.Brackets = ShowBracketsEnum.Never;
                    writer.OpenLn("{");
                }

                _ifFalse.Emit(emiter, writer, iStyle);
                if (myBracket)
                    writer.CloseLn("}");
            }
            writer.Intent = oldIndent;
        }

        public override IEnumerable<ICodeRequest> GetCodeRequests()
        {
            return GetCodeRequests(Condition, _ifTrue, _ifFalse);
        }

        public override IPyStatement Simplify(IPySimplifier s)
        {
            var newIfTrue    = s.Simplify(_ifTrue);
            var newIfFalse   = s.Simplify(_ifFalse);
            var newCondition = s.Simplify(Condition);
            if (newIfTrue == _ifTrue && newIfFalse == _ifFalse && newCondition == Condition)
                return this;
            return new PyIfStatement(newCondition, newIfTrue, newIfFalse);
        }


        /// <summary>
        /// </summary>
        public IPyValue Condition { get; set; }

        /// <summary>
        /// </summary>
        public IPyStatement IfTrue
        {
            get => _ifTrue;
            set => _ifTrue = PyCodeBlock.Reduce(value);
        }

        /// <summary>
        /// </summary>
        public IPyStatement IfFalse
        {
            get => _ifFalse;
            set
            {
                value    = PyCodeBlock.Reduce(value);
                _ifFalse = value;
            }
        }

        private IPyStatement _ifTrue;
        private IPyStatement _ifFalse;
    }
}