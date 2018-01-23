using Xunit;

namespace Lang.Python.Tests
{
    public class TensorflowTests : TestingBase
    {
        [Fact]
        public void T01_Should_create_double_value()
        {
            Assert.Equal(16, sizeof(decimal));
            Assert.Equal(8, sizeof(double));
            Assert.Equal(4, sizeof(float));
        }
        
        
        [Fact]
        public void T02_Should_convert_tensorflow_scope()
        {
            const string cs = @"
       public static void inferenceb(Tensor<double> images, int hidden1Units)
        {
            int IMAGE_PIXELS = 23;
            using(var scope = Tf.NameScope(""scopeName""))
            {
                var weights = Tf.Variable(
                    Tf.TruncatedNormal(new[] {IMAGE_PIXELS, hidden1Units}, stddev: 1.0 / Math.Sqrt(IMAGE_PIXELS)),
                    name: ""weights"");

                TfVariable<Tensor<double>> biases =
                    Tf.Variable(Tf.ZerosDouble(new[] {hidden1Units}), name: ""biases"");
                Tensor<double> hidden1 = TfNn.Relu(Tf.MatMul(images, weights) + biases);
            }
        }
        ";

            const string expected = @"

import tensorflow
import math
class Demo:
    @staticmethod
    def inferenceb(cls, images, hidden1Units):
        IMAGE_PIXELS = 23
        with tensorflow.name_scope('scopeName') as scope:
            weights = tensorflow.variable(tensorflow.truncated_normal([IMAGE_PIXELS, hidden1Units], stddev=1 / math.sqrt(IMAGE_PIXELS)), name='weights')
            biases = tensorflow.variable(tensorflow.zeros([hidden1Units]), name='biases')
            hidden1 = tensorflow.nn.relu(tensorflow.matmul(images, weights) + biases)
    


";
            CheckTranslation(WrapClass(cs, "Lang.Python.Tensorflow", "System"), new Info
            {
                Compare = expected,
                Ref     = new [] { typeof(Lang.Python.Tensorflow.Graph).Assembly}
            });
        }
    }
}