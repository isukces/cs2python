using System;
using System.Collections.Generic;
using System.Linq;
using Cs2Py.Emit;

namespace Cs2Py.Source
{
    public class PyClassDefinition : ICodeRelated, IEmitable
    {
        /// <summary>
        ///     Tworzy instancję obiektu
        ///     <param name="name">Nazwa klasy</param>
        /// </summary>
        public PyClassDefinition(PyQualifiedName name)
        {
            Name = name;
        }

        /// <summary>
        ///     Tworzy instancję obiektu
        ///     <param name="name">Nazwa klasy</param>
        ///     <param name="baseTypeName">Nazwa klasy</param>
        /// </summary>
        public PyClassDefinition(PyQualifiedName name, PyQualifiedName baseTypeName)
        {
            Name          = name;
            _baseTypeName = baseTypeName;
        }
        // Private Methods 

        private static int FieldOrderGroup(PyClassFieldDefinition fieldDefinition)
        {
            return fieldDefinition.IsConst ? 0 : (fieldDefinition.IsStatic ? 1 : 2);
        }

        // Public Methods 

        public void Emit(PySourceCodeEmiter emiter, PySourceCodeWriter writer, PyEmitStyle style)
        {
            var saveStyleCurrentClass     = style.CurrentClass;
            var saveStyleCurrentNamespace = style.CurrentNamespace;
            try
            {
                if (IsEmpty)
                    return;
                if (style.CurrentNamespace == null)
                    style.CurrentNamespace = PyNamespace.Root;
                if (style.CurrentNamespace != Name.Namespace)
                    throw new Exception("Unable to emit class into different namespace");
                var e = "";
                if (!_baseTypeName.IsEmpty)
                    e = " extends " + _baseTypeName.NameForEmit(style);
                writer.OpenLnF("class {0}{1}:", Name.ShortName, e);
                style.CurrentClass = Name; // do not move this before "class XXX" is emited
                for (var orderGroup = 0; orderGroup < 3; orderGroup++)
                    foreach (var field in Fields.Where(_ => FieldOrderGroup(_) == orderGroup))
                        field.Emit(emiter, writer, style);
                foreach (var me in Methods) me.Emit(emiter, writer, style);
                writer.CloseLn("");
            }
            finally
            {
                style.CurrentClass     = saveStyleCurrentClass;
                style.CurrentNamespace = saveStyleCurrentNamespace;
            }
        }

        public IEnumerable<ICodeRequest> GetCodeRequests()
        {
            var a = PyStatementBase.GetCodeRequests(Name, BaseTypeName);
            var b = PyStatementBase.GetCodeRequests(Fields);
            var c = PyStatementBase.GetCodeRequests(Methods);
            return a.Union(b).Union(c);
        }

        public bool IsEmpty => Methods.Count == 0 && Fields.Count == 0;

        /// <summary>
        ///     Nazwa klasy; własność jest tylko do odczytu.
        /// </summary>
        public PyQualifiedName Name { get; }

        /// <summary>
        ///     Nazwa klasy; własność jest tylko do odczytu.
        /// </summary>
        public PyQualifiedName BaseTypeName => _baseTypeName;

        /// <summary>
        /// </summary>
        public List<PyClassMethodDefinition> Methods { get; set; } = new List<PyClassMethodDefinition>();

        /// <summary>
        /// </summary>
        public List<PyClassFieldDefinition> Fields { get; set; } = new List<PyClassFieldDefinition>();

        private PyQualifiedName _baseTypeName;
    }
}