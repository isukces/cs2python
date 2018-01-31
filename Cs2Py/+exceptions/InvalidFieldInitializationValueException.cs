using System;

namespace Cs2Py
{
    public class InvalidFieldInitializationValueException : Exception
    {
        public InvalidFieldInitializationValueException(IPyValue value)
            : base(GetMessage(value))
        {
            Value = value;
        }

        private static string GetMessage(IPyValue value)
        {
            var code = value?.GetPyCode(null);
            return $"Unable to use value {code} for field initialization";
        }

        public IPyValue Value { get; }
    }
}