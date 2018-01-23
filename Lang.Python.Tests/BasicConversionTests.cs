using Xunit;

namespace Lang.Python.Tests
{
    public class BasicConversionTests : TestingBase
    {
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

            CheckTranslation(cs, new Info{Compare = expected});
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
            CheckTranslation(cs, new Info{Compare = expected});
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
            CheckTranslation(cs, new Info{Compare = expected});
        }


        [Fact]
        public void T05_Should_convert_class_with_field()
        {
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
            CheckTranslation(cs, new Info{Compare = expected});
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
            CheckTranslation(cs, new Info{Compare = expected});
        }
    }
}