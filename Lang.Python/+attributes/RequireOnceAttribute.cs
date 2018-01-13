using System;

namespace Lang.Python
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class RequireOnceAttribute : Attribute
    {
        public RequireOnceAttribute(string f)
        {
            Filename = f;
        }
        public string Filename { get; private set; }
    }
}