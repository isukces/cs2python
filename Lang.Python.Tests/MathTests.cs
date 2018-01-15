using Xunit;

namespace Lang.Python.Tests
{
    public class MathTests : TestingBase
    {

        [Fact]
        public void T01_Should_convert_sin_cos_tan_asin_acos_atan()
        {
            const string cs       = @"
        public static double Sin(double a) {
            return System.Math.Sin(a);            
            return System.Math.Cos(a);
            return System.Math.Tan(a);
            return System.Math.Asin(a);            
            return System.Math.Acos(a);
            return System.Math.Atan(a);
        }
";
            const string expected = @"
import math
class Demo:
    @staticmethod
    def Sin(cls, a):
        return math.sin(a);
        return math.cos(a);
        return math.tan(a);
        return math.asin(a);
        return math.acos(a);
        return math.atan(a);
";
            CheckTranslation(WrapClass(cs), expected);
        }

        [Fact]
        public void T02_Should_convert_isnan_isinf()
        {
            const string cs       = @"
public static bool IsNaN(double a) {
    return double.IsNaN(a);
}            
public static bool IsInfinity(double a) {
    return double.IsInfinity(a);
}            
";
            const string expected = @"
import math
class Demo:
    @staticmethod
    def IsNaN(cls, a):
        return math.isnan(a);
    
    @staticmethod
    def IsInfinity(cls, a):
        return math.isinf(a);
";
            CheckTranslation(WrapClass(cs), expected);
        }

       
        [Fact]
        public void T03_Should_convert_sinh_cosh_tanh()
        {
            const string cs       = @"
public static double Sin(double a) {
    return System.Math.Sinh(a);            
    return System.Math.Cosh(a);
    return System.Math.Tanh(a);
}
";
            const string expected = @"
import math
class Demo:
    @staticmethod
    def Sin(cls, a):
        return math.sinh(a);
        return math.cosh(a);
        return math.tanh(a);
";
            CheckTranslation(WrapClass(cs), expected);
        }
    }
}