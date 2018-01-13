using System.Collections.Generic;
using Cs2Py.Compilation;
using Cs2Py.Emit;

namespace Cs2Py.Source
{
    public class PyClassFieldAccessExpression : PyValueBase
    {
        public override IEnumerable<ICodeRequest> GetCodeRequests()
        {
            if (_className.EmitName != PyQualifiedName.ClassnameSelf)
                yield return new ClassCodeRequest(_className);
        }

        public override string GetPyCode(PyEmitStyle style)
        {
            return string.Format("{0}::{1}{2}",
                _className.NameForEmit(style),
                IsConst ? "" : "$",
                _fieldName);
        }

        public void SetClassName(PyQualifiedName PyClassName, ClassTranslationInfo classTi)
        {
            _className = PyClassName;
            ClassTi    = classTi;
        }

        /// <summary>
        ///     Własność jest tylko do odczytu.
        /// </summary>
        public PyQualifiedName ClassName => _className;

        private PyQualifiedName _className;

        /// <summary>
        /// </summary>
        public string FieldName
        {
            get => _fieldName;
            set
            {
                value                               = (value ?? string.Empty).Trim();
                while (value.StartsWith("$")) value = value.Substring(1);
                _fieldName                          = value;
            }
        }

        private string _fieldName = string.Empty;

        /// <summary>
        /// </summary>
        public bool IsConst { get; set; }

        /// <summary>
        ///     Własność jest tylko do odczytu.
        /// </summary>
        public ClassTranslationInfo ClassTi { get; private set; }
    }
}