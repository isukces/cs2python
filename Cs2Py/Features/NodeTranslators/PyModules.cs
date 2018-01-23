using Cs2Py.Source;

namespace Cs2Py.NodeTranslators
{
    public static class PyModules
    {
        public static PyCodeModuleName Math
        {
            get
            {
                var moduleName = new PyCodeModuleName("math", "math", true);
                return moduleName;
            }
        }
    }
}