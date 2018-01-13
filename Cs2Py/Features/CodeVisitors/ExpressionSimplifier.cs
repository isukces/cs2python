using System;
using System.Linq;
using System.Web;
using Cs2Py.Source;
using Lang.Python;

namespace Cs2Py.CodeVisitors
{
    public class ExpressionSimplifier : PyBaseVisitor<IPyValue>, IPyExpressionSimplifier
    {
        protected override IPyValue VisitPyIncrementDecrementExpression(PyIncrementDecrementExpression node)
        {
            return node.Simplify(this);
        }
        public ExpressionSimplifier(OptimizeOptions op)
        {
            this.op = op;
        }
        OptimizeOptions op;

        // Protected Methods 

        protected override IPyValue VisitPyArrayAccessExpression(PyArrayAccessExpression node)
        {
            return node;
        }

        protected override IPyValue VisitPyArrayCreateExpression(PyArrayCreateExpression node)
        {
            return node;
        }

        protected override IPyValue VisitPyAssignExpression(PyAssignExpression node)
        {
            return node.Simplify(this);
        }

        public static IPyValue[] ExplodeConcats(IPyValue x, string op)
        {
            if (x is PyMethodInvokeValue)
                x = (x as PyMethodInvokeValue).Expression;
            if (x is PyBinaryOperatorExpression)
            {
                var y = x as PyBinaryOperatorExpression;
                if (y.Operator == op)
                    return ExplodeConcats(y.Left, op).Union(ExplodeConcats(y.Right, op)).ToArray();
            }
            return new IPyValue[] { x };
        }

        static bool SameCode(IPyValue a, IPyValue b)
        {
            var codeA = a == null ? "" : a.GetPyCode(null);
            var codeB = a == null ? "" : b.GetPyCode(null);
            return codeA == codeB;
        }

        static IPyValue ReturnSubst(IPyValue old, IPyValue @new)
        {
            if (SameCode(old, @new))
                return old;
            return @new;
        }



        protected override IPyValue VisitPyBinaryOperatorExpression(PyBinaryOperatorExpression node)
        {
            switch (node.Operator)
            {
                case ".":
                {
                    var _left  = Simplify(node.Left);
                    var _right = Simplify(node.Right);
                    var n      = new PyBinaryOperatorExpression(node.Operator, _left, _right);
                    var c      = ExplodeConcats(n, ".").ToList();



                    for (var i = 1; i < c.Count; i++)
                    {
                        var L = c[i - 1];
                        var R = c[i];
                        if (L is PyConstValue && R is PyConstValue)
                        {
                            var LValue = (L as PyConstValue).Value;
                            var RValue = (R as PyConstValue).Value;
                            if (LValue is string && RValue is string)
                            {
                                c[i - 1] = new PyConstValue((string)LValue + (string)RValue);
                                c.RemoveAt(i);
                                i--;
                                continue;
                            }
                            var    LCode = PyValues.ToPyCodeValue(LValue);
                            var    RCode = PyValues.ToPyCodeValue(RValue);
                            string left, right;
                            if (LCode.TryGetPyString(out left) && RCode.TryGetPyString(out right))
                            {
                                c[i - 1] = new PyConstValue(left + right);
                                c.RemoveAt(i);
                                i--;
                                continue;
                            }

                            var msg = string.Format("left={0}, right={1} '{2}+{3}'", LValue, RValue, LValue == null ? null : LValue.GetType().FullName, RValue == null ? null : RValue.GetType().FullName);

#if DEBUG
                            throw new NotImplementedException(msg);
#else
                        Console.WriteLine(msg);
                        Console.WriteLine(L.GetPyCode(null));
                        Console.WriteLine(R.GetPyCode(null));
                        continue;
#endif
                        }
                    }
                    var result = c[0];
                    if (c.Count > 1)
                        foreach (var x2 in c.Skip(1))
                            result = new PyBinaryOperatorExpression(".", result, x2);
                    return ReturnSubst(node, result);
                }
                case "|":
                {
                    //                    var aLeft = node.Left as PyConstValue;
                    //                    var aRight = node.Right as PyConstValue;
                    //                    if (aLeft != null && aRight != null && aLeft.Value!=null && aRight.Value!=null)
                    //                    {
                    //                        var typeLeft = aLeft.Value.GetType();
                    //                        var typeRight = aRight.Value.GetType();
                    //                        if (typeLeft.IsEnum && typeLeft == typeRight)
                    //                        {
                    //                            var leftValue = (int)aLeft.Value;
                    //                            var rightValue = (int)aRight.Value;
                    //                            var c = leftValue | rightValue;
                    //                            var dd = PyCodeValue.FromInt(c, true);
                    //                            var d = new PyConstValue(c, false);
                    //                            return d;
                    //                        }
                    //                    }
                }
                    break;
            }
            return node;
        }

