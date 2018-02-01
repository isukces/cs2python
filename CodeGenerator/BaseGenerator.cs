using System.Collections.Generic;
using System.IO;
using isukces.code;
using isukces.code.CodeWrite;

namespace CodeGenerator
{
    internal class BaseGenerator
    {
        protected static CsFile CreateFile()
        {
            var file = new CsFile();
            file.AddImportNamespace("System");
            return file;
        }

        protected void Save(CsFile file, CsClass cl, params string[] subDirs)
        {
            var a = new List<string> {BasePath.FullName};
            a.AddRange(subDirs);
            a.Add(cl.GetShortName());
            var fileName = Path.Combine(a.ToArray());
            file.SaveIfDifferent(fileName);
        }

        public DirectoryInfo BasePath { get; set; }
    }
}