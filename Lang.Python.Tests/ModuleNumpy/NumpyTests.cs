using Lang.Python.Tensorflow;
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
            var tmp = Np.Array1(new[] {1.0, 2, 3}, order: NumpyArrayOrder.C);
        }
        ";

            const string expected                                                  = @"
import numpy
class Demo:
    @staticmethod
    def CreateNumpyArrays(cls):
        tmp = numpy.array([1., 2, 3], order='C')
    


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
                Ref     = new[] {typeof(Graph).Assembly}
            });
        }


        [Fact]
        public void T03_Should_convert_arange()
        {
            const string cs = @"
        public static void ConvertArange()
        {
            var int1 = Np.ARange(5);
            var int2 = Np.ARange(5, 10);
            var int3 = Np.ARange(5, 10, 3);

            var double1 = Np.ARange(5.1);
            var double2 = Np.ARange(5.1, 10);
            var double3 = Np.ARange(5.1, 10, 3);
        }
        ";

            const string expected = @"
import numpy
class Demo:
    @staticmethod
    def ConvertArange(cls):
        int1 = numpy.arange(5)
        int2 = numpy.arange(5, 10)
        int3 = numpy.arange(5, 10, 3)
        double1 = numpy.arange(5.1)
        double2 = numpy.arange(5.1, 10)
        double3 = numpy.arange(5.1, 10, 3)";
            CheckTranslation(WrapClass(cs, "Lang.Python.Numpy", "System", "Lang.Python"), new Info
            {
                Compare = expected,
                Ref     = new[] {typeof(Graph).Assembly}
            });
        }


        [Fact]
        public void T04_Should_import_numpy_module_with_np_alias()
        {
            const string cs = @"
using Lang.Python.Numpy;
using System;
using Lang.Python;

[assembly:ImportModuleAs(""numpy"",""np"")]
namespace Foo {

    [IgnoreNamespaceAttribute]
    public class Demo{
        
        public static void ConvertArange()
        {
            var int1 = Np.ARange(5);           
        }
        
    }
}
        ";

            const string expected                  = @"
import numpy as np
class Demo:
    @staticmethod
    def ConvertArange(cls):
        int1 = np.arange(5)
";
            CheckTranslation(cs, new Info {Compare = expected});
        }
    }
}