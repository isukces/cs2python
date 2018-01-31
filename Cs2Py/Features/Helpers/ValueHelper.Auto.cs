using System;

// ReSharper disable once CheckNamespace
namespace Cs2Py.Helpers
{
    public static class ValueHelper
    {
        public static object Add(object left, object right)
        {
            switch (left)
            {
                case int leftInt:
                    switch (right)
                    {
                        case int rightInt: return leftInt + rightInt;
                        case long rightLong: return leftInt + rightLong;
                        case short rightShort: return leftInt + rightShort;
                        case sbyte rightSbyte: return leftInt + rightSbyte;
                        case uint rightUint: return leftInt + rightUint;
                        case ushort rightUshort: return leftInt + rightUshort;
                        case byte rightByte: return leftInt + rightByte;
                        case double rightDouble: return leftInt + rightDouble;
                        case float rightFloat: return leftInt + rightFloat;
                        case decimal rightDecimal: return leftInt + rightDecimal;
                        default:
                            throw new NotSupportedException();
                    }
                case long leftLong:
                    switch (right)
                    {
                        case int rightInt: return leftLong + rightInt;
                        case long rightLong: return leftLong + rightLong;
                        case short rightShort: return leftLong + rightShort;
                        case sbyte rightSbyte: return leftLong + rightSbyte;
                        case uint rightUint: return leftLong + rightUint;
                        case ushort rightUshort: return leftLong + rightUshort;
                        case byte rightByte: return leftLong + rightByte;
                        case double rightDouble: return leftLong + rightDouble;
                        case float rightFloat: return leftLong + rightFloat;
                        case decimal rightDecimal: return leftLong + rightDecimal;
                        default:
                            throw new NotSupportedException();
                    }
                case short leftShort:
                    switch (right)
                    {
                        case int rightInt: return leftShort + rightInt;
                        case long rightLong: return leftShort + rightLong;
                        case short rightShort: return leftShort + rightShort;
                        case sbyte rightSbyte: return leftShort + rightSbyte;
                        case uint rightUint: return leftShort + rightUint;
                        case ushort rightUshort: return leftShort + rightUshort;
                        case byte rightByte: return leftShort + rightByte;
                        case double rightDouble: return leftShort + rightDouble;
                        case float rightFloat: return leftShort + rightFloat;
                        case decimal rightDecimal: return leftShort + rightDecimal;
                        default:
                            throw new NotSupportedException();
                    }
                case sbyte leftSbyte:
                    switch (right)
                    {
                        case int rightInt: return leftSbyte + rightInt;
                        case long rightLong: return leftSbyte + rightLong;
                        case short rightShort: return leftSbyte + rightShort;
                        case sbyte rightSbyte: return leftSbyte + rightSbyte;
                        case uint rightUint: return leftSbyte + rightUint;
                        case ushort rightUshort: return leftSbyte + rightUshort;
                        case byte rightByte: return leftSbyte + rightByte;
                        case double rightDouble: return leftSbyte + rightDouble;
                        case float rightFloat: return leftSbyte + rightFloat;
                        case decimal rightDecimal: return leftSbyte + rightDecimal;
                        default:
                            throw new NotSupportedException();
                    }
                case uint leftUint:
                    switch (right)
                    {
                        case int rightInt: return leftUint + rightInt;
                        case long rightLong: return leftUint + rightLong;
                        case short rightShort: return leftUint + rightShort;
                        case sbyte rightSbyte: return leftUint + rightSbyte;
                        case uint rightUint: return leftUint + rightUint;
                        case ulong rightUlong: return leftUint + rightUlong;
                        case ushort rightUshort: return leftUint + rightUshort;
                        case byte rightByte: return leftUint + rightByte;
                        case double rightDouble: return leftUint + rightDouble;
                        case float rightFloat: return leftUint + rightFloat;
                        case decimal rightDecimal: return leftUint + rightDecimal;
                        default:
                            throw new NotSupportedException();
                    }
                case ulong leftUlong:
                    switch (right)
                    {
                        case uint rightUint: return leftUlong + rightUint;
                        case ulong rightUlong: return leftUlong + rightUlong;
                        case ushort rightUshort: return leftUlong + rightUshort;
                        case byte rightByte: return leftUlong + rightByte;
                        case double rightDouble: return leftUlong + rightDouble;
                        case float rightFloat: return leftUlong + rightFloat;
                        case decimal rightDecimal: return leftUlong + rightDecimal;
                        default:
                            throw new NotSupportedException();
                    }
                case ushort leftUshort:
                    switch (right)
                    {
                        case int rightInt: return leftUshort + rightInt;
                        case long rightLong: return leftUshort + rightLong;
                        case short rightShort: return leftUshort + rightShort;
                        case sbyte rightSbyte: return leftUshort + rightSbyte;
                        case uint rightUint: return leftUshort + rightUint;
                        case ulong rightUlong: return leftUshort + rightUlong;
                        case ushort rightUshort: return leftUshort + rightUshort;
                        case byte rightByte: return leftUshort + rightByte;
                        case double rightDouble: return leftUshort + rightDouble;
                        case float rightFloat: return leftUshort + rightFloat;
                        case decimal rightDecimal: return leftUshort + rightDecimal;
                        default:
                            throw new NotSupportedException();
                    }
                case byte leftByte:
                    switch (right)
                    {
                        case int rightInt: return leftByte + rightInt;
                        case long rightLong: return leftByte + rightLong;
                        case short rightShort: return leftByte + rightShort;
                        case sbyte rightSbyte: return leftByte + rightSbyte;
                        case uint rightUint: return leftByte + rightUint;
                        case ulong rightUlong: return leftByte + rightUlong;
                        case ushort rightUshort: return leftByte + rightUshort;
                        case byte rightByte: return leftByte + rightByte;
                        case double rightDouble: return leftByte + rightDouble;
                        case float rightFloat: return leftByte + rightFloat;
                        case decimal rightDecimal: return leftByte + rightDecimal;
                        default:
                            throw new NotSupportedException();
                    }
                case double leftDouble:
                    switch (right)
                    {
                        case int rightInt: return leftDouble + rightInt;
                        case long rightLong: return leftDouble + rightLong;
                        case short rightShort: return leftDouble + rightShort;
                        case sbyte rightSbyte: return leftDouble + rightSbyte;
                        case uint rightUint: return leftDouble + rightUint;
                        case ulong rightUlong: return leftDouble + rightUlong;
                        case ushort rightUshort: return leftDouble + rightUshort;
                        case byte rightByte: return leftDouble + rightByte;
                        case double rightDouble: return leftDouble + rightDouble;
                        case float rightFloat: return leftDouble + rightFloat;
                        default:
                            throw new NotSupportedException();
                    }
                case float leftFloat:
                    switch (right)
                    {
                        case int rightInt: return leftFloat + rightInt;
                        case long rightLong: return leftFloat + rightLong;
                        case short rightShort: return leftFloat + rightShort;
                        case sbyte rightSbyte: return leftFloat + rightSbyte;
                        case uint rightUint: return leftFloat + rightUint;
                        case ulong rightUlong: return leftFloat + rightUlong;
                        case ushort rightUshort: return leftFloat + rightUshort;
                        case byte rightByte: return leftFloat + rightByte;
                        case double rightDouble: return leftFloat + rightDouble;
                        case float rightFloat: return leftFloat + rightFloat;
                        default:
                            throw new NotSupportedException();
                    }
                case decimal leftDecimal:
                    switch (right)
                    {
                        case int rightInt: return leftDecimal + rightInt;
                        case long rightLong: return leftDecimal + rightLong;
                        case short rightShort: return leftDecimal + rightShort;
                        case sbyte rightSbyte: return leftDecimal + rightSbyte;
                        case uint rightUint: return leftDecimal + rightUint;
                        case ulong rightUlong: return leftDecimal + rightUlong;
                        case ushort rightUshort: return leftDecimal + rightUshort;
                        case byte rightByte: return leftDecimal + rightByte;
                        case decimal rightDecimal: return leftDecimal + rightDecimal;
                        default:
                            throw new NotSupportedException();
                    }
                case string leftString:
                    switch (right)
                    {
                        case string rightString: return leftString + rightString;
                        default:
                            throw new NotSupportedException();
                    }
                default:
                    throw new NotSupportedException();
            }
        }

