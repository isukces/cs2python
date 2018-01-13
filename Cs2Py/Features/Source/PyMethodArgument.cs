using Cs2Py.Emit;

namespace Cs2Py.Source
{
    public class PyMethodArgument
    {
        // Public Methods 

        public string GetPyCode(PyEmitStyle s)
        {
            s      = s ?? new PyEmitStyle();
            var eq = s.Compression == EmitStyleCompression.Beauty ? " = " : "=";
            var d  = DefaultValue != null ? eq + DefaultValue.GetPyCode(s) : "";
            return string.Format("${0}{1}", _name, d);
        }

        public override string ToString()
        {
            return GetPyCode(null);
        }


        /// <summary>
        ///     Nazwa argumentu
        /// </summary>
        public string Name
        {
            get => _name;
            set => _name = (value ?? string.Empty).Trim();
        }

        /// <summary>
        /// </summary>
        public IPyValue DefaultValue { get; set; }

        private string _name = string.Empty;
    }
}