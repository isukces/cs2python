using System;
using System.Collections.Generic;
using Cs2Py.Emit;

namespace Cs2Py.Source
{
    public class PyVariableExpression : PyValueBase, IEquatable<PyVariableExpression>
    {
        public bool Equals(PyVariableExpression other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return string.Equals(_variableName, other._variableName) && Kind == other.Kind;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((PyVariableExpression)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((_variableName != null ? _variableName.GetHashCode() : 0) * 397) ^ (int)Kind;
            }
        }

        public static bool operator ==(PyVariableExpression left, PyVariableExpression right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(PyVariableExpression left, PyVariableExpression right)
        {
            return !Equals(left, right);
        }

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