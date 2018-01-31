using System.IO;
using System.Linq;
using isukces.code;
using isukces.code.CodeWrite;

namespace CodeGenerator
{
    internal class Generator
    {
        private static void DefaultNotSupportedException(CSCodeFormatter c)
        {
            c.Writeln("default:");
            c.IncIndent();
            c.Writeln("throw new NotSupportedException();");
            c.DecIndent();
        }

        private static string FirstLower(string x)
        {
            return x.Substring(0, 1).ToLower() + x.Substring(1);
        }


        private static string FirstUpper(string x)
        {
            return x.Substring(0, 1).ToUpper() + x.Substring(1);
        }

        private static bool IsAllowedPair(string left, string right)
        {
            bool IsAllowedPair1(string l, string r)
            {
                switch (l + " " + r)
                {
                    case "int ulong":
                    case "sbyte ulong":
                    case "short ulong":
                    case "long ulong":
                    case "double decimal":
                    case "float decimal":
                        return false;
                }

                return true;
            }

            if (left == "string" && right == "string")
                return true;
            if (left == "string" || right == "string")
                return false;
            return IsAllowedPair1(left, right) && IsAllowedPair1(right, left);
        }

        public void GenerateAll()
        {
            GenerateBinaryOperators();
        }

        private void GenerateBinaryOperators()
        {
            var file    = new CsFile();
            var subDir  = "Helpers";
            var cl      = file.GetOrCreateClass(Namespace + "." + subDir, "ValueHelper");
            cl.IsStatic = true;
            file.AddImportNamespace("System");

            void Make(string name, string op)
            {
                var types = "int,long,short,sbyte,uint,ulong,ushort,byte,double,float,decimal".Split(',').ToList();
                if (op == "+")
                    types.Add("string");
                var c = new CSCodeFormatter();
                c.Open("switch (left)");
                {
                    foreach (var left in types)
                    {
                        var ln = "left" + FirstUpper(left);
                        c.Writeln($"case {left} {ln}:");
                        c.IncIndent();
                        {
                            c.Open("switch (right)");
                            {
                                foreach (var right in types)
                                {
                                    if (!IsAllowedPair(left, right))
                                        continue;
                                    var rn = "right" + FirstUpper(right);
                                    c.Writeln($"case {right} {rn}: return {ln} {op} {rn};");
                                }

                                DefaultNotSupportedException(c);
                            }
                            c.Close();
                        }
                        c.DecIndent();
                    }

                    DefaultNotSupportedException(c);
                }
                c.Close();

                var m = cl.AddMethod(name, "object")
                    .WithBody(c)
                    .WithStatic();
                m.AddParam("left",  "object");
                m.AddParam("right", "object");
            }

            Make("Add", "+");
            Make("Sub", "-");
            Make("Mul", "*");
            Make("Div", "/");
            Save(file, subDir, cl);
        }

        private void Save(CsFile file, string subDir, CsClass cl)
        {
            var shortName = string.Format("{0}.Auto.cs", cl.Name);
            var fileName  = Path.Combine(BasePath.FullName, "Cs2Py", "Features", subDir, shortName);
            file.SaveIfDifferent(fileName);
        }

        public DirectoryInfo BasePath  { get; set; }
        public string        Namespace { get; set; }
    }
}