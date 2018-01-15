using Xunit;

namespace Lang.Python.Tests
{
    public class MathTests : TestingBase
    {
        [Fact]
        public void T01_Should_convert_empty_class()
        {
            const string cs       = @"
namespace Foo {
    [Lang.Python.IgnoreNamespaceAttribute]
    public class Demo{
        public static double Sin(double a) {
            return System.Math.Sin(a);            
            return System.Math.Cos(a);
        }
    }
}";
            const string expected = @"
import math
class Demo:
    @staticmethod
    def Sin(cls, a):
        return math.sin(a);
        return math.cos(a);
";

            CheckTranslation(cs, expected);
        }
    }
}