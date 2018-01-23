using Xunit;

namespace Lang.Python.Tests
{
    public class ListsConversionTests : TestingBase
    {
        [Fact]
        public void T01_Should_convert_simple_array()
        {
            const string cs                        = @"
        public static void Test() {           
              var array = new[] {1, 2, 3};
        }
        ";
            const string expected                  = @"
class Demo:
    @staticmethod
    def Test(cls):
        array = [1, 2, 3]
";
            CheckTranslation(WrapClass(cs), new Info {Compare = expected});
        }
    }
}