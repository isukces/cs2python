using System.Linq;
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
        return a + b";

            CheckTranslation(cs, new Info {Compare = expected});
        }

        [Fact]
        public void T03_Should_convert_class_with_static_method_and_constructor()
        {
            var cs                                 = @"
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
            var expected                           = @"
'''
Generated with cs2py
'''
class Demo:
    def __init__(self, i):
    
    @staticmethod
    def Sum(cls, a, b):
        return a + b   
";
            CheckTranslation(cs, new Info {Compare = expected});
        }

        [Fact]
        public void T04_Should_convert_class_with_constructor()
        {
            var cs                                 = @"
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
            var expected                           = @"
'''
Generated with cs2py
'''
class Demo:
    def __init__(self, i):
        self.publicField = 1
        self._protectedField = 2
        self.__privateField = i
 
";
            CheckTranslation(cs, new Info {Compare = expected});
        }

        [Fact]
        public void T05_Should_convert_class_with_field()
        {
            var cs                                 = @"
namespace Foo {
    [Lang.Python.IgnoreNamespaceAttribute]
    public class Demo{
             public static int someField;
    }
}";
            var expected                           = @"
'''
Generated with cs2py
'''
class Demo:

";
            CheckTranslation(cs, new Info {Compare = expected});
            // Init
            cs                                     = @"
namespace Foo {
    [Lang.Python.IgnoreNamespaceAttribute]
    public class Demo{
             public static int someField = 76;
    }
}";
            expected                               = @"
'''
Generated with cs2py
'''
class Demo:
    someField = 76
";
            CheckTranslation(cs, new Info {Compare = expected});
        }

        [Fact]
        public void T06_Should_export_class_as_module()
        {
            var cs                                 = @"using Lang.Python;

namespace Demo01
{
    [PyModule(""demo"", false)]
    [ExportAsPyModule]
    public static class ClassAsModuleDemo
    {
        [PyName(""sum"")]
        public static int Sum(int a, int b)
        {
            return a + b;
        } 
    }
}";
            var expected                           = @"
def sum(a, b):
    return a + b
";
            CheckTranslation(cs, new Info {Compare = expected});
        }

        [Fact]
        public void T07_Should_convert_enumerable_to_list_and_array()
        {
            var cs       = @"
using System.Linq;

namespace Demo01
{
    [Lang.Python.IgnoreNamespaceAttribute]
    public class LinqCodes
    {
        public static void Enumerable1()
        {
            var a = Enumerable.Range(2, 10).ToList();
            var b = Enumerable.Range(3, 5).ToArray();
        }                
    }
}
";
            var expected = @"
import numpy
class LinqCodes:
    @staticmethod
    def Enumerable1(cls):
        a = numpy.arange(2, 12)
        b = numpy.arange(3, 8)
";
            var info     = new Info
            {
                Compare = expected,
                Ref     = new[]
                {
                    typeof(Enumerable).Assembly
                }
            };
            CheckTranslation(cs, info);
        }

        [Fact]
        public void T08_Should_convert_enumerable_to_list_and_array_with_argument_names()
        {
            var cs       = @"
using System.Linq;

namespace Demo01
{
    [Lang.Python.IgnoreNamespaceAttribute]
    public class LinqCodes
    {
        public static void Enumerable2()
        {
            var a = Enumerable.Range(start: 2, count: 10).ToList();
            var b = Enumerable.Range(count: 10, start: 2).ToList();
        }                  
    }
}
";
            var expected = @"
import numpy
class LinqCodes:
    @staticmethod
    def Enumerable2(cls):
        a = numpy.arange(2, 12)
        b = numpy.arange(2, 12)
";
            var info     = new Info
            {
                Compare = expected,
                Ref     = new[]
                {
                    typeof(Enumerable).Assembly
                }
            };
            CheckTranslation(cs, info);
        }
        
        
        [Fact]
        public void T09_Should_convert_dictionary_remove()
        {
            /* if 'key' in myDict:
    del myDict['key'] */
            var cs       = @"
using System;
using System.Linq;
using System.Collections.Generic;

namespace Demo01
{
    [Lang.Python.IgnoreNamespaceAttribute]
    public class Codes
    {
        public static void DictionaryRemove()
        {
            var dictEmpty = new Dictionary<int, string>();            
            dictEmpty.Remove(1);                    
        }
    }
}
";
            var expected = @"
class Codes:
    @staticmethod
    def DictionaryRemove(cls):
        dictEmpty = dict()
        del dictEmpty[1]
";
            var info     = new Info
            {
                Compare = expected,
                Ref     = new[]
                {
                    typeof(Enumerable).Assembly
                }
            };
            CheckTranslation(cs, info);
        }
        
        
        [Fact]
        public void T10_Should_convert_dictionary()
        {
            var cs       = @"
using System;
using System.Linq;
using System.Collections.Generic;

namespace Demo01
{
    [Lang.Python.IgnoreNamespaceAttribute]
    public class Codes
    {
         public static void DictionaryTest()
        {
            var dictEmpty = new Dictionary<int, string>();
            Console.WriteLine(dictEmpty.Count);
            var dictInitialized = new Dictionary<int, string>
            {
                [1] = ""one"",
                [2] = ""two""
            };
            dictEmpty = dictInitialized; 
            dictEmpty[3] = ""three"";
            dictEmpty.Remove(1);
            dictEmpty.Clear();
            var keys = dictEmpty.Keys;
            var values = dictEmpty.Values;
            var containsKye = dictEmpty.ContainsKey(3);
        }
    }
}
";
            var expected = @"
class Codes:
    @staticmethod
    def DictionaryTest(cls):
        dictEmpty = dict()
        print len(dictEmpty)
        dictInitialized = {1:'one', 2:'two'}
        dictEmpty = dictInitialized
        dictEmpty[3] = 'three'
        del dictEmpty[1]
        dictEmpty.clear()
        keys = dictEmpty.keys()
        values = dictEmpty.values()
        containsKye = dictEmpty.has_key(3) 
";
            var info     = new Info
            {
                Compare = expected,
                Ref     = new[]
                {
                    typeof(Enumerable).Assembly
                }
            };
            CheckTranslation(cs, info);
        }
        
        
        [Fact]
        public void T11_Should_convert_const()
        {
            var cs       = @"
using System;
using System.Linq;
using System.Collections.Generic;

namespace Demo01
{
    [Lang.Python.IgnoreNamespaceAttribute]
    public class Codes
    {
        public static void LocalConst()
        {
            const int Number = 1;
            Console.WriteLine(Number);        
            const string Text = ""some text"";
            Console.WriteLine(Text);
        }
    }
}
";
            var expected = @"
class Codes:
    @staticmethod
    def LocalConst(cls):
        Number = 1
        print Number
        Text = 'some text'
        print Text
";
            var info     = new Info
            {
                Compare = expected,
                Ref     = new[]
                {
                    typeof(Enumerable).Assembly
                }
            };
            CheckTranslation(cs, info);
        }
    }
}