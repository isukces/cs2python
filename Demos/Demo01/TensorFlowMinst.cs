using System;
using Lang.Python.Tensorflow;

namespace Demo01
{
    internal class TensorFlowMinst
    {
        /// <summary>
        ///     Build the MNIST model up to where it may be used for inference.
        /// </summary>
        /// <param name="images">Images placeholder, from inputs()</param>
        /// <param name="hidden1Units">Size of the first hidden layer</param>
        /// <param name="hidden2Units">Size of the second hidden layer</param>
        /// <returns>softmax_linear: Output tensor with the computed logits</returns>
        public static object inference(Tensor<double> images, int hidden1Units, int hidden2Units)
        {
            // ReSharper disable once LocalVariableHidesMember
            const int NUM_CLASSES  = 10;
            // ReSharper disable once LocalVariableHidesMember
            const int IMAGE_SIZE   = 28;
            // ReSharper disable once LocalVariableHidesMember
            const int IMAGE_PIXELS = IMAGE_SIZE * IMAGE_SIZE;
            // Hidden 1
            Tensor<double> hidden1, hidden2;
            using(var scope = Tf.NameScope("hidden1"))
            {
                var weights = Tf.Variable(
                    Tf.TruncatedNormal(new[] {IMAGE_PIXELS, hidden1Units},
                        stddev: 1.0 / Math.Sqrt(IMAGE_PIXELS)),
                    name: "weights");
                var biases = Tf.Variable(Tf.ZerosDouble(new[] {hidden1Units}), name: "biases");
                hidden1    = Tf.Nn.Relu(Tf.MatMul(images, weights) + biases);
            }

            // Hidden 2
            using(var scope = Tf.NameScope("hidden2"))
            {
                var weights = Tf.Variable(
                    Tf.TruncatedNormal(new[] {hidden1Units, hidden2Units},
                        stddev: 1.0 / Math.Sqrt(hidden1Units)),
                    name: "weights");
                var biases = Tf.Variable(Tf.ZerosDouble(new[] {hidden2Units}), name: "biases");
                hidden2    = Tf.Nn.Relu(Tf.MatMul(hidden1, weights) + biases);
            }

            // Linear
            using(var scope = Tf.NameScope("softmax_linear"))
            {
                var weights = Tf.Variable(
                    Tf.TruncatedNormal(new[] {hidden2Units, NUM_CLASSES},
                        stddev: 1.0 / Math.Sqrt(hidden2Units)), name: "weights");
                var biases = Tf.Variable(Tf.ZerosDouble(new[] {NUM_CLASSES}), name: "biases");
                var logits = Tf.MatMul(hidden2, weights) + biases;
                return logits;
            }

            /*
           *

"""
# Hidden 1
with tf.name_scope('hidden1'):
  weights = tf.Variable    (
      tf.truncated_normal([IMAGE_PIXELS, hidden1_units],
                          stddev=1.0 / math.sqrt(float(IMAGE_PIXELS))),
      name='weights')
  biases = tf.Variable(tf.zeros([hidden1_units]),
                       name='biases')
  hidden1 = tf.nn.relu(tf.matmul(images, weights) + biases)
  
  
# Hidden 2
with tf.name_scope('hidden2'):
  weights = tf.Variable(
      tf.truncated_normal([hidden1_units, hidden2_units],
                          stddev=1.0 / math.sqrt(float(hidden1_units))),
      name='weights')
  biases = tf.Variable(tf.zeros([hidden2_units]),
                       name='biases')
  hidden2 = tf.nn.relu(tf.matmul(hidden1, weights) + biases)
# Linear
with tf.name_scope('softmax_linear'):
  weights = tf.Variable(
      tf.truncated_normal([hidden2_units, NUM_CLASSES],
                          stddev=1.0 / math.sqrt(float(hidden2_units))),
      name='weights')
  biases = tf.Variable(tf.zeros([NUM_CLASSES]),
                       name='biases')
  logits = tf.matmul(hidden2, weights) + biases
return logits

           * 
           */
        }

        public static void inferenceb(Tensor<double> images, int hidden1Units)
        {
            // ReSharper disable once LocalVariableHidesMember
            const int NUM_CLASSES = 10;
            // ReSharper disable once LocalVariableHidesMember
            const int IMAGE_SIZE = 28;

            using(var scope = Tf.NameScope("scopeName"))
            {
                var weights = Tf.Variable(
                    Tf.TruncatedNormal(new[] {IMAGE_PIXELS, hidden1Units}, stddev: 1.0 / Math.Sqrt(IMAGE_PIXELS)),
                    name: "weights");

                var biases  = Tf.Variable(Tf.ZerosDouble(new[] {hidden1Units}), name: "biases");
                var hidden1 = Tf.Nn.Relu(Tf.MatMul(images, weights) + biases);
            }
        }

        public static Tensor<double> Loss(Tensor<double> logits, Tensor<int> labels)
        {
            var labels2      = Tf.ToInt64(labels);
            var crossEntropy =
                Tf.Nn.SparseSoftmaxCrossEntropyWithLogits(logits: logits, labels: labels2, name: "xentropy");
            var loss = Tf.ReduceMean(crossEntropy, name: "xentropy_mean");
            return loss;
        }

        private const int NUM_CLASSES  = 10;
        private const int IMAGE_SIZE   = 28;
        private const int IMAGE_PIXELS = IMAGE_SIZE * IMAGE_SIZE;
    }
}