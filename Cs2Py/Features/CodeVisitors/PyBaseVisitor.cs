using System;
using Cs2Py.Source;

namespace Cs2Py.CodeVisitors
{
    public class PyBaseVisitor<T>
    {
	    // public LangParseContext context = new LangParseContext();
        public bool ThrowNotImplementedException = true;

        public virtual T Visit(PySourceBase node)
        {
			if (node == null)
				return VisitNull();
            switch (node.Kind)
            {
                case PySourceItems.PyArrayAccessExpression:
                    return VisitPyArrayAccessExpression(node as PyArrayAccessExpression);
                case PySourceItems.PyArrayCreateExpression:
                    return VisitPyArrayCreateExpression(node as PyArrayCreateExpression);
                case PySourceItems.PyAssignExpression:
                    return VisitPyAssignExpression(node as PyAssignExpression);
                case PySourceItems.PyAssignVariableStatement:
                    return VisitPyAssignVariableStatement(node as PyAssignVariableStatement);
                case PySourceItems.PyBinaryOperatorExpression:
                    return VisitPyBinaryOperatorExpression(node as PyBinaryOperatorExpression);
                case PySourceItems.PyBreakStatement:
                    return VisitPyBreakStatement(node as PyBreakStatement);
                case PySourceItems.PyClassFieldAccessExpression:
                    return VisitPyClassFieldAccessExpression(node as PyClassFieldAccessExpression);
                case PySourceItems.PyCodeBlock:
                    return VisitPyCodeBlock(node as PyCodeBlock);
                case PySourceItems.PyConditionalExpression:
                    return VisitPyConditionalExpression(node as PyConditionalExpression);
                case PySourceItems.PyConstValue:
                    return VisitPyConstValue(node as PyConstValue);
                case PySourceItems.PyContinueStatement:
                    return VisitPyContinueStatement(node as PyContinueStatement);
                case PySourceItems.PyDefinedConstExpression:
                    return VisitPyDefinedConstExpression(node as PyDefinedConstExpression);
                case PySourceItems.PyDictionaryCreateExpression:
                    return VisitPyDictionaryCreateExpression(node as PyDictionaryCreateExpression);
                case PySourceItems.PyElementAccessExpression:
                    return VisitPyElementAccessExpression(node as PyElementAccessExpression);
                case PySourceItems.PyExpressionStatement:
                    return VisitPyExpressionStatement(node as PyExpressionStatement);
                case PySourceItems.PyForEachStatement:
                    return VisitPyForEachStatement(node as PyForEachStatement);
                case PySourceItems.PyForStatement:
                    return VisitPyForStatement(node as PyForStatement);
                case PySourceItems.PyIfStatement:
                    return VisitPyIfStatement(node as PyIfStatement);
                case PySourceItems.PyIncrementDecrementExpression:
                    return VisitPyIncrementDecrementExpression(node as PyIncrementDecrementExpression);
                case PySourceItems.PyInstanceFieldAccessExpression:
                    return VisitPyInstanceFieldAccessExpression(node as PyInstanceFieldAccessExpression);
                case PySourceItems.PyMethodCallExpression:
                    return VisitPyMethodCallExpression(node as PyMethodCallExpression);
                case PySourceItems.PyMethodInvokeValue:
                    return VisitPyMethodInvokeValue(node as PyMethodInvokeValue);
                case PySourceItems.PyModuleExpression:
                    return VisitPyModuleExpression(node as PyModuleExpression);
                case PySourceItems.PyParenthesizedExpression:
                    return VisitPyParenthesizedExpression(node as PyParenthesizedExpression);
                case PySourceItems.PyPropertyAccessExpression:
                    return VisitPyPropertyAccessExpression(node as PyPropertyAccessExpression);
                case PySourceItems.PyReturnStatement:
                    return VisitPyReturnStatement(node as PyReturnStatement);
                case PySourceItems.PySwitchStatement:
                    return VisitPySwitchStatement(node as PySwitchStatement);
                case PySourceItems.PyThisExpression:
                    return VisitPyThisExpression(node as PyThisExpression);
                case PySourceItems.PyUnaryOperatorExpression:
                    return VisitPyUnaryOperatorExpression(node as PyUnaryOperatorExpression);
                case PySourceItems.PyUsingStatement:
                    return VisitPyUsingStatement(node as PyUsingStatement);
                case PySourceItems.PyVariableExpression:
                    return VisitPyVariableExpression(node as PyVariableExpression);
                case PySourceItems.PyWhileStatement:
                    return VisitPyWhileStatement(node as PyWhileStatement);
                default: throw new NotSupportedException(node.Kind.ToString() + "," + node.GetType().Name);
            }
        }

