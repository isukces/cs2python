using isukces.code;

namespace CodeGenerator
{
    internal static class Extensions
    {
        public static string FirstLower(this string x)
        {
            return x.Substring(0, 1).ToLower() + x.Substring(1);
        }

        public static string GetShortName(this CsClass cl)
        {
            return string.Format("{0}.Auto.cs", cl.Name);
        }

        public static CsMethod WithBodyComment(this CsMethod m, string comment)
        {
            // uncomment for diagnostic code generation
            /*
            m.Body = $"//{comment}\r\n{m.Body}".TrimEnd();
            */
            return m;
        }

        public static CsMethod WithDirectCall(this CsMethod m, string name)
        {
            m.Attributes.Add(new CsAttribute("DirectCall").WithArgument(name));
            return m;
        }
    }
}