using System.Linq;
using Cs2Py;
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
    someField = 0

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
        print(len(dictEmpty))
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
        print(Number)
        Text = 'some text'
        print(Text)
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
        public void T12_Should_convert_null()
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
        public static object Get()
        {
            return null;
        }
    }
}
";
            var expected = @"
class Codes:
    @staticmethod
    def Get(cls):
        return None
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
        public void T13_Should_convert_true_and_false()
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
        public static bool GetTrue() { return true; }
        public static bool GetFalse() { return false; }
    }
}
";
            var expected = @"
class Codes:
    @staticmethod
    def GetTrue(cls):
        return True
    
    @staticmethod
    def GetFalse(cls):
        return False
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
        public void T14_Should_convert_static_fields_and_consts()
        {
            var cs       = @"
using System;
using Lang.Python;

namespace Demo01
{
    [IgnoreNamespaceAttribute]
    public class ClassWithFieldsDemo
    {
        [PyName(""earth_gravity"")] 
        public static double EarthGravity = 9.81;

        public static double AnotherStatic = 12.44;

        public const double Sum = 3 + 4.0 /2;
        
        [PyName(""rounded_pi_2"")] 
        public const double RoundedPi2 = 3.14;

        public const double RoundedPi4 = 3.1415;

        public static void PrintAll()
        {
            Console.WriteLine(EarthGravity);
            Console.WriteLine(AnotherStatic);
            Console.WriteLine(RoundedPi2);
            Console.WriteLine(RoundedPi4);
        }
    }
}
";
            var expected = @"

class ClassWithFieldsDemo:
    Sum = 3 + 4. / 2
    rounded_pi_2 = 3.14
    RoundedPi4 = 3.1415
    earth_gravity = 9.81
    AnotherStatic = 12.44
    @staticmethod
    def PrintAll(cls):
        print(cls.earth_gravity)
        print(cls.AnotherStatic)
        print(cls.rounded_pi_2)
        print(cls.RoundedPi4)
    

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
        public void T15_Should_throw_exception_when_illegal_field_initialization()
        {
            var cs       = @"
using System;
using Lang.Python;

namespace Demo01
{
    [IgnoreNamespaceAttribute]
    public class ClassWithFieldsDemo
    {
        [PyName(""earth_gravity"")] 
        public static double EarthGravity = 9.81;

        public static double AnotherStatic = 12.44;

        public const double Sum = RoundedPi2 + RoundedPi4;
        
        [PyName(""rounded_pi_2"")] 
        public const double RoundedPi2 = 3.14;

        public const double RoundedPi4 = 3.1415;

        public static void PrintAll()
        {
            Console.WriteLine(EarthGravity);
            Console.WriteLine(AnotherStatic);
            Console.WriteLine(RoundedPi2);
            Console.WriteLine(RoundedPi4);
        }
    }
}
";
            var expected = @"";
            var info     = new Info
            {
                Compare = expected,
                Ref     = new[]
                {
                    typeof(Enumerable).Assembly
                }
            };
            Assert.Throws<InvalidFieldInitializationValueException>(() =>
            {
                CheckTranslation(cs, info);
            });

        }
        
        
        [Fact]
        public void T16_Should_convert_uninitialised_static_fields()
        {
            var cs       = @"
using System;
using Lang.Python;

namespace Demo01
{
    [IgnoreNamespaceAttribute]
    public class ClassWithFieldsDemo
    {
        public static double f_double;
        public static float f_float;
        public static decimal f_decimal;
        public static int f_int;
        public static long f_long;
        public static short f_short;
        public static sbyte f_sbyte;
        public static byte f_byte;
        public static ushort f_ushort;
        public static uint f_uint;
        public static ulong f_ulong;
        public static string f_string;

        public static void PrintAll()
        {
            Console.WriteLine(f_double);
        }
    }
}
";
            var expected = @"
class ClassWithFieldsDemo:
    f_double = 0.
    f_float = 0.
    f_decimal = 0.
    f_int = 0
    f_long = 0
    f_short = 0
    f_sbyte = 0
    f_byte = 0
    f_ushort = 0
    f_uint = 0
    f_ulong = 0
    f_string = None
    @staticmethod
    def PrintAll(cls):
        print(cls.f_double)    
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
        public void T17_Should_convert_add_assignment()
        {
            var cs       = @"
using System;
using Lang.Python;

namespace Demo01
{
    [IgnoreNamespaceAttribute]
    public class Demo
    {       
        public static void PrintAll()
        {
            int i=2; i+=3; i -= 11;
               
        }
    }
}
";
            var expected = @"
class Demo:
    @staticmethod
    def PrintAll(cls):
        i = 2
        i += 3
        i -= 11   
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