		protected virtual T VisitNull()
        {
            if (ThrowNotImplementedException)
                throw new NotImplementedException(string.Format("Method {0} is not supported", "VisitNull"));
            return default(T);
        }

            
        protected virtual T VisitPyArrayAccessExpression(PyArrayAccessExpression node)
        {
            if (ThrowNotImplementedException)
                throw new NotImplementedException(string.Format("Method {0} is not supported in class {1}", "VisitPyArrayAccessExpression", this.GetType().FullName));
            return default(T);
        }

        protected virtual T VisitPyArrayCreateExpression(PyArrayCreateExpression node)
        {
            if (ThrowNotImplementedException)
                throw new NotImplementedException(string.Format("Method {0} is not supported in class {1}", "VisitPyArrayCreateExpression", this.GetType().FullName));
            return default(T);
        }

        protected virtual T VisitPyAssignExpression(PyAssignExpression node)
        {
            if (ThrowNotImplementedException)
                throw new NotImplementedException(string.Format("Method {0} is not supported in class {1}", "VisitPyAssignExpression", this.GetType().FullName));
            return default(T);
        }

        protected virtual T VisitPyAssignVariableStatement(PyAssignVariableStatement node)
        {
            if (ThrowNotImplementedException)
                throw new NotImplementedException(string.Format("Method {0} is not supported in class {1}", "VisitPyAssignVariableStatement", this.GetType().FullName));
            return default(T);
        }

        protected virtual T VisitPyBinaryOperatorExpression(PyBinaryOperatorExpression node)
        {
            if (ThrowNotImplementedException)
                throw new NotImplementedException(string.Format("Method {0} is not supported in class {1}", "VisitPyBinaryOperatorExpression", this.GetType().FullName));
            return default(T);
        }

        protected virtual T VisitPyBreakStatement(PyBreakStatement node)
        {
            if (ThrowNotImplementedException)
                throw new NotImplementedException(string.Format("Method {0} is not supported in class {1}", "VisitPyBreakStatement", this.GetType().FullName));
            return default(T);
        }

        protected virtual T VisitPyClassFieldAccessExpression(PyClassFieldAccessExpression node)
        {
            if (ThrowNotImplementedException)
                throw new NotImplementedException(string.Format("Method {0} is not supported in class {1}", "VisitPyClassFieldAccessExpression", this.GetType().FullName));
            return default(T);
        }

        protected virtual T VisitPyCodeBlock(PyCodeBlock node)
        {
            if (ThrowNotImplementedException)
                throw new NotImplementedException(string.Format("Method {0} is not supported in class {1}", "VisitPyCodeBlock", this.GetType().FullName));
            return default(T);
        }

        protected virtual T VisitPyConditionalExpression(PyConditionalExpression node)
        {
            if (ThrowNotImplementedException)
                throw new NotImplementedException(string.Format("Method {0} is not supported in class {1}", "VisitPyConditionalExpression", this.GetType().FullName));
            return default(T);
        }

        protected virtual T VisitPyConstValue(PyConstValue node)
        {
            if (ThrowNotImplementedException)
                throw new NotImplementedException(string.Format("Method {0} is not supported in class {1}", "VisitPyConstValue", this.GetType().FullName));
            return default(T);
        }

