using System;
using System.Collections.Generic;
using System.Linq;
using Cs2Py.CSharp;
using Cs2Py.Helpers;
using Cs2Py.Source;

namespace Cs2Py.Translator
{
    public class ForTranslator
    {
        public ForTranslator(IStatementTranslator translator)
        {
            _translator = translator;
        }

        public static IPyValue FindIncrement(PyVariableExpression controlVariable, IPyStatement statement)
        {
            if (statement is PyExpressionStatement expressionStatement)
                return FindIncrement(controlVariable, expressionStatement.Expression);
            return null;
        }

        public static IPyValue FindIncrement(PyVariableExpression controlVariable, IPyValue expression)
        {
            switch (expression)
            {
                case PyIncrementDecrementExpression incDecExpression:
                    if (incDecExpression.Operand is PyVariableExpression opv)
                        if (controlVariable.Equals(opv))
                            return new PyConstValue(incDecExpression.Increment ? 1 : -1);
                    break;
                case PyAssignExpression assignExpression:
                    if (!controlVariable.Equals(assignExpression.Left))
                        return null;
                    switch (assignExpression.OptionalOperator)
                    {
                        case "+": return assignExpression.Right;
                        case "-": return Minus(assignExpression.Right);
                        case "":
                        {
                            if (assignExpression.Right is PyBinaryOperatorExpression b)
                            {
                                var isMinus = b.Operator == "-";
                                if (b.Operator == "+" || isMinus)
                                {
                                    if (controlVariable.Equals(b.Left))
                                        return isMinus ? Minus(b.Right) : b.Right;
                                    if (controlVariable.Equals(b.Right))
                                    {
                                        if (!isMinus) return b.Left;
                                    }
                                }
                            }
                        }
                            break;                                
                    }
                    break;                 
            }

            return null;
        }

        private static bool IsConstZero(IPyValue expression)
        {
            return expression is PyConstValue constValue
                   && (ValueHelper.EqualsNumericZero(constValue.Value) ?? false);
        }

        private static IPyValue Minus(IPyValue v)
        {
            switch (v)
            {
                case PyConstValue c:
                    var minus = ValueHelper.Minus(c.Value);
                    if (minus != null)
                        return new PyConstValue(minus);
                    break;
            }

            return new PyUnaryOperatorExpression(v, "-");
        }

        private static string OpositeOperator(string o)
        {
            switch (o)
            {
                case "<":  return ">";
                case "<=": return ">=";
                case ">":  return "<";
                case ">=": return "<=";
                case "==": return "!=";
                case "!=": return "==";
            }

            return null;
        }

        private static PyBinaryOperatorExpression VariableOnLeft(PyBinaryOperatorExpression e, string name)
        {
            if (e.Left is PyVariableExpression veL)
                if (veL.VariableName == name)
                    return e;
            if (e.Right is PyVariableExpression veR)
                if (veR.VariableName == name)
                {
                    var oposite = OpositeOperator(e.Operator);
                    if (oposite == null)
                        return e;
                    return new PyBinaryOperatorExpression(oposite, e.Right, e.Left);
                }

            return e;
        }

        public IPyStatement[] Translate(ForStatement src)
        {
            var condition      = _translator.TransValue(src.Condition);
            var statement      = _translator.TranslateStatementOne(src.Statement);
            var incrementors   = _translator.TranslateStatements(src.Incrementors);
            var declarations   = _translator.TranslateStatement(src.Declaration).ToArray();
            var pyDeclarations = new List<PyAssignExpression>();
            foreach (object declaration in declarations)
            {
                var d = declaration;
                if (declaration is PyExpressionStatement)
                    d = (declaration as PyExpressionStatement).Expression;
                if (d is PyAssignExpression)
                    pyDeclarations.Add(d as PyAssignExpression);
                else
                    throw new NotSupportedException();
            }

            var pyDeclarationsA = pyDeclarations.ToArray();
            var candidate       = TrySimpleForLoop(pyDeclarationsA, incrementors, condition, statement);
            if (candidate != null)
                return candidate;

            throw new NotImplementedException();
            // var result = new PyForStatement(pyDeclarationsA, condition, statement, incrementors);
            // return MakeArray(result);
        }

        /// <summary>
        ///     try to resolve simple case like for(int i=0; i<10; i++)
        /// </summary>
        private IPyStatement[] TrySimpleForLoop(
            PyAssignExpression[] pyDeclarations,
            IPyStatement[]       incrementors,
            IPyValue             condition,
            IPyStatement         statement)
        {
            if (pyDeclarations.Length != 1 || incrementors.Length != 1)
                return null;
            var dec = pyDeclarations[0];
            if (!(dec.Left is PyVariableExpression controlVariable))
                return null;
            if (!(condition is PyBinaryOperatorExpression binCondition)) return null;
            binCondition = VariableOnLeft(binCondition, controlVariable.VariableName);

            var loopIncrement = FindIncrement(controlVariable, incrementors[0]);
            if (loopIncrement == null)
                return null;

            var loopStart = pyDeclarations[0].Right;

            // var isLessOrEqual = binCondition.Operator == "<=";
            if (binCondition.Operator == "<")
                if (loopIncrement is PyConstValue constLoopIncrement)
                {
                    var range = new PyMethodCallExpression("range");
                    if (ValueHelper.IsGreaterThanZero(constLoopIncrement.Value) ?? false)
                    {
                        var isOneIncrement = ValueHelper.EqualsNumericOne(constLoopIncrement.Value) ?? false;
                        if (!IsConstZero(loopStart) || !isOneIncrement)
                            range.Arguments.Add(new PyMethodInvokeValue(loopStart));
                        range.Arguments.Add(new PyMethodInvokeValue(binCondition.Right));
                        if (!isOneIncrement)
                            range.Arguments.Add(
                                new PyMethodInvokeValue(new PyConstValue(constLoopIncrement.Value)));
                        var foreachStatement = new PyForEachStatement(controlVariable.VariableName, range, statement);
                        return new IPyStatement[] {foreachStatement};
                    }
                }

            var result = new PyForStatement(pyDeclarations.ToArray(), condition, statement, incrementors);
            return new IPyStatement[] {result};
        }

        private readonly IStatementTranslator _translator;
    }
}