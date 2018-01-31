using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;
using Cs2Py.CSharp;
using Cs2Py.Emit;

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

        public static IPyValue DefaultForType(LangType type)
        {
            return DefaultForType(type.DotnetType);
        }

        public static IPyValue DefaultForType(Type type)
        {
            if (type == typeof(double)) return new PyConstValue(default(double));
            if (type == typeof(float)) return new PyConstValue(default(float));
            if (type == typeof(decimal)) return new PyConstValue(default(decimal));
            if (type == typeof(int)) return new PyConstValue(default(int));
            if (type == typeof(long)) return new PyConstValue(default(long));
            if (type == typeof(short)) return new PyConstValue(default(short));
            if (type == typeof(sbyte)) return new PyConstValue(default(sbyte));
            if (type == typeof(byte)) return new PyConstValue(default(byte));
            if (type == typeof(ushort)) return new PyConstValue(default(ushort));
            if (type == typeof(uint)) return new PyConstValue(default(uint));
            if (type == typeof(ulong)) return new PyConstValue(default(ulong));
            if (type == typeof(string)) return new PyConstValue(default(string));
            throw new NotImplementedException(type.ToString());
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

        private static string FixDecimal(string x)
        {
            if (x.Contains(".")) return x;
            if (x.Contains("e"))
                return "float(" + x + ")";
            return x + ".";
        }

        // Public Methods 

        public override IEnumerable<ICodeRequest> GetCodeRequests()
        {
            return new ICodeRequest[0];
        }

        public override string GetPyCode(PyEmitStyle style)
        {
            var b = style != null && style.Compression != EmitStyleCompression.Beauty;

            //var a = PyValues.ToPyCodeValue(Value, b);
            switch (Value)
            {
                case null: return "None";
                case int _:
                case long _:
                case short _:
                case sbyte _:
                    var longValue = Convert.ToInt64(Value);
                    return longValue.ToString(CultureInfo.InvariantCulture);
                case uint _:
                case ulong _:
                case ushort _:
                case byte _:
                    var ulongValue = Convert.ToUInt64(Value);
                    return ulongValue.ToString(CultureInfo.InvariantCulture);
                case string stringValue:
                    return EscapeSingleQuote(stringValue);
                case bool boolValue:
                    return boolValue ? "True" : "False";
                case decimal decimalValue:
                    return FixDecimal(decimalValue.ToString(CultureInfo.InvariantCulture));
                case float floatValue:
                    return FixDecimal(floatValue.ToString(CultureInfo.InvariantCulture));
                case double doubleValue:
                    return FixDecimal(doubleValue.ToString(CultureInfo.InvariantCulture));
                default:
                {
                    var t = Value.GetType();
                    if (t.IsEnum)
                    {
                        return EscapeSingleQuote(Value.ToString()); 
                    }
                    throw new NotImplementedException(Value.GetType().ToString());
                }
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