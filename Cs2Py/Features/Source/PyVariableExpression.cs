using System.Collections.Generic;
using Cs2Py.Emit;

namespace Cs2Py.Source
{
    public class PyVariableExpression : PyValueBase
    {
        /// <summary>
        ///     Tworzy instancję obiektu
        ///     <param name="variableName"></param>
        ///     <param name="kind"></param>
        /// </summary>
        public PyVariableExpression(string variableName, PyVariableKind kind)
        {
            VariableName = variableName;
            Kind         = kind;
        }
        // Public Methods 

       
        public static PyVariableExpression MakeGlobal(string name)
        {
            return new PyVariableExpression(name, PyVariableKind.Global);
        }

        public static PyVariableExpression MakeLocal(string name, bool isFunctionArgument)
        {
            return new PyVariableExpression(name,
                isFunctionArgument ? PyVariableKind.LocalArgument : PyVariableKind.Local);
        }

        // Public Methods 

        public override IEnumerable<ICodeRequest> GetCodeRequests()
        {
            if (Kind == PyVariableKind.Global)
            {
                yield return new GlobalVariableRequest(_variableName);
            }
            else
            {
                var a = new LocalVariableRequest(_variableName,
                    Kind == PyVariableKind.LocalArgument,
                    newName => { VariableName = newName; });
                yield return a;
            }
        }

        public override string GetPyCode(PyEmitStyle style)
        {
            return _variableName;
        }


        /// <summary>
        /// </summary>
        public string VariableName
        {
            get => _variableName;
            set => _variableName = (value ?? string.Empty).Trim();
        }

        /// <summary>
        /// </summary>
        public PyVariableKind Kind { get; set; }

        private string _variableName = string.Empty;
    }
}