using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Cs2Py.Emit;
using Lang.Python;

namespace Cs2Py.Source
{
    public class PyConstValue : PyValueBase
    {
        /// <summary>
        ///     Tworzy instancję obiektu
        ///     <param name="value"></param>
        /// </summary>
        public PyConstValue(object value)
        {
            Value = value;           
        }

        /// <summary>
        ///     Tworzy instancję obiektu
        ///     <param name="value"></param>
        ///     <param name="useGlue"></param>
        /// </summary>
        public PyConstValue(object value, bool useGlue)
        {
            Value   = value;
            UseGlue = useGlue;
        }
        // Public Methods 

        public static PyConstValue FromPyValue(string code)
        {
            var m = Regex.Match(code, "^(-?\\d)+$");
            if (m.Success)
            {
                var value = int.Parse(code);
                return new PyConstValue(value);
            }

            throw new NotImplementedException("Only integer values are supported. Sorry.");
        }


        private static string EscapeSingleQuote(string x)
        {
            return "'" + x.Replace("\\", "\\\\").Replace("'", "\\'") + "'";
        }

        // Public Methods 

        public override IEnumerable<ICodeRequest> GetCodeRequests()
        {
            return new ICodeRequest[0];
        }

        public override string GetPyCode(PyEmitStyle style)
        {
            var b = style != null && style.Compression != EmitStyleCompression.Beauty;
            PyCodeValue a = PyValues.ToPyCodeValue(Value, b);
            switch (a.Kind)
            {
                case PyCodeValue.Kinds.Null:
                    return "None";
                default:
                    return a.PyValue;
            }
        }


        /// <summary>
        /// </summary>
        public object Value { get; set; }

        /// <summary>
        /// </summary>
        public bool UseGlue { get; set; }
    }
}