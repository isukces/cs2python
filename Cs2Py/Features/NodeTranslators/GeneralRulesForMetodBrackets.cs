using Cs2Py.Source;

namespace Cs2Py.NodeTranslators
{
    class GeneralRulesForMetodBrackets
    {
        public static bool Bla(PyMethodCallExpression q)
        {
            if (q.Arguments.Count != 1) 
                return false; // many arguments
            var firstArg = q.Arguments[0];
            if (!string.IsNullOrEmpty(firstArg.Name)) 
                return false; // named argument
            var expression = firstArg.Expression;
            if (expression is PyMethodCallExpression)
                return true;
            if (expression is PyArrayAccessExpression)
                return true;
            if (expression is PyVariableExpression)
                return true;            
            if (expression is PyClassFieldAccessExpression)
                return false;
            
            return false;
        }
    }
}