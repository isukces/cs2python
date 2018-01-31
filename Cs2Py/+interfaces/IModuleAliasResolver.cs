using Cs2Py.Source;
using JetBrains.Annotations;

namespace Cs2Py
{
    public interface IModuleAliasResolver
    {
        /// <summary>
        ///  Gets module alias for importing i.e. 'np' for 'numpy' 
        /// </summary>
        /// <param name="moduleName">module name</param>
        /// <returns>module alias</returns>
        [CanBeNull]
        string FindModuleAlias(PyCodeModuleName moduleName);
    }
}