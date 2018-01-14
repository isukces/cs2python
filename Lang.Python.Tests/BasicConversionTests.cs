using System.IO;
using Cs2Py.Compilation;
using Cs2Py.Emit;
using Cs2Py.Translator;
using Xunit;

namespace Lang.Python.Tests
{
    public class BasicConversionTests : TestingBase
    {
        private static CompilationTestInfo CheckTranslation(string code, string compare)
        {
            return ParseCs(code, true, compare);
        }

        private static CompilationTestInfo ParseCs(string code, bool translate, string compare = null)
        {
            var project = CreateOneFileProject(code);
            var c       = new Cs2PyCompiler
            {
                CSharpProject = project
            };
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
                var emiter = new PySourceCodeEmiter();
                var writer = new PySourceCodeWriter();
                translator.Modules[0].Emit(emiter, writer, new PyEmitStyle());
                var pyCode = writer.GetCode();
                Assert.Equal(compare.Trim(), pyCode.Trim());
            }

            return new CompilationTestInfo(c, translationInfo, translator);
        }

        [Fact]
        public void T01_Should_convert_empty_class()
        {
            var ti = ParseCs(@"
namespace Foo {
    public class Demo{       
    }
}", true);
        }

        [Fact]
        public void T02_Should_convert_class_with_static_method()
        {
            const string cs       = @"
namespace Foo {
    [Lang.Python.IgnoreNamespaceAttribute]
    public class Demo{
        public static int Sum(int a, int b) {
            return a+b;
        }
    }
}";
            const string expected = @"
'''
Generated with cs2py
'''
class Demo:
    @staticmethod
    def Sum(cls, a, b):
        return a + b;";

            CheckTranslation(cs, expected);
        }

        [Fact]
        public void T03_Should_convert_class_with_static_method_and_constructor()
        {
            var cs       = @"
namespace Foo {
    [Lang.Python.IgnoreNamespaceAttribute]
    public class Demo{
                public Demo(int i) {
            }
        public static int Sum(int a, int b) {
            return a+b;
        }
    }
}";
            var expected = @"
'''
Generated with cs2py
'''
class Demo:
    def __init__(self, i):
    
    @staticmethod
    def Sum(cls, a, b):
        return a + b;   
";
            CheckTranslation(cs, expected);
        }

        [Fact]
        public void T04_Should_convert_class_with_constructor()
        {
            var cs       = @"
namespace Foo {
    [Lang.Python.IgnoreNamespaceAttribute]
    public class Demo{
        public Demo(int i) {
            publicField = 1;
            protectedField = 2;
            privateField = i;
        }
        public int publicField;
        protected int protectedField;
        private int privateField;
    }
}";
            var expected = @"
'''
Generated with cs2py
'''
class Demo:
    def __init__(self, i):
        self.publicField = 1
        self._protectedField = 2
        self.__privateField = i
 
";
            CheckTranslation(cs, expected);
        }

        [Fact]
        public void T05_Should_convert_class_with_field()
        {
            // No init
            var cs       = @"
namespace Foo {
    [Lang.Python.IgnoreNamespaceAttribute]
    public class Demo{
             public static int someField;
    }
}";
            var expected = @"
'''
Generated with cs2py
'''
class Demo:

";
            CheckTranslation(cs, expected);
            // Init
            cs       = @"
namespace Foo {
    [Lang.Python.IgnoreNamespaceAttribute]
    public class Demo{
             public static int someField = 76;
    }
}";
            expected = @"
'''
Generated with cs2py
'''
class Demo:
    someField = 76
";
            CheckTranslation(cs, expected);
        }
    }
}