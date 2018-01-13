using System;

namespace Lang.Python
{
    [AttributeUsage(AttributeTargets.Class)]
    public class PageAttribute : Attribute
    {
        public PageAttribute()
        {

        }
        public PageAttribute(string ModuleShortName)
        {
            this.ModuleShortName = ModuleShortName;
        }
        public string ModuleShortName { get; set; }
    }
}