        public static object Div(object left, object right)
        {
            switch (left)
            {
                case int leftInt:
                    switch (right)
                    {
                        case int rightInt: return leftInt / rightInt;
                        case long rightLong: return leftInt / rightLong;
                        case short rightShort: return leftInt / rightShort;
                        case sbyte rightSbyte: return leftInt / rightSbyte;
                        case uint rightUint: return leftInt / rightUint;
                        case ushort rightUshort: return leftInt / rightUshort;
                        case byte rightByte: return leftInt / rightByte;
                        case double rightDouble: return leftInt / rightDouble;
                        case float rightFloat: return leftInt / rightFloat;
                        case decimal rightDecimal: return leftInt / rightDecimal;
                        default:
                            throw new NotSupportedException();
                    }
                case long leftLong:
                    switch (right)
                    {
                        case int rightInt: return leftLong / rightInt;
                        case long rightLong: return leftLong / rightLong;
                        case short rightShort: return leftLong / rightShort;
                        case sbyte rightSbyte: return leftLong / rightSbyte;
                        case uint rightUint: return leftLong / rightUint;
                        case ushort rightUshort: return leftLong / rightUshort;
                        case byte rightByte: return leftLong / rightByte;
                        case double rightDouble: return leftLong / rightDouble;
                        case float rightFloat: return leftLong / rightFloat;
                        case decimal rightDecimal: return leftLong / rightDecimal;
                        default:
                            throw new NotSupportedException();
                    }
                case short leftShort:
                    switch (right)
                    {
                        case int rightInt: return leftShort / rightInt;
                        case long rightLong: return leftShort / rightLong;
                        case short rightShort: return leftShort / rightShort;
                        case sbyte rightSbyte: return leftShort / rightSbyte;
                        case uint rightUint: return leftShort / rightUint;
                        case ushort rightUshort: return leftShort / rightUshort;
                        case byte rightByte: return leftShort / rightByte;
                        case double rightDouble: return leftShort / rightDouble;
                        case float rightFloat: return leftShort / rightFloat;
                        case decimal rightDecimal: return leftShort / rightDecimal;
                        default:
                            throw new NotSupportedException();
                    }
                case sbyte leftSbyte:
                    switch (right)
                    {
                        case int rightInt: return leftSbyte / rightInt;
                        case long rightLong: return leftSbyte / rightLong;
                        case short rightShort: return leftSbyte / rightShort;
                        case sbyte rightSbyte: return leftSbyte / rightSbyte;
                        case uint rightUint: return leftSbyte / rightUint;
                        case ushort rightUshort: return leftSbyte / rightUshort;
                        case byte rightByte: return leftSbyte / rightByte;
                        case double rightDouble: return leftSbyte / rightDouble;
                        case float rightFloat: return leftSbyte / rightFloat;
                        case decimal rightDecimal: return leftSbyte / rightDecimal;
                        default:
                            throw new NotSupportedException();
                    }
                case uint leftUint:
                    switch (right)
                    {
                        case int rightInt: return leftUint / rightInt;
                        case long rightLong: return leftUint / rightLong;
                        case short rightShort: return leftUint / rightShort;
                        case sbyte rightSbyte: return leftUint / rightSbyte;
                        case uint rightUint: return leftUint / rightUint;
                        case ulong rightUlong: return leftUint / rightUlong;
                        case ushort rightUshort: return leftUint / rightUshort;
                        case byte rightByte: return leftUint / rightByte;
                        case double rightDouble: return leftUint / rightDouble;
                        case float rightFloat: return leftUint / rightFloat;
                        case decimal rightDecimal: return leftUint / rightDecimal;
                        default:
                            throw new NotSupportedException();
                    }
                case ulong leftUlong:
                    switch (right)
                    {
                        case uint rightUint: return leftUlong / rightUint;
                        case ulong rightUlong: return leftUlong / rightUlong;
                        case ushort rightUshort: return leftUlong / rightUshort;
                        case byte rightByte: return leftUlong / rightByte;
                        case double rightDouble: return leftUlong / rightDouble;
                        case float rightFloat: return leftUlong / rightFloat;
                        case decimal rightDecimal: return leftUlong / rightDecimal;
                        default:
                            throw new NotSupportedException();
                    }
                case ushort leftUshort:
                    switch (right)
                    {
                        case int rightInt: return leftUshort / rightInt;
                        case long rightLong: return leftUshort / rightLong;
                        case short rightShort: return leftUshort / rightShort;
                        case sbyte rightSbyte: return leftUshort / rightSbyte;
                        case uint rightUint: return leftUshort / rightUint;
                        case ulong rightUlong: return leftUshort / rightUlong;
                        case ushort rightUshort: return leftUshort / rightUshort;
                        case byte rightByte: return leftUshort / rightByte;
                        case double rightDouble: return leftUshort / rightDouble;
                        case float rightFloat: return leftUshort / rightFloat;
                        case decimal rightDecimal: return leftUshort / rightDecimal;
                        default:
                            throw new NotSupportedException();
                    }
                case byte leftByte:
                    switch (right)
                    {
                        case int rightInt: return leftByte / rightInt;
                        case long rightLong: return leftByte / rightLong;
                        case short rightShort: return leftByte / rightShort;
                        case sbyte rightSbyte: return leftByte / rightSbyte;
                        case uint rightUint: return leftByte / rightUint;
                        case ulong rightUlong: return leftByte / rightUlong;
                        case ushort rightUshort: return leftByte / rightUshort;
                        case byte rightByte: return leftByte / rightByte;
                        case double rightDouble: return leftByte / rightDouble;
                        case float rightFloat: return leftByte / rightFloat;
                        case decimal rightDecimal: return leftByte / rightDecimal;
                        default:
                            throw new NotSupportedException();
                    }
                case double leftDouble:
                    switch (right)
                    {
                        case int rightInt: return leftDouble / rightInt;
                        case long rightLong: return leftDouble / rightLong;
                        case short rightShort: return leftDouble / rightShort;
                        case sbyte rightSbyte: return leftDouble / rightSbyte;
                        case uint rightUint: return leftDouble / rightUint;
                        case ulong rightUlong: return leftDouble / rightUlong;
                        case ushort rightUshort: return leftDouble / rightUshort;
                        case byte rightByte: return leftDouble / rightByte;
                        case double rightDouble: return leftDouble / rightDouble;
                        case float rightFloat: return leftDouble / rightFloat;
                        default:
                            throw new NotSupportedException();
                    }
                case float leftFloat:
                    switch (right)
                    {
                        case int rightInt: return leftFloat / rightInt;
                        case long rightLong: return leftFloat / rightLong;
                        case short rightShort: return leftFloat / rightShort;
                        case sbyte rightSbyte: return leftFloat / rightSbyte;
                        case uint rightUint: return leftFloat / rightUint;
                        case ulong rightUlong: return leftFloat / rightUlong;
                        case ushort rightUshort: return leftFloat / rightUshort;
                        case byte rightByte: return leftFloat / rightByte;
                        case double rightDouble: return leftFloat / rightDouble;
                        case float rightFloat: return leftFloat / rightFloat;
                        default:
                            throw new NotSupportedException();
                    }
                case decimal leftDecimal:
                    switch (right)
                    {
                        case int rightInt: return leftDecimal / rightInt;
                        case long rightLong: return leftDecimal / rightLong;
                        case short rightShort: return leftDecimal / rightShort;
                        case sbyte rightSbyte: return leftDecimal / rightSbyte;
                        case uint rightUint: return leftDecimal / rightUint;
                        case ulong rightUlong: return leftDecimal / rightUlong;
                        case ushort rightUshort: return leftDecimal / rightUshort;
                        case byte rightByte: return leftDecimal / rightByte;
                        case decimal rightDecimal: return leftDecimal / rightDecimal;
                        default:
                            throw new NotSupportedException();
                    }
                default:
                    throw new NotSupportedException();
            }
        }

