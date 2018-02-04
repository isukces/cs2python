using System.Linq;
using Xunit;

namespace Lang.Python.Tests
{
    public class LoopsTest : TestingBase
    {
        [Fact]
        public void T01_Should_convert_for_loop()
        {
            var cs       = @"
using System;
using Lang.Python;

namespace Demo01
{
    [IgnoreNamespaceAttribute]
    public class DemoClass
    {
        public static void Test()
        {
            for(int i=0; i< 10; i++)
                Console.WriteLine(i);
        }
    }
}
";
            var expected = @"
class DemoClass:
    @staticmethod
    def Test(cls):
        for i in range(10):
            print(i)    
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
        public void T02_Should_convert_for_loop()
        {
            var cs       = @"
using System;
using Lang.Python;

namespace Demo01
{
    [IgnoreNamespaceAttribute]
    public class DemoClass
    {
        public static void Test()
        {
            for(int i=3; i< 10; i++)
                Console.WriteLine(i);
        }
    }
}
";
            var expected = @"
class DemoClass:
    @staticmethod
    def Test(cls):
        for i in range(3, 10):
            print(i)    
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