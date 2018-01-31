using System;

namespace Lang.Python
{
    [AttributeUsage(AttributeTargets.Assembly, AllowMultiple = true)]
    public class ImportModuleAsAttribute:Attribute
    {
        public ImportModuleAsAttribute(string moduleName, string alias)
        {
            ModuleName = moduleName;
            Alias      = alias;
        }

        public string ModuleName { get; }
        public string Alias      { get; }
    }
}