        public static object Mul(object left, object right)
        {
            switch (left)
            {
                case int leftInt:
                    switch (right)
                    {
                        case int rightInt: return leftInt * rightInt;
                        case long rightLong: return leftInt * rightLong;
                        case short rightShort: return leftInt * rightShort;
                        case sbyte rightSbyte: return leftInt * rightSbyte;
                        case uint rightUint: return leftInt * rightUint;
                        case ushort rightUshort: return leftInt * rightUshort;
                        case byte rightByte: return leftInt * rightByte;
                        case double rightDouble: return leftInt * rightDouble;
                        case float rightFloat: return leftInt * rightFloat;
                        case decimal rightDecimal: return leftInt * rightDecimal;
                        default:
                            throw new NotSupportedException();
                    }
                case long leftLong:
                    switch (right)
                    {
                        case int rightInt: return leftLong * rightInt;
                        case long rightLong: return leftLong * rightLong;
                        case short rightShort: return leftLong * rightShort;
                        case sbyte rightSbyte: return leftLong * rightSbyte;
                        case uint rightUint: return leftLong * rightUint;
                        case ushort rightUshort: return leftLong * rightUshort;
                        case byte rightByte: return leftLong * rightByte;
                        case double rightDouble: return leftLong * rightDouble;
                        case float rightFloat: return leftLong * rightFloat;
                        case decimal rightDecimal: return leftLong * rightDecimal;
                        default:
                            throw new NotSupportedException();
                    }
                case short leftShort:
                    switch (right)
                    {
                        case int rightInt: return leftShort * rightInt;
                        case long rightLong: return leftShort * rightLong;
                        case short rightShort: return leftShort * rightShort;
                        case sbyte rightSbyte: return leftShort * rightSbyte;
                        case uint rightUint: return leftShort * rightUint;
                        case ushort rightUshort: return leftShort * rightUshort;
                        case byte rightByte: return leftShort * rightByte;
                        case double rightDouble: return leftShort * rightDouble;
                        case float rightFloat: return leftShort * rightFloat;
                        case decimal rightDecimal: return leftShort * rightDecimal;
                        default:
                            throw new NotSupportedException();
                    }
                case sbyte leftSbyte:
                    switch (right)
                    {
                        case int rightInt: return leftSbyte * rightInt;
                        case long rightLong: return leftSbyte * rightLong;
                        case short rightShort: return leftSbyte * rightShort;
                        case sbyte rightSbyte: return leftSbyte * rightSbyte;
                        case uint rightUint: return leftSbyte * rightUint;
                        case ushort rightUshort: return leftSbyte * rightUshort;
                        case byte rightByte: return leftSbyte * rightByte;
                        case double rightDouble: return leftSbyte * rightDouble;
                        case float rightFloat: return leftSbyte * rightFloat;
                        case decimal rightDecimal: return leftSbyte * rightDecimal;
                        default:
                            throw new NotSupportedException();
                    }
                case uint leftUint:
                    switch (right)
                    {
                        case int rightInt: return leftUint * rightInt;
                        case long rightLong: return leftUint * rightLong;
                        case short rightShort: return leftUint * rightShort;
                        case sbyte rightSbyte: return leftUint * rightSbyte;
                        case uint rightUint: return leftUint * rightUint;
                        case ulong rightUlong: return leftUint * rightUlong;
                        case ushort rightUshort: return leftUint * rightUshort;
                        case byte rightByte: return leftUint * rightByte;
                        case double rightDouble: return leftUint * rightDouble;
                        case float rightFloat: return leftUint * rightFloat;
                        case decimal rightDecimal: return leftUint * rightDecimal;
                        default:
                            throw new NotSupportedException();
                    }
                case ulong leftUlong:
                    switch (right)
                    {
                        case uint rightUint: return leftUlong * rightUint;
                        case ulong rightUlong: return leftUlong * rightUlong;
                        case ushort rightUshort: return leftUlong * rightUshort;
                        case byte rightByte: return leftUlong * rightByte;
                        case double rightDouble: return leftUlong * rightDouble;
                        case float rightFloat: return leftUlong * rightFloat;
                        case decimal rightDecimal: return leftUlong * rightDecimal;
                        default:
                            throw new NotSupportedException();
                    }
                case ushort leftUshort:
                    switch (right)
                    {
                        case int rightInt: return leftUshort * rightInt;
                        case long rightLong: return leftUshort * rightLong;
                        case short rightShort: return leftUshort * rightShort;
                        case sbyte rightSbyte: return leftUshort * rightSbyte;
                        case uint rightUint: return leftUshort * rightUint;
                        case ulong rightUlong: return leftUshort * rightUlong;
                        case ushort rightUshort: return leftUshort * rightUshort;
                        case byte rightByte: return leftUshort * rightByte;
                        case double rightDouble: return leftUshort * rightDouble;
                        case float rightFloat: return leftUshort * rightFloat;
                        case decimal rightDecimal: return leftUshort * rightDecimal;
                        default:
                            throw new NotSupportedException();
                    }
                case byte leftByte:
                    switch (right)
                    {
                        case int rightInt: return leftByte * rightInt;
                        case long rightLong: return leftByte * rightLong;
                        case short rightShort: return leftByte * rightShort;
                        case sbyte rightSbyte: return leftByte * rightSbyte;
                        case uint rightUint: return leftByte * rightUint;
                        case ulong rightUlong: return leftByte * rightUlong;
                        case ushort rightUshort: return leftByte * rightUshort;
                        case byte rightByte: return leftByte * rightByte;
                        case double rightDouble: return leftByte * rightDouble;
                        case float rightFloat: return leftByte * rightFloat;
                        case decimal rightDecimal: return leftByte * rightDecimal;
                        default:
                            throw new NotSupportedException();
                    }
                case double leftDouble:
                    switch (right)
                    {
                        case int rightInt: return leftDouble * rightInt;
                        case long rightLong: return leftDouble * rightLong;
                        case short rightShort: return leftDouble * rightShort;
                        case sbyte rightSbyte: return leftDouble * rightSbyte;
                        case uint rightUint: return leftDouble * rightUint;
                        case ulong rightUlong: return leftDouble * rightUlong;
                        case ushort rightUshort: return leftDouble * rightUshort;
                        case byte rightByte: return leftDouble * rightByte;
                        case double rightDouble: return leftDouble * rightDouble;
                        case float rightFloat: return leftDouble * rightFloat;
                        default:
                            throw new NotSupportedException();
                    }
                case float leftFloat:
                    switch (right)
                    {
                        case int rightInt: return leftFloat * rightInt;
                        case long rightLong: return leftFloat * rightLong;
                        case short rightShort: return leftFloat * rightShort;
                        case sbyte rightSbyte: return leftFloat * rightSbyte;
                        case uint rightUint: return leftFloat * rightUint;
                        case ulong rightUlong: return leftFloat * rightUlong;
                        case ushort rightUshort: return leftFloat * rightUshort;
                        case byte rightByte: return leftFloat * rightByte;
                        case double rightDouble: return leftFloat * rightDouble;
                        case float rightFloat: return leftFloat * rightFloat;
                        default:
                            throw new NotSupportedException();
                    }
                case decimal leftDecimal:
                    switch (right)
                    {
                        case int rightInt: return leftDecimal * rightInt;
                        case long rightLong: return leftDecimal * rightLong;
                        case short rightShort: return leftDecimal * rightShort;
                        case sbyte rightSbyte: return leftDecimal * rightSbyte;
                        case uint rightUint: return leftDecimal * rightUint;
                        case ulong rightUlong: return leftDecimal * rightUlong;
                        case ushort rightUshort: return leftDecimal * rightUshort;
                        case byte rightByte: return leftDecimal * rightByte;
                        case decimal rightDecimal: return leftDecimal * rightDecimal;
                        default:
                            throw new NotSupportedException();
                    }
                default:
                    throw new NotSupportedException();
            }
        }

