using System.Collections.Generic;
using Cs2Py.Compilation;
using Cs2Py.Emit;

namespace Cs2Py.Source
{
    public class PyNamespaceStatement : PySourceBase, IPyStatement, ICodeRelated
    {
        /// <summary>
        ///     Tworzy instancję obiektu
        ///     <param name="name">namespace name</param>
        /// </summary>
        public PyNamespaceStatement(PyNamespace name)
        {
            Name = name;
        }
        // Public Methods 

        public static bool IsRootNamespace(string name)
        {
            return string.IsNullOrEmpty(name) || name == PathUtil.WIN_SEP;
        }

        public void Emit(PySourceCodeEmiter emiter, PySourceCodeWriter writer, PyEmitStyle style)
        {
            Code.Emit(emiter, writer, style);
        }

        public IEnumerable<ICodeRequest> GetCodeRequests()
        {
            return Code.GetCodeRequests();
        }

        public StatementEmitInfo GetStatementEmitInfo(PyEmitStyle style)
        {
            return StatementEmitInfo.NormalSingleStatement;
        }

        public override string ToString()
        {
            if (Name.IsRoot)
                return "Root Py namespace";
            return string.Format("Py namespace {0}", Name);
        }

        /// <summary>
        ///     namespace name
        /// </summary>
        public PyNamespace Name { get; set; }

        /// <summary>
        /// </summary>
        public PyCodeBlock Code { get; set; } = new PyCodeBlock();
    }
}