using Cs2Py.Source;

namespace Cs2Py.NodeTranlators
{
    public static class PyModules
    {
        public static PyCodeModuleName Math
        {
            get
            {
                var moduleName = new PyCodeModuleName("math", true);
                return moduleName;
            }
        }
    }
}