        public static object Sub(object left, object right)
        {
            switch (left)
            {
                case int leftInt:
                    switch (right)
                    {
                        case int rightInt: return leftInt - rightInt;
                        case long rightLong: return leftInt - rightLong;
                        case short rightShort: return leftInt - rightShort;
                        case sbyte rightSbyte: return leftInt - rightSbyte;
                        case uint rightUint: return leftInt - rightUint;
                        case ushort rightUshort: return leftInt - rightUshort;
                        case byte rightByte: return leftInt - rightByte;
                        case double rightDouble: return leftInt - rightDouble;
                        case float rightFloat: return leftInt - rightFloat;
                        case decimal rightDecimal: return leftInt - rightDecimal;
                        default:
                            throw new NotSupportedException();
                    }
                case long leftLong:
                    switch (right)
                    {
                        case int rightInt: return leftLong - rightInt;
                        case long rightLong: return leftLong - rightLong;
                        case short rightShort: return leftLong - rightShort;
                        case sbyte rightSbyte: return leftLong - rightSbyte;
                        case uint rightUint: return leftLong - rightUint;
                        case ushort rightUshort: return leftLong - rightUshort;
                        case byte rightByte: return leftLong - rightByte;
                        case double rightDouble: return leftLong - rightDouble;
                        case float rightFloat: return leftLong - rightFloat;
                        case decimal rightDecimal: return leftLong - rightDecimal;
                        default:
                            throw new NotSupportedException();
                    }
                case short leftShort:
                    switch (right)
                    {
                        case int rightInt: return leftShort - rightInt;
                        case long rightLong: return leftShort - rightLong;
                        case short rightShort: return leftShort - rightShort;
                        case sbyte rightSbyte: return leftShort - rightSbyte;
                        case uint rightUint: return leftShort - rightUint;
                        case ushort rightUshort: return leftShort - rightUshort;
                        case byte rightByte: return leftShort - rightByte;
                        case double rightDouble: return leftShort - rightDouble;
                        case float rightFloat: return leftShort - rightFloat;
                        case decimal rightDecimal: return leftShort - rightDecimal;
                        default:
                            throw new NotSupportedException();
                    }
                case sbyte leftSbyte:
                    switch (right)
                    {
                        case int rightInt: return leftSbyte - rightInt;
                        case long rightLong: return leftSbyte - rightLong;
                        case short rightShort: return leftSbyte - rightShort;
                        case sbyte rightSbyte: return leftSbyte - rightSbyte;
                        case uint rightUint: return leftSbyte - rightUint;
                        case ushort rightUshort: return leftSbyte - rightUshort;
                        case byte rightByte: return leftSbyte - rightByte;
                        case double rightDouble: return leftSbyte - rightDouble;
                        case float rightFloat: return leftSbyte - rightFloat;
                        case decimal rightDecimal: return leftSbyte - rightDecimal;
                        default:
                            throw new NotSupportedException();
                    }
                case uint leftUint:
                    switch (right)
                    {
                        case int rightInt: return leftUint - rightInt;
                        case long rightLong: return leftUint - rightLong;
                        case short rightShort: return leftUint - rightShort;
                        case sbyte rightSbyte: return leftUint - rightSbyte;
                        case uint rightUint: return leftUint - rightUint;
                        case ulong rightUlong: return leftUint - rightUlong;
                        case ushort rightUshort: return leftUint - rightUshort;
                        case byte rightByte: return leftUint - rightByte;
                        case double rightDouble: return leftUint - rightDouble;
                        case float rightFloat: return leftUint - rightFloat;
                        case decimal rightDecimal: return leftUint - rightDecimal;
                        default:
                            throw new NotSupportedException();
                    }
                case ulong leftUlong:
                    switch (right)
                    {
                        case uint rightUint: return leftUlong - rightUint;
                        case ulong rightUlong: return leftUlong - rightUlong;
                        case ushort rightUshort: return leftUlong - rightUshort;
                        case byte rightByte: return leftUlong - rightByte;
                        case double rightDouble: return leftUlong - rightDouble;
                        case float rightFloat: return leftUlong - rightFloat;
                        case decimal rightDecimal: return leftUlong - rightDecimal;
                        default:
                            throw new NotSupportedException();
                    }
                case ushort leftUshort:
                    switch (right)
                    {
                        case int rightInt: return leftUshort - rightInt;
                        case long rightLong: return leftUshort - rightLong;
                        case short rightShort: return leftUshort - rightShort;
                        case sbyte rightSbyte: return leftUshort - rightSbyte;
                        case uint rightUint: return leftUshort - rightUint;
                        case ulong rightUlong: return leftUshort - rightUlong;
                        case ushort rightUshort: return leftUshort - rightUshort;
                        case byte rightByte: return leftUshort - rightByte;
                        case double rightDouble: return leftUshort - rightDouble;
                        case float rightFloat: return leftUshort - rightFloat;
                        case decimal rightDecimal: return leftUshort - rightDecimal;
                        default:
                            throw new NotSupportedException();
                    }
                case byte leftByte:
                    switch (right)
                    {
                        case int rightInt: return leftByte - rightInt;
                        case long rightLong: return leftByte - rightLong;
                        case short rightShort: return leftByte - rightShort;
                        case sbyte rightSbyte: return leftByte - rightSbyte;
                        case uint rightUint: return leftByte - rightUint;
                        case ulong rightUlong: return leftByte - rightUlong;
                        case ushort rightUshort: return leftByte - rightUshort;
                        case byte rightByte: return leftByte - rightByte;
                        case double rightDouble: return leftByte - rightDouble;
                        case float rightFloat: return leftByte - rightFloat;
                        case decimal rightDecimal: return leftByte - rightDecimal;
                        default:
                            throw new NotSupportedException();
                    }
                case double leftDouble:
                    switch (right)
                    {
                        case int rightInt: return leftDouble - rightInt;
                        case long rightLong: return leftDouble - rightLong;
                        case short rightShort: return leftDouble - rightShort;
                        case sbyte rightSbyte: return leftDouble - rightSbyte;
                        case uint rightUint: return leftDouble - rightUint;
                        case ulong rightUlong: return leftDouble - rightUlong;
                        case ushort rightUshort: return leftDouble - rightUshort;
                        case byte rightByte: return leftDouble - rightByte;
                        case double rightDouble: return leftDouble - rightDouble;
                        case float rightFloat: return leftDouble - rightFloat;
                        default:
                            throw new NotSupportedException();
                    }
                case float leftFloat:
                    switch (right)
                    {
                        case int rightInt: return leftFloat - rightInt;
                        case long rightLong: return leftFloat - rightLong;
                        case short rightShort: return leftFloat - rightShort;
                        case sbyte rightSbyte: return leftFloat - rightSbyte;
                        case uint rightUint: return leftFloat - rightUint;
                        case ulong rightUlong: return leftFloat - rightUlong;
                        case ushort rightUshort: return leftFloat - rightUshort;
                        case byte rightByte: return leftFloat - rightByte;
                        case double rightDouble: return leftFloat - rightDouble;
                        case float rightFloat: return leftFloat - rightFloat;
                        default:
                            throw new NotSupportedException();
                    }
                case decimal leftDecimal:
                    switch (right)
                    {
                        case int rightInt: return leftDecimal - rightInt;
                        case long rightLong: return leftDecimal - rightLong;
                        case short rightShort: return leftDecimal - rightShort;
                        case sbyte rightSbyte: return leftDecimal - rightSbyte;
                        case uint rightUint: return leftDecimal - rightUint;
                        case ulong rightUlong: return leftDecimal - rightUlong;
                        case ushort rightUshort: return leftDecimal - rightUshort;
                        case byte rightByte: return leftDecimal - rightByte;
                        case decimal rightDecimal: return leftDecimal - rightDecimal;
                        default:
                            throw new NotSupportedException();
                    }
                default:
                    throw new NotSupportedException();
            }
        }

    }
}
