using Xunit;

namespace Lang.Python.Tests.ModuleNumpy
{
    public class NumpyTests : TestingBase
    {
        [Fact]
        public void T01_Should_convert_numpy_array()
        {
            const string cs = @"
        public static void CreateNumpyArrays()
        {
            var tmp = Numpy.Array(new[] {1.0, 2, 3}, order: NumpyArrayOrder.C);
        }
        ";

            const string expected                                                  = @"
import numpy
class Demo:
    @staticmethod
    def CreateNumpyArrays(cls):
        tmp = numpy.array([1, 2, 3], order='C')
    


";
            CheckTranslation(WrapClass(cs, "Lang.Python.Numpy"), new Info {Compare = expected});
        }
        
        
        [Fact]
        public void T02_Should_convert_double_with_statement()
        {
            const string cs = @"
        public static void DoubleWithDemo()
        {
            using(TfScope scope = Tf.NameScope(""scopeName""), scope2 = Tf.NameScope(""scopeName2""))
            {
                Py.Nothing();
            }
        }
        ";

            const string expected = @"
import tensorflow
class Demo:
    @staticmethod
    def DoubleWithDemo(cls):
        with tensorflow.name_scope('scopeName') as scope:
            with tensorflow.name_scope('scopeName2') as scope2:
";
            CheckTranslation(WrapClass(cs, "Lang.Python.Tensorflow", "System", "Lang.Python"), new Info
            {
                Compare = expected,
                Ref     = new [] { typeof(Lang.Python.Tensorflow.Graph).Assembly}
            });
        }

    }
}