using System;

namespace Lang.Python
{
    [AttributeUsage(AttributeTargets.All)]
    public class ModuleAttribute : Attribute
    {
        /// <summary>
        ///     Tworzy instancję obiektu
        ///     <param name="moduleShortName">Module short name i.e "hello-page" or "mynamespace/hello-class"</param>
        /// </summary>
        public ModuleAttribute(string moduleShortName, bool isExternal)
        {
            ModuleShortName = moduleShortName;
            IsExternal      = isExternal;
        }

        /// <summary>
        ///     Module short name i.e "hello-page" or "mynamespace/hello-class"; własność jest tylko do odczytu.
        /// </summary>
        public string ModuleShortName { get; }

        public bool IsExternal { get; }
    }
}