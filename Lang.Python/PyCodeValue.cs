using System;
using System.Globalization;

namespace Lang.Python
{
    public  class PyCodeValue
    {
        // Public Methods 

        public static PyCodeValue FromBool(bool v)
        {
            var txt = v ? "true" : "false";
            return new PyCodeValue(txt, v, Kinds.Bool);
        }

        public static PyCodeValue FromDouble(double v)
        {
            var txt = v.ToString(CultureInfo.InvariantCulture);
            return new PyCodeValue(txt, v, Kinds.Double);
        }

        public static PyCodeValue FromInt(int v, bool octal = false)
        {
            var txt = octal ? PyValues.Dec2Oct(v) : v.ToString();
            return new PyCodeValue(txt, v, octal ? Kinds.OctalInt : Kinds.Int);
        }

        public static PyCodeValue FromString(string txt)
        {
            return new PyCodeValue(PyValues.PyStringEmit(txt, true), txt, Kinds.StringConstant);
        }

        // Public Methods 

        public bool TryGetPyString(out string txt)
        {
            switch (Kind)
            {
                case Kinds.StringConstant:
                    if (PyValues.TryGetPyStringValue(_PyValue, out txt))
                        return true;
                    throw new NotSupportedException();
                case Kinds.Bool:
                    txt = (bool)SourceValue ? "1" : "";
                    return true;
                case Kinds.Int:
                case Kinds.OctalInt:
                    txt = ((int)SourceValue).ToString();
                    return true;
                case Kinds.Double:
                    txt = _PyValue;
                    return true;
                case Kinds.DefinedConst:
                    txt = "";
                    return false;
                case Kinds.Null:
                    txt = "";
                    return true;
                default:
                    throw new NotSupportedException();

            }
        }

        public enum Kinds
        {
            Other, // ie. flags
            StringConstant,
            Int,
            OctalInt,
            DefinedConst,
            Bool,
            Double,
            Null
        }
   
      
        /// <summary>
        /// Tworzy instancję obiektu
        /// <param name="PyValue">Value on Py side</param>
        /// <param name="kind"></param>
        /// </summary>
        public PyCodeValue(string PyValue, Kinds kind)
        {
            PyValue = PyValue;
            Kind     = kind;
        }

        /// <summary>
        /// Tworzy instancję obiektu
        /// <param name="PyValue">Value on Py side</param>
        /// <param name="sourceValue"></param>
        /// <param name="kind"></param>
        /// </summary>
        public PyCodeValue(string PyValue, object sourceValue, Kinds kind)
        {
            PyValue    = PyValue;
            SourceValue = sourceValue;
            Kind        = kind;
        }

     

        /// <summary>
        /// Zwraca tekstową reprezentację obiektu
        /// </summary>
        /// <returns>Tekstowa reprezentacja obiektu</returns>
        public override string ToString()
        {
            return string.Format("{0}", _PyValue);
        }

        /// <summary>
        /// Value on Py side
        /// </summary>
        public string PyValue
        {
            get => _PyValue;
            set => _PyValue = (value ?? String.Empty).Trim();
        }
        private string _PyValue = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public object SourceValue { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Kinds Kind { get; set; }
    }
}