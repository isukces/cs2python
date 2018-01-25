using System;

namespace Lang.Python
{
    [AttributeUsage(AttributeTargets.All)]
    public class PyModuleAttribute : Attribute
    {
        /// <summary>
        ///     Tworzy instancję obiektu
        ///     <param name="moduleShortName">Module short name i.e "hello-page" or "mynamespace/hello-class"</param>
        /// </summary>
        public PyModuleAttribute(string moduleShortName, bool isExternal)
        {
            ModuleShortName = moduleShortName;
            IsExternal      = isExternal;
        }

        /// <summary>
        ///     Module short name i.e "hello-page" or "mynamespace/hello-class"; własność jest tylko do odczytu.
        /// </summary>
        public string ModuleShortName { get; }

        public bool IsExternal { get; }
               
        public string ImportModule { get; set; }

        public string GetImportModuleName()
        {
            return string.IsNullOrEmpty(ImportModule) ? ModuleShortName : ImportModule;
        }
    }
}