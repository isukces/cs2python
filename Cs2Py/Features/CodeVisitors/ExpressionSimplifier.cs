using System;
using System.Linq;
using System.Web;
using Cs2Py.Source;
using Lang.Python;

namespace Cs2Py.CodeVisitors
{
    public class ExpressionSimplifier : PyBaseVisitor<IPyValue>, IPyExpressionSimplifier
    {
        public ExpressionSimplifier(OptimizeOptions op)
        {
            this.op = op;
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

            return new[] {x};
        }

        private static IPyValue ReturnSubst(IPyValue old, IPyValue @new)
        {
            if (SameCode(old, @new))
                return old;
            return @new;
        }

        private static bool SameCode(IPyValue a, IPyValue b)
        {
            var codeA = a == null ? "" : a.GetPyCode(null);
            var codeB = a == null ? "" : b.GetPyCode(null);
            return codeA == codeB;
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

        protected override IPyValue VisitPyBinaryOperatorExpression(PyBinaryOperatorExpression node)
        {           
            return node;
        }

        protected override IPyValue VisitPyClassFieldAccessExpression(PyClassFieldAccessExpression node)
        {
            return node;
        }

        protected override IPyValue VisitPyConditionalExpression(PyConditionalExpression node)
        {
            return node.Simplify(this);
        }

        protected override IPyValue VisitPyConstValue(PyConstValue node)
        {
            return node;
        }

        protected override IPyValue VisitPyDefinedConstExpression(PyDefinedConstExpression node)
        {
            return node;
        }

        protected override IPyValue VisitPyDictionaryCreateExpression(PyDictionaryCreateExpression node)
        {
            return node;
        }

        protected override IPyValue VisitPyElementAccessExpression(PyElementAccessExpression node)
        {
            return node.Simplify(this);
        }

        protected override IPyValue VisitPyIncrementDecrementExpression(PyIncrementDecrementExpression node)
        {
            return node.Simplify(this);
        }


        protected override IPyValue VisitPyInstanceFieldAccessExpression(PyInstanceFieldAccessExpression node)
        {
            return node;
        }

        protected override IPyValue VisitPyMethodCallExpression(PyMethodCallExpression node)
        {
            if (node.Name == "_urlencode_" || node.Name == "_htmlspecialchars_")
                if (node.Arguments[0].Expression is PyConstValue)
                {
                    var cv = (node.Arguments[0].Expression as PyConstValue).Value;
                    if (cv == null)
                        return Simplify(node.Arguments[0].Expression);
                    if (cv is int)
                        cv = cv.ToString();
                    else if (cv is string)
                        if (node.Name == "_urlencode_")
                            cv = HttpUtility.UrlEncode(cv as string);
                        else
                            cv = HttpUtility.HtmlEncode(cv as string);
                    else
                        throw new NotSupportedException();
                    return Simplify(new PyConstValue(cv));
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

        protected override IPyValue VisitPyMethodInvokeValue(PyMethodInvokeValue node)
        {
            var nv = strip(node.Expression);

            if (PySourceBase.EqualCode(nv, node.Expression))
                return node;
            return new PyMethodInvokeValue(nv) {ByRef = node.ByRef};
        }

        protected override IPyValue VisitPyModuleExpression(PyModuleExpression node)
        {
            return node;
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

        protected override IPyValue VisitPyPropertyAccessExpression(PyPropertyAccessExpression node)
        {
            return node.Simplify(this);
        }

        protected override IPyValue VisitPyThisExpression(PyThisExpression node)
        {
            return node;
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

        protected override IPyValue VisitPyVariableExpression(PyVariableExpression node)
        {
            return node;
        }


        private IPyValue strip(IPyValue v)
        {
            while (v is PyParenthesizedExpression)
                v = (v as PyParenthesizedExpression).Expression;
            v     = Simplify(v);
            return v;
        }

        private OptimizeOptions op;
    }
}