using System.Linq;
using Cs2Py;
using Cs2Py.Source;
using Cs2Py.Translator;
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
        public void T02_Should_convert_for_loop_starting_from_3()
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

        [Fact]
        public void T03_Should_convert_for_loop_with_step_2()
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
            for(int i=3; i< 10; i+=2)
                Console.WriteLine(i);
        }
    }
}
";
            var expected = @"
class DemoClass:
    @staticmethod
    def Test(cls):
        for i in range(3, 10, 2):
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
        public void T04_Should_convert_for_loop_with_step_2()
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
            for(int i=0; i< 10; i=i+2)
                Console.WriteLine(i);
        }
    }
}
";
            var expected = @"
class DemoClass:
    @staticmethod
    def Test(cls):
        for i in range(0, 10, 2):
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
        public void T05_Should_Find_Increment()
        {
            var variable = new PyVariableExpression("x", PyVariableKind.Local);

            void TestExpr(IPyValue e, object expected)
            {
                var value = ForTranslator.FindIncrement(variable, e);
                Assert.NotNull(value);
                var result = value as PyConstValue;
                Assert.NotNull(result);
                Assert.Equal(result.Value, expected);
            }

            TestExpr(new PyIncrementDecrementExpression(variable, true,  false),  1);
            TestExpr(new PyIncrementDecrementExpression(variable, false, false),  -1);
            
            TestExpr(new PyAssignExpression(variable, new PyConstValue(3),   "+"), 3);
            TestExpr(new PyAssignExpression(variable, new PyConstValue(3.7), "+"), 3.7);
            TestExpr(new PyAssignExpression(variable, new PyConstValue(3),   "-"), -3);
            TestExpr(new PyAssignExpression(variable, new PyConstValue(3.7), "-"), -3.7);
            
            
            TestExpr(new PyAssignExpression(variable, new PyBinaryOperatorExpression("+", variable, new PyConstValue(3))), 3);
            TestExpr(new PyAssignExpression(variable, new PyBinaryOperatorExpression("+", variable, new PyConstValue(3.7))), 3.7);
            TestExpr(new PyAssignExpression(variable, new PyBinaryOperatorExpression("+", new PyConstValue(3), variable)),   3);
            TestExpr(new PyAssignExpression(variable, new PyBinaryOperatorExpression("+", new PyConstValue(3.7), variable)), 3.7);
            
            TestExpr(new PyAssignExpression(variable, new PyBinaryOperatorExpression("-", variable, new PyConstValue(3))),   -3);
            TestExpr(new PyAssignExpression(variable, new PyBinaryOperatorExpression("-", variable, new PyConstValue(3.7))), -3.7);
        }
    }
}