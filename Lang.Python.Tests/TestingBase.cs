using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Host.Mef;

namespace Lang.Python.Tests
{
    public class TestingBase
    {
        protected static Project CreateOneFileProject(string code)
        {
            var tmp      = new AdhocWorkspace(DesktopMefHostServices.DefaultServices);
            var solution = tmp.AddSolution(SolutionInfo.Create(SolutionId.CreateNewId(), VersionStamp.Create()));
            var project  = solution.AddProject("Foo", "Foo", LanguageNames.CSharp);
            var doc      = project.AddDocument("foo.cs", code);
            project      = doc.Project;
            project      = project.AddMetadataReferences(GetGlobalReferences());
            return project;
        }

        private static IEnumerable<MetadataReference> GetGlobalReferences()
        {
            // from https://stackoverflow.com/questions/23907305/roslyn-has-no-reference-to-system-runtime
            var assemblies = new[]
            {
                //mscorlib
                typeof(object).Assembly,
                // Lang.Python
                typeof(Py).Assembly 
                //typeof(System.Composition.ExportAttribute).Assembly,   //System.Composition (MEF)
                // typeof(System.CodeDom.Compiler.CodeCompiler).Assembly, //System.CodeDom.Compiler
                
            };

            var refs = assemblies.Select(a => MetadataReference.CreateFromFile(a.Location));
            return refs.ToList();
        }
    }
}