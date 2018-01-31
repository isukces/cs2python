using System;
using Cs2Py.Emit;
using Cs2Py.Helpers;
using Cs2Py.Source;

namespace Cs2Py.Translator
{
    public class ExpressionEvaluator
    {
        public static PyConstValue Evaluate(IPyValue v)
        {
            try
            {
                if (v is PyConstValue co)
                    return co;
                if (v is PyBinaryOperatorExpression bo)
                {
                    var left  = Evaluate(bo.Left).Value;
                    var right = Evaluate(bo.Right).Value;

                    switch (bo.Operator)
                    {
                        case "+":
                            return new PyConstValue(ValueHelper.Add(left, right));
                        case "-":
                            return new PyConstValue(ValueHelper.Sub(left, right));
                        case "*":
                            return new PyConstValue(ValueHelper.Mul(left, right));
                        case "/":
                            return new PyConstValue(ValueHelper.Div(left, right));
                    }
                }
            }
            catch (Exception e)
            {
                throw new NotSupportedException("unable to get static value from " + v.GetPyCode(new PyEmitStyle()), e);
            }

            throw new NotSupportedException("unable to get static value from " + v.GetPyCode(new PyEmitStyle()));
        }


        private static object Sum(object left, object right, int mn)
        {
            if (left is int leftInt)
                switch (right)
                {
                    case int r1:
                        return leftInt + mn * r1;
                    case long r2:
                        return leftInt + mn * r2;
                    case short r3:
                        return leftInt + mn * r3;
                    case sbyte r4:
                        return leftInt + mn * r4;

                    case uint ur1:
                        return leftInt + mn * ur1;
                    case ulong ur2:
                        return 0;
                    case ushort ur3:
                        return leftInt + mn * ur3;
                    case byte ur4:
                        return leftInt + mn * ur4;
                }
            throw new NotSupportedException();
        }
    }
}