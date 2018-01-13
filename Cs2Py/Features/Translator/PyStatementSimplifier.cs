using System;
using Cs2Py.CodeVisitors;
using Cs2Py.Source;
using Lang.Python;

namespace Cs2Py.Translator
{
    public class PyStatementSimplifier : PyBaseVisitor<IPyStatement>, IPySimplifier
    {
        public PyStatementSimplifier(OptimizeOptions op)
        {
            this.op = op;
        }

        // Protected Methods 

        private static PyMethodCallExpression GetPyNativeMethodCall(IPyStatement statement, string name)
        {
            var expressionStatement = statement as PyExpressionStatement;
            if (expressionStatement == null) return null;

            var methodCall = expressionStatement.Expression as PyMethodCallExpression;
            if (methodCall == null) return null;
            if (methodCall.Name == name && methodCall.CallType == MethodCallStyles.Procedural)
                return methodCall;
            return null;
        }

        public IPyStatement Simplify(IPyStatement x)
        {
            if (x == null)
                return null;
            if (!(x is PySourceBase))
                throw new Exception(x.GetType().FullName);
            return Visit(x as PySourceBase);
        }

        public IPyValue Simplify(IPyValue x)
        {
            var a = new ExpressionSimplifier(op);
            return a.Visit(x as PySourceBase);
        }

        protected override IPyStatement VisitPyBreakStatement(PyBreakStatement node)
        {
            return node;
        }

        protected override IPyStatement VisitPyCodeBlock(PyCodeBlock node)
        {
            var newNode = new PyCodeBlock();
            foreach (var i in node.GetPlain()) newNode.Statements.Add(Simplify(i));

            if (op.JoinEchoStatements)
            {
                for (var i = 1; i < newNode.Statements.Count; i++)
                {
                    var e1 = GetPyNativeMethodCall(newNode.Statements[i - 1], "echo");
                    if (e1 == null) continue;
                    var e2 = GetPyNativeMethodCall(newNode.Statements[i], "echo");
                    if (e2 == null) continue;

                    Func<IPyValue, IPyValue> AddBracketsIfNecessary = ee =>
                    {
                        if (ee is PyParenthesizedExpression || ee is PyConstValue ||
                            ee is PyPropertyAccessExpression)
                            return ee;

                        if (ee is PyBinaryOperatorExpression && ((PyBinaryOperatorExpression)ee).Operator == ".")
                            return ee;
                        return new PyParenthesizedExpression(ee);
                    };

                    var a1 = AddBracketsIfNecessary(e1.Arguments[0].Expression);
                    var a2 = AddBracketsIfNecessary(e2.Arguments[0].Expression);

                    IPyValue e               = new PyBinaryOperatorExpression(".", a1, a2);
                    e                         = Simplify(e);
                    IPyValue echo            = new PyMethodCallExpression("echo", e);
                    newNode.Statements[i - 1] = new PyExpressionStatement(echo);
                    newNode.Statements.RemoveAt(i);
                    i--;
                }

                for (var i = 0; i < newNode.Statements.Count; i++)
                {
                    var a = newNode.Statements[i];
                    if (a is PySourceBase)
                        newNode.Statements[i] = Visit(a as PySourceBase);
                }
            }

            return PySourceBase.EqualCode_List(node.Statements, newNode.Statements) ? node : newNode;
        }

        protected override IPyStatement VisitPyContinueStatement(PyContinueStatement node)
        {
            return node.Simplify(this);
        }


        protected override IPyStatement VisitPyExpressionStatement(PyExpressionStatement node)
        {
            var newExpression = Simplify(node.Expression);
            return newExpression == node.Expression ? node : new PyExpressionStatement(newExpression);
        }

        protected override IPyStatement VisitPyForEachStatement(PyForEachStatement node)
        {
            return node.Simplify(this);
        }

        protected override IPyStatement VisitPyForStatement(PyForStatement node)
        {
            return node.Simplify(this);
        }

        protected override IPyStatement VisitPyIfStatement(PyIfStatement node)
        {
            return node.Simplify(this);
        }

        protected override IPyStatement VisitPyReturnStatement(PyReturnStatement node)
        {
            return node.Simplify(this);
        }

        protected override IPyStatement VisitPySwitchStatement(PySwitchStatement node)
        {
            return node.Simplify(this);
        }
        // Private Methods 

        protected override IPyStatement VisitPyWhileStatement(PyWhileStatement node)
        {
            return node.Simplify(this);
        }

        private readonly OptimizeOptions op;
    }
}