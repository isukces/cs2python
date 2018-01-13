using System.Collections.Generic;
using System.Linq;
using Cs2Py.Emit;

namespace Cs2Py.Source
{
    public abstract class PyStatementBase : PySourceBase, IPyStatement
    {
        #region Static Methods

        // Public Methods 

        public static IEnumerable<ICodeRequest> GetCodeRequests(params object[] x)
        {
            return GetCodeRequests<object>(x);
        }

        public static IEnumerable<ICodeRequest> GetCodeRequests<T>(IEnumerable<T> x)
        {
            if (x == null)
                return new ICodeRequest[0];
            var requests = from codeRelated in x.OfType<ICodeRelated>()
                where codeRelated != null
                let append = codeRelated.GetCodeRequests()
                where append != null
                select append;
            IEnumerable<ICodeRequest> result = new ICodeRequest[0];
            return requests.Aggregate(result, (current, request) => current.Concat(request));
        }

        #endregion Static Methods

        #region Methods

        // Public Methods 

        public abstract void Emit(PySourceCodeEmiter emiter, PySourceCodeWriter writer, PyEmitStyle style);

        public abstract IEnumerable<ICodeRequest> GetCodeRequests();

        public virtual StatementEmitInfo GetStatementEmitInfo(PyEmitStyle style)
        {
            return StatementEmitInfo.NormalSingleStatement;
        }

        public virtual IPyStatement Simplify(IPySimplifier s)
        {
            return this;
        }
        // Protected Methods 

        protected void EmitHeaderStatement(PySourceCodeEmiter emiter, PySourceCodeWriter writer, PyEmitStyle style, string header, IPyStatement statement)
        {
            style      = style ?? new PyEmitStyle();
            var iStyle = PyEmitStyle.xClone(style, ShowBracketsEnum.IfManyItems);
            if (style.UseBracketsEvenIfNotNecessary)
                iStyle.Brackets = ShowBracketsEnum.Always;

            var statementToEmit = PyCodeBlock.Reduce(statement);
            var emptyStatement  = !PyCodeBlock.HasAny(statementToEmit);


            if (emptyStatement)
                header += "{}";
            if (style.Compression == EmitStyleCompression.NearCrypto)
                writer.Write(header);
            else
                writer.WriteLn(header);
            if (emptyStatement) return;


            var myBracket = style.UseBracketsEvenIfNotNecessary;
            if (!myBracket)
            {
                var gf = statementToEmit.GetStatementEmitInfo(iStyle);
                if (gf != StatementEmitInfo.NormalSingleStatement)
                    myBracket = true;
            }
            writer.IncIndent();
            if (myBracket)
            {
                iStyle.Brackets = ShowBracketsEnum.Never;
                writer.OpenLn("{");
            }


            statementToEmit.Emit(emiter, writer, iStyle);
            if (myBracket)
                writer.CloseLn("}");

            writer.DecIndent();

        }

        #endregion Methods
    }
}