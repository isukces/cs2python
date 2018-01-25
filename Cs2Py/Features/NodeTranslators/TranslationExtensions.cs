using System;
using System.Reflection;
using Cs2Py.Source;
using Lang.Python;

namespace Cs2Py.NodeTranslators
{
    public static class TranslationExtensions
    {
        public static PyMethodCallExpression TrySetTargetObjectFromModule(this PyMethodCallExpression self, Type methodInfoDeclaringType)
        {
            var ar = methodInfoDeclaringType?.GetCustomAttribute<PyModuleAttribute>();
            if (ar != null)
                self.TargetObject = new PyModuleExpression(PyCodeModuleName.FromAttribute(ar), "?");
            return self;
        }
    }
}