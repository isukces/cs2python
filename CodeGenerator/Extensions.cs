using System;
using System.Collections.Generic;
using isukces.code;

namespace CodeGenerator
{
    static class Extensions
    {
        public static string GetShortName(this CsClass cl)
        {
            return String.Format("{0}.Auto.cs", cl.Name);
        }
        
        public static string FirstLower(this string x)
        {
            return x.Substring(0, 1).ToLower() + x.Substring(1);
        }

        public static CsMethod WithDirectCall(this CsMethod m, string name)
        {
            m.Attributes.Add(new CsAttribute("DirectCall").WithArgument(name));
            return m;
        }

      
    }
}