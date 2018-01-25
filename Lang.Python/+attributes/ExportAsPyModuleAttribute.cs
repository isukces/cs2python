using System;

namespace Lang.Python
{
    [AttributeUsage(AttributeTargets.Class)]
    public class ExportAsPyModuleAttribute : Attribute
    {
    }
}