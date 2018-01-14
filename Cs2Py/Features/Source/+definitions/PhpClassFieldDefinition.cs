using System;
using System.Collections.Generic;
using Cs2Py.CSharp;
using Cs2Py.Emit;

namespace Cs2Py.Source
{
    public class PyClassFieldDefinition : IClassMember, ICodeRelated
    {
        // Public Methods 


        public void Emit(PySourceCodeEmiter emiter, PySourceCodeWriter writer, PyEmitStyle style)
        {
            /*
            if (IsConst)
            {
                //  const CONSTANT = 'constant value';
                writer.WriteLnF("const {0} = {1};", Name, ConstValue.GetPyCode(style));
                return;
            }
            */


            if (ConstValue != null)
            {
                if (!IsStatic)
                    throw new Exception(
                        "Only static fields with initialization are allowed. Move instance field initialization to constructior.");
                writer.WriteLn(Name + " = " + ConstValue.GetPyCode(style));
            }

            /*

            var a = string.Format("{0}{1} ${2}",
                Visibility.ToString().ToLower(),
                IsStatic ? " static" : "",
                Name
            );
            if (ConstValue != null)
                a += " = " + ConstValue.GetPyCode(style);
            writer.WriteLn(a + ";");
            */
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