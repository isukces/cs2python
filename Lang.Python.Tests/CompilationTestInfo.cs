using Cs2Py.Compilation;
using Cs2Py.Translator;

namespace Lang.Python.Tests
{
    public class CompilationTestInfo
    {
        public CompilationTestInfo(Cs2PyCompiler compiler, TranslationInfo info, Translator translator)
        {
            Compiler   = compiler;
            Info       = info;
            Translator = translator;
        }

        public Cs2PyCompiler   Compiler   { get; set; }
        public TranslationInfo Info       { get; set; }
        public Translator      Translator { get; set; }
    }
}