        protected override IPyValue VisitPyClassFieldAccessExpression(PyClassFieldAccessExpression node)
        {
            return node;
        }

        protected override IPyValue VisitPyConstValue(PyConstValue node)
        {
            return node;
        }

        protected override IPyValue VisitPyDefinedConstExpression(PyDefinedConstExpression node)
        {
            return node;
        }

        
        protected override IPyValue VisitPyInstanceFieldAccessExpression(PyInstanceFieldAccessExpression node)
        {
            return node;
        }

        protected override IPyValue VisitPyMethodCallExpression(PyMethodCallExpression node)
        {
            if (node.Name == "_urlencode_" || node.Name == "_htmlspecialchars_")
            {
                if (node.Arguments[0].Expression is PyConstValue)
                {
                    var cv = (node.Arguments[0].Expression as PyConstValue).Value;
                    if (cv == null)
                        return Simplify(node.Arguments[0].Expression);
                    if (cv is int)
                        cv = cv.ToString();
                    else if (cv is string)
                    {
                        if (node.Name == "_urlencode_")
                            cv = HttpUtility.UrlEncode(cv as string);
                        else
                            cv = HttpUtility.HtmlEncode(cv as string);
                    }
                    else
                        throw new NotSupportedException();
                    return Simplify(new PyConstValue(cv));
                }
            }
            {
                var list1 = node.Arguments.Select(Simplify).Cast<PyMethodInvokeValue>().ToList();
                var to    = node.TargetObject == null ? null : Simplify(node.TargetObject);
                if (PySourceBase.EqualCode_List(list1, node.Arguments) && PySourceBase.EqualCode(to, node.TargetObject))
                    return node;
                var xx = new PyMethodCallExpression(node.Name)
                {
                    Arguments        = list1,
                    DontIncludeClass = node.DontIncludeClass,
                    TargetObject     = to
                };
                xx.SetClassName(node.ClassName, node.TranslationInfo);
                return xx;
            }
            return node;
        }


        IPyValue strip(IPyValue v)
        {
            while (v is PyParenthesizedExpression)
                v = (v as PyParenthesizedExpression).Expression;
            v     = Simplify(v);
            return v;
        }
        protected override IPyValue VisitPyMethodInvokeValue(PyMethodInvokeValue node)
        {
            var nv = strip(node.Expression);

            if (PySourceBase.EqualCode(nv, node.Expression))
                return node;
            return new PyMethodInvokeValue(nv) { ByRef = node.ByRef };
        }

        protected override IPyValue VisitPyUnaryOperatorExpression(PyUnaryOperatorExpression node)
        {
            if (node.Operator == "!" && node.Operand is PyBinaryOperatorExpression)
            {
                var bin = node.Operand as PyBinaryOperatorExpression;
                if (bin.Operator == "!==")
                {
                    var bin2 = new PyBinaryOperatorExpression("===", bin.Left, bin.Right);
                    return bin2;
                }
                var be = new PyParenthesizedExpression(node.Operand);
                node   = new PyUnaryOperatorExpression(be, node.Operator);
                return node;
            }
            if (node.Operator == "!" && node.Operand is PyUnaryOperatorExpression)
            {
                var bin = node.Operand as PyUnaryOperatorExpression;
                if (bin.Operator == "!")
                    return Simplify(bin.Operand);
            }
            return node;
        }
        protected override IPyValue VisitPyElementAccessExpression(PyElementAccessExpression node)
        {
            return node.Simplify(this);
        }
        protected override IPyValue VisitPyConditionalExpression(PyConditionalExpression node)
        {
            return node.Simplify(this);

        }

        protected override IPyValue VisitPyParenthesizedExpression(PyParenthesizedExpression node)
        {
            // zdejmowanie wielokrotnych nawiasów
            if (node.Expression is PyParenthesizedExpression)
                return node.Expression;
            if (node.Expression is PyMethodCallExpression)
            {
                var t = node.Expression as PyMethodCallExpression;
                if (!t.IsConstructorCall)
                    return node.Expression;
            }
            return node;
        }
        protected override IPyValue VisitPyVariableExpression(PyVariableExpression node)
        {
            return node;
        }
        // Private Methods 

        public IPyValue Simplify(IPyValue src)
        {
            if (src == null)
                return null;
            if (src is PySourceBase)
                return Visit(src as PySourceBase);
            return src;
        }

        protected override IPyValue VisitPyPropertyAccessExpression(PyPropertyAccessExpression node)
        {
            return node.Simplify(this);
        }
    }
}