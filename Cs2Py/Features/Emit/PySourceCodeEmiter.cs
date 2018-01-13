using System.Collections.Generic;
using Cs2Py.CSharp;

namespace Cs2Py.Emit
{
    public class PySourceCodeEmiter
    {
        public static string GetAccessModifiers(IPyClassMember m)
        {
            var modifiers = new List<string>();
            switch (m.Visibility)
            {
                case Visibility.Private:
                    modifiers.Add("private");
                    break;
                case Visibility.Protected:
                    modifiers.Add("protected");
                    break;
                default:
                    modifiers.Add("public");
                    break;
            }

            if (m.IsStatic)
                modifiers.Add("static");
            return string.Join(" ", modifiers);
        }

        private PySourceCodeWriter _code = new PySourceCodeWriter();
    }
}