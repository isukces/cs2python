using System.Collections.Generic;
using System.Linq;
using Cs2Py.Emit;

namespace Cs2Py.Source
{
    public class PyMethodDefinition : ICodeRelated
    {
        /// <summary>
        ///     Tworzy instancję obiektu
        ///     <param name="name">Nazwa metody</param>
        /// </summary>
        public PyMethodDefinition(string name)
        {
            Name = name;
        }
        // Public Methods 

        public virtual void Emit(PySourceCodeEmiter emiter, PySourceCodeWriter code, PyEmitStyle style)
        {
            // public function addFunction($function, $namespace = '') 
            var accessModifiers = GetAccessModifiers();
            var param           =
                Arguments == null ? "" : string.Join(", ", Arguments.Select(u => u.GetPyCode(style)));
            code.OpenLnF("{0} function {1}({2}) {{", accessModifiers, Name, param);
            {
                var g = GetGlobals();
                if (!string.IsNullOrEmpty(g))
                    code.WriteLnF("global {0};", g);
            }
            foreach (var statement in Statements)
            {
                var g      = PyEmitStyle.xClone(style);
                g.Brackets = ShowBracketsEnum.Never;
                statement.Emit(emiter, code, g);
            }

            code.CloseLn("}");
        }

        public IEnumerable<ICodeRequest> GetCodeRequests()
        {
            var a = PyStatementBase.GetCodeRequests(Arguments);
            var b = PyStatementBase.GetCodeRequests(Statements);
            return a.Union(b);
        }
        // Protected Methods 

        protected virtual string GetAccessModifiers()
        {
            return "";
        }

        protected string GetGlobals()
        {
            var aa = GetCodeRequests()
                .OfType<GlobalVariableRequest>()
                .Where(i => !string.IsNullOrEmpty(i.VariableName))
                .Select(i => PyVariableExpression.AddDollar(i.VariableName)).Distinct();
            var globals = string.Join(", ", aa);
            return globals;
        }


        /// <summary>
        ///     Nazwa metody
        /// </summary>
        public string Name
        {
            get => _name;
            set => _name = (value ?? string.Empty).Trim();
        }

        /// <summary>
        /// </summary>
        public List<PyMethodArgument> Arguments { get; set; } = new List<PyMethodArgument>();

        /// <summary>
        /// </summary>
        public List<IPyStatement> Statements { get; set; } = new List<IPyStatement>();

        /// <summary>
        ///     Własność jest tylko do odczytu.
        /// </summary>
        public bool IsAnonymous => string.IsNullOrEmpty(_name);

        private string _name = string.Empty;
    }
}