        protected virtual T VisitPyContinueStatement(PyContinueStatement node)
        {
            if (ThrowNotImplementedException)
                throw new NotImplementedException(string.Format("Method {0} is not supported in class {1}", "VisitPyContinueStatement", this.GetType().FullName));
            return default(T);
        }

        protected virtual T VisitPyDefinedConstExpression(PyDefinedConstExpression node)
        {
            if (ThrowNotImplementedException)
                throw new NotImplementedException(string.Format("Method {0} is not supported in class {1}", "VisitPyDefinedConstExpression", this.GetType().FullName));
            return default(T);
        }

        protected virtual T VisitPyDictionaryCreateExpression(PyDictionaryCreateExpression node)
        {
            if (ThrowNotImplementedException)
                throw new NotImplementedException(string.Format("Method {0} is not supported in class {1}", "VisitPyDictionaryCreateExpression", this.GetType().FullName));
            return default(T);
        }

        protected virtual T VisitPyElementAccessExpression(PyElementAccessExpression node)
        {
            if (ThrowNotImplementedException)
                throw new NotImplementedException(string.Format("Method {0} is not supported in class {1}", "VisitPyElementAccessExpression", this.GetType().FullName));
            return default(T);
        }

        protected virtual T VisitPyExpressionStatement(PyExpressionStatement node)
        {
            if (ThrowNotImplementedException)
                throw new NotImplementedException(string.Format("Method {0} is not supported in class {1}", "VisitPyExpressionStatement", this.GetType().FullName));
            return default(T);
        }

        protected virtual T VisitPyForEachStatement(PyForEachStatement node)
        {
            if (ThrowNotImplementedException)
                throw new NotImplementedException(string.Format("Method {0} is not supported in class {1}", "VisitPyForEachStatement", this.GetType().FullName));
            return default(T);
        }

        protected virtual T VisitPyForStatement(PyForStatement node)
        {
            if (ThrowNotImplementedException)
                throw new NotImplementedException(string.Format("Method {0} is not supported in class {1}", "VisitPyForStatement", this.GetType().FullName));
            return default(T);
        }

        protected virtual T VisitPyIfStatement(PyIfStatement node)
        {
            if (ThrowNotImplementedException)
                throw new NotImplementedException(string.Format("Method {0} is not supported in class {1}", "VisitPyIfStatement", this.GetType().FullName));
            return default(T);
        }

        protected virtual T VisitPyIncrementDecrementExpression(PyIncrementDecrementExpression node)
        {
            if (ThrowNotImplementedException)
                throw new NotImplementedException(string.Format("Method {0} is not supported in class {1}", "VisitPyIncrementDecrementExpression", this.GetType().FullName));
            return default(T);
        }

        protected virtual T VisitPyInstanceFieldAccessExpression(PyInstanceFieldAccessExpression node)
        {
            if (ThrowNotImplementedException)
                throw new NotImplementedException(string.Format("Method {0} is not supported in class {1}", "VisitPyInstanceFieldAccessExpression", this.GetType().FullName));
            return default(T);
        }

        protected virtual T VisitPyMethodCallExpression(PyMethodCallExpression node)
        {
            if (ThrowNotImplementedException)
                throw new NotImplementedException(string.Format("Method {0} is not supported in class {1}", "VisitPyMethodCallExpression", this.GetType().FullName));
            return default(T);
        }

        protected virtual T VisitPyMethodInvokeValue(PyMethodInvokeValue node)
        {
            if (ThrowNotImplementedException)
                throw new NotImplementedException(string.Format("Method {0} is not supported in class {1}", "VisitPyMethodInvokeValue", this.GetType().FullName));
            return default(T);
        }

