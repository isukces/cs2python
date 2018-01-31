using System;
using System.Collections.Generic;
using Cs2Py.CSharp;
using Cs2Py.Emit;
using JetBrains.Annotations;

namespace Cs2Py.Source
{
    public class PyClassFieldDefinition : IClassMember, ICodeRelated
    {
        private readonly Type _valueType;

        public PyClassFieldDefinition(string name, [NotNull] Type valueType)
        {
            _valueType = valueType ?? throw new ArgumentNullException(nameof(valueType));
            Name = name;
        }

        private static void ScanForDangerousCode(IPyValue v)
        {
            void Danger()
            {
                throw new InvalidFieldInitializationValueException(v);
            }

            switch (v)
            {
                case null:
                    return;
                case PyConstValue _:
                    return;
                case PyBinaryOperatorExpression b:
                    ScanForDangerousCode(b.Left);
                    ScanForDangerousCode(b.Right);
                    return;
                case PyClassFieldAccessExpression c:
                    Danger();
                    return;
                default: throw new NotSupportedException(v.GetType().ToString());
            }
        }
        // Public Methods 


        public void Emit(PySourceCodeEmiter emiter, PySourceCodeWriter writer, PyEmitStyle style)
        {
            var c = ConstValue;
            if (IsStatic && c == null)
                c = PyConstValue.DefaultForType(_valueType);
            if (c == null) return;
            if (!IsStatic)
                throw new Exception(
                    "Only static fields with initialization are allowed. Move instance field initialization to constructior.");
            ScanForDangerousCode(ConstValue);
            writer.WriteLn(Name + " = " + c.GetPyCode(style));
        }

        public IEnumerable<ICodeRequest> GetCodeRequests()
        {
            return PyStatementBase.GetCodeRequests(ConstValue);
        }


        /// <summary>
        ///     nazwa pola lub stałej
        /// </summary>
        public string Name
        {
            get => _name;
            set => _name = (value ?? string.Empty).Trim();
        }

        /// <summary>
        /// </summary>
        public bool IsStatic { get; set; }

        /// <summary>
        /// </summary>
        public bool IsConst { get; set; }

        /// <summary>
        /// </summary>
        public IPyValue ConstValue { get; set; }

        /// <summary>
        /// </summary>
        public Visibility Visibility { get; set; } = Visibility.Public;

        private string _name = string.Empty;
    }
}