using System;

namespace Lang.Python
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class BuiltInAttribute : Attribute
    {
    }
}