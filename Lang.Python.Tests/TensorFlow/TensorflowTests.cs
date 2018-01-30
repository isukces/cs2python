using System;
using Lang.Python.Tensorflow;
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
                Tensor<double> hidden1 = Tf.Nn.Relu(Tf.MatMul(images, weights) + biases);
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
            weights = tensorflow.Variable(tensorflow.truncated_normal([IMAGE_PIXELS, hidden1Units], stddev=1 / math.sqrt(IMAGE_PIXELS)), name='weights')
            biases = tensorflow.Variable(tensorflow.zeros([hidden1Units]), name='biases')
            hidden1 = tensorflow.nn.relu(tensorflow.matmul(images, weights) + biases)
    


";
            CheckTranslation(WrapClass(cs, "Lang.Python.Tensorflow", "System"), new Info
            {
                Compare = expected,
                Ref     = new [] { typeof(Tensorflow.Graph).Assembly}
            });
        }
        
        
          
        [Fact]
        public void T03_Should_convert_tensorflow_code()
        {
            const string cs = @"
public static object inference(Tensor<double> images, int hidden1Units, int hidden2Units)
{
            const int NUM_CLASSES = 10;
            const int IMAGE_SIZE  = 28;
            const int IMAGE_PIXELS = IMAGE_SIZE * IMAGE_SIZE;
            // Hidden 1
            Tensor<double> hidden1, hidden2;
            using(var scope = Tf.NameScope(""hidden1""))
            {
                var weights = Tf.Variable(
                    Tf.TruncatedNormal(new[] {IMAGE_PIXELS, hidden1Units},
                        stddev: 1.0 / Math.Sqrt(IMAGE_PIXELS)),
                    name: ""weights"");
                var biases = Tf.Variable(Tf.ZerosDouble(new[] {hidden1Units}), name: ""biases"");
                hidden1    = Tf.Nn.Relu(Tf.MatMul(images, weights) + biases);
            }

            // Hidden 2
            using(var scope = Tf.NameScope(""hidden2""))
            {
                var weights = Tf.Variable(
                    Tf.TruncatedNormal(new[] {hidden1Units, hidden2Units},
                        stddev: 1.0 / Math.Sqrt(hidden1Units)),
                    name: ""weights"");
                var biases = Tf.Variable(Tf.ZerosDouble(new[] {hidden2Units}), name: ""biases"");
                hidden2    = Tf.Nn.Relu(Tf.MatMul(hidden1, weights) + biases);
            }

            // Linear
            using(var scope = Tf.NameScope(""softmax_linear""))
            {
                var weights = Tf.Variable(
                    Tf.TruncatedNormal(new[] {hidden2Units, NUM_CLASSES},
                        stddev: 1.0 / Math.Sqrt(hidden2Units)), name: ""weights"");
                var biases = Tf.Variable(Tf.ZerosDouble(new []{NUM_CLASSES}), name : ""biases"");
                var logits = Tf.MatMul(hidden2, weights) + biases;
                return logits;
            }
}
        ";

            const string expected = @"

import tensorflow
import math
class Demo:
    @staticmethod
    def inference(cls, images, hidden1Units, hidden2Units):
        NUM_CLASSES = 10
        IMAGE_SIZE = 28
        IMAGE_PIXELS = IMAGE_SIZE * IMAGE_SIZE
        with tensorflow.name_scope('hidden1') as scope:
            weights = tensorflow.Variable(tensorflow.truncated_normal([IMAGE_PIXELS, hidden1Units], stddev=1 / math.sqrt(IMAGE_PIXELS)), name='weights')
            biases = tensorflow.Variable(tensorflow.zeros([hidden1Units]), name='biases')
            hidden1 = tensorflow.nn.relu(tensorflow.matmul(images, weights) + biases)
        with tensorflow.name_scope('hidden2') as scope:
            weights = tensorflow.Variable(tensorflow.truncated_normal([hidden1Units, hidden2Units], stddev=1 / math.sqrt(hidden1Units)), name='weights')
            biases = tensorflow.Variable(tensorflow.zeros([hidden2Units]), name='biases')
            hidden2 = tensorflow.nn.relu(tensorflow.matmul(hidden1, weights) + biases)
        with tensorflow.name_scope('softmax_linear') as scope:
            weights = tensorflow.Variable(tensorflow.truncated_normal([hidden2Units, NUM_CLASSES], stddev=1 / math.sqrt(hidden2Units)), name='weights')
            biases = tensorflow.Variable(tensorflow.zeros([NUM_CLASSES]), name='biases')
            logits = tensorflow.matmul(hidden2, weights) + biases
            return logits
    
";
            CheckTranslation(WrapClass(cs, "Lang.Python.Tensorflow", "System"), new Info
            {
                Compare = expected,
                Ref     = new [] { typeof(Tensorflow.Graph).Assembly}
            });
        }
    }
}