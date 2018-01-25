using System;
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
            var argumentsCode   = Arguments.Select(u => u.GetPyCode(style)).ToList();
            var mk              = GetPyMethodKind();
            switch (mk)
            {
                case PyMethodKind.ClassStatic:
                    code.WriteLn("@staticmethod");
                    argumentsCode.Insert(0, "cls");
                    break;
                case PyMethodKind.OutOfClass:
                    break;
                case PyMethodKind.ClassInstance:
                    argumentsCode.Insert(0, "self");
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            var param = Arguments == null ? "" : string.Join(", ", argumentsCode);
            code.OpenLnF("def {0}({1}):", Name, param);
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

            code.CloseLn("");
        }

        public IEnumerable<ICodeRequest> GetCodeRequests()
        {
            var a = PyStatementBase.GetCodeRequests(Arguments);
            var b = PyStatementBase.GetCodeRequests(Statements);
            return a.Union(b);
        }
        // Protected Methods 


        protected string GetGlobals()
        {
            var aa = GetCodeRequests()
                .OfType<GlobalVariableRequest>()
                .Where(i => !string.IsNullOrEmpty(i.VariableName))
                .Select(i => i.VariableName).Distinct();
            var globals = string.Join(", ", aa);
            return globals;
        }

        protected virtual PyMethodKind GetPyMethodKind()
        {
            return PyMethodKind.OutOfClass;
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

    public enum PyMethodKind
    {
        OutOfClass,
        ClassInstance,
        ClassStatic
    }
}