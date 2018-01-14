using System;

namespace Lang.Python
{
    [AttributeUsage(AttributeTargets.Class)]
    public class IgnoreNamespaceAttribute : Attribute
    {
    }
}