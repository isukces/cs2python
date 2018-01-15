using System.Collections.Generic;
using System.IO;
using System.Linq;
using Cs2Py.Compilation;
using Cs2Py.Emit;
using Cs2Py.Sandbox;
using Cs2Py.Translator;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Host.Mef;
using Xunit;

namespace Lang.Python.Tests
{
    public class TestingBase
    {
        protected static string WrapClass(string code)
        {
            return $@"
namespace Foo {{
    [Lang.Python.IgnoreNamespaceAttribute]
    public class Demo{{
        {code}
    }}
}}";
        }
        protected static CompilationTestInfo CheckTranslation(string code, string compare)
        {
            return ParseCs(code, true, compare);
        }

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

        protected static CompilationTestInfo ParseCs(string code, bool translate, string compare = null)
        {
            var project = CreateOneFileProject(code);
            var c       = new Cs2PyCompiler
            {
                CSharpProject = project
            };
            c.TranslationAssemblies.Add(typeof(AssemblySandbox).Assembly);
            var filename = Path.GetTempFileName().Replace(".tmp", ".dll");
            var er       = c.CompileCSharpProject(c.Sandbox, filename);
            Assert.True(er.Success);
            var translationInfo = c.ParseCsSource();
            if (!translate)
                return new CompilationTestInfo(c, translationInfo, null);
            var translationState            = new TranslationState(translationInfo);
            var translator                  = new Translator(translationState);
            translator.Info.CurrentAssembly = c.CompiledAssembly;
            translator.Translate(c.Sandbox);
            if (compare != null)
            {
                compare = compare.Trim();
                if (!compare.StartsWith("'''"))
                    compare = "'''\r\nGenerated with cs2py\r\n'''\r\n" + compare;
                var emiter  = new PySourceCodeEmiter();
                var writer  = new PySourceCodeWriter();
                translator.Modules[0].Emit(emiter, writer, new PyEmitStyle());
                var pyCode = writer.GetCode();
                Assert.Equal(compare.Trim(), pyCode.Trim());
            }

            return new CompilationTestInfo(c, translationInfo, translator);
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