        protected virtual T VisitPyModuleExpression(PyModuleExpression node)
        {
            if (ThrowNotImplementedException)
                throw new NotImplementedException(string.Format("Method {0} is not supported in class {1}", "VisitPyModuleExpression", this.GetType().FullName));
            return default(T);
        }

        protected virtual T VisitPyParenthesizedExpression(PyParenthesizedExpression node)
        {
            if (ThrowNotImplementedException)
                throw new NotImplementedException(string.Format("Method {0} is not supported in class {1}", "VisitPyParenthesizedExpression", this.GetType().FullName));
            return default(T);
        }

        protected virtual T VisitPyPropertyAccessExpression(PyPropertyAccessExpression node)
        {
            if (ThrowNotImplementedException)
                throw new NotImplementedException(string.Format("Method {0} is not supported in class {1}", "VisitPyPropertyAccessExpression", this.GetType().FullName));
            return default(T);
        }

        protected virtual T VisitPyReturnStatement(PyReturnStatement node)
        {
            if (ThrowNotImplementedException)
                throw new NotImplementedException(string.Format("Method {0} is not supported in class {1}", "VisitPyReturnStatement", this.GetType().FullName));
            return default(T);
        }

        protected virtual T VisitPySwitchStatement(PySwitchStatement node)
        {
            if (ThrowNotImplementedException)
                throw new NotImplementedException(string.Format("Method {0} is not supported in class {1}", "VisitPySwitchStatement", this.GetType().FullName));
            return default(T);
        }

        protected virtual T VisitPyThisExpression(PyThisExpression node)
        {
            if (ThrowNotImplementedException)
                throw new NotImplementedException(string.Format("Method {0} is not supported in class {1}", "VisitPyThisExpression", this.GetType().FullName));
            return default(T);
        }

        protected virtual T VisitPyUnaryOperatorExpression(PyUnaryOperatorExpression node)
        {
            if (ThrowNotImplementedException)
                throw new NotImplementedException(string.Format("Method {0} is not supported in class {1}", "VisitPyUnaryOperatorExpression", this.GetType().FullName));
            return default(T);
        }

        protected virtual T VisitPyUsingStatement(PyUsingStatement node)
        {
            if (ThrowNotImplementedException)
                throw new NotImplementedException(string.Format("Method {0} is not supported in class {1}", "VisitPyUsingStatement", this.GetType().FullName));
            return default(T);
        }

        protected virtual T VisitPyVariableExpression(PyVariableExpression node)
        {
            if (ThrowNotImplementedException)
                throw new NotImplementedException(string.Format("Method {0} is not supported in class {1}", "VisitPyVariableExpression", this.GetType().FullName));
            return default(T);
        }

        protected virtual T VisitPyWhileStatement(PyWhileStatement node)
        {
            if (ThrowNotImplementedException)
                throw new NotImplementedException(string.Format("Method {0} is not supported in class {1}", "VisitPyWhileStatement", this.GetType().FullName));
            return default(T);
        }
		public static PySourceItems GetKind(PySourceBase x) {
			if (x == null) throw new ArgumentNullException();           
			if (x.GetType() == typeof(PyArrayAccessExpression)) return PySourceItems.PyArrayAccessExpression;
			if (x.GetType() == typeof(PyArrayCreateExpression)) return PySourceItems.PyArrayCreateExpression;
			if (x.GetType() == typeof(PyAssignExpression)) return PySourceItems.PyAssignExpression;
			if (x.GetType() == typeof(PyAssignVariableStatement)) return PySourceItems.PyAssignVariableStatement;
			if (x.GetType() == typeof(PyBinaryOperatorExpression)) return PySourceItems.PyBinaryOperatorExpression;
			if (x.GetType() == typeof(PyBreakStatement)) return PySourceItems.PyBreakStatement;
			if (x.GetType() == typeof(PyClassFieldAccessExpression)) return PySourceItems.PyClassFieldAccessExpression;
			if (x.GetType() == typeof(PyCodeBlock)) return PySourceItems.PyCodeBlock;
			if (x.GetType() == typeof(PyConditionalExpression)) return PySourceItems.PyConditionalExpression;
			if (x.GetType() == typeof(PyConstValue)) return PySourceItems.PyConstValue;
			if (x.GetType() == typeof(PyContinueStatement)) return PySourceItems.PyContinueStatement;
			if (x.GetType() == typeof(PyDefinedConstExpression)) return PySourceItems.PyDefinedConstExpression;
			if (x.GetType() == typeof(PyDictionaryCreateExpression)) return PySourceItems.PyDictionaryCreateExpression;
			if (x.GetType() == typeof(PyElementAccessExpression)) return PySourceItems.PyElementAccessExpression;
			if (x.GetType() == typeof(PyExpressionStatement)) return PySourceItems.PyExpressionStatement;
			if (x.GetType() == typeof(PyForEachStatement)) return PySourceItems.PyForEachStatement;
			if (x.GetType() == typeof(PyForStatement)) return PySourceItems.PyForStatement;
			if (x.GetType() == typeof(PyIfStatement)) return PySourceItems.PyIfStatement;
			if (x.GetType() == typeof(PyIncrementDecrementExpression)) return PySourceItems.PyIncrementDecrementExpression;
			if (x.GetType() == typeof(PyInstanceFieldAccessExpression)) return PySourceItems.PyInstanceFieldAccessExpression;
			if (x.GetType() == typeof(PyMethodCallExpression)) return PySourceItems.PyMethodCallExpression;
			if (x.GetType() == typeof(PyMethodInvokeValue)) return PySourceItems.PyMethodInvokeValue;
			if (x.GetType() == typeof(PyModuleExpression)) return PySourceItems.PyModuleExpression;
			if (x.GetType() == typeof(PyParenthesizedExpression)) return PySourceItems.PyParenthesizedExpression;
			if (x.GetType() == typeof(PyPropertyAccessExpression)) return PySourceItems.PyPropertyAccessExpression;
			if (x.GetType() == typeof(PyReturnStatement)) return PySourceItems.PyReturnStatement;
			if (x.GetType() == typeof(PySwitchStatement)) return PySourceItems.PySwitchStatement;
			if (x.GetType() == typeof(PyThisExpression)) return PySourceItems.PyThisExpression;
			if (x.GetType() == typeof(PyUnaryOperatorExpression)) return PySourceItems.PyUnaryOperatorExpression;
			if (x.GetType() == typeof(PyUsingStatement)) return PySourceItems.PyUsingStatement;
			if (x.GetType() == typeof(PyVariableExpression)) return PySourceItems.PyVariableExpression;
			if (x.GetType() == typeof(PyWhileStatement)) return PySourceItems.PyWhileStatement;
            throw new NotSupportedException(x.GetType().FullName);
		}
    }
	public enum PySourceItems
	{
		PyArrayAccessExpression,
		PyArrayCreateExpression,
		PyAssignExpression,
		PyAssignVariableStatement,
		PyBinaryOperatorExpression,
		PyBreakStatement,
		PyClassFieldAccessExpression,
		PyCodeBlock,
		PyConditionalExpression,
		PyConstValue,
		PyContinueStatement,
		PyDefinedConstExpression,
		PyDictionaryCreateExpression,
		PyElementAccessExpression,
		PyExpressionStatement,
		PyForEachStatement,
		PyForStatement,
		PyIfStatement,
		PyIncrementDecrementExpression,
		PyInstanceFieldAccessExpression,
		PyMethodCallExpression,
		PyMethodInvokeValue,
		PyModuleExpression,
		PyParenthesizedExpression,
		PyPropertyAccessExpression,
		PyReturnStatement,
		PySwitchStatement,
		PyThisExpression,
		PyUnaryOperatorExpression,
		PyUsingStatement,
		PyVariableExpression,
		PyWhileStatement,
	}
}
