using System;
using Lang.Python.Tensorflow;

namespace Demo01
{
    class TensorFlowMinst
    {

        public static void inferenceb(Tensor<double> images, int hidden1Units)
        {
            using(var scope = Tf.NameScope("scopeName"))
            {
                var weights = Tf.Variable(
                    Tf.TruncatedNormal(new[] {IMAGE_PIXELS, hidden1Units}, stddev: 1.0 / Math.Sqrt(IMAGE_PIXELS)),
                    name: "weights");

                var biases  = Tf.Variable(Tf.ZerosDouble(new[] {hidden1Units}), name: "biases");
                var hidden1 = TfNn.Relu(Tf.MatMul(images, weights) + biases);
            }

            /*
             *
             *def inference(images, hidden1_units, hidden2_units):
  """Build the MNIST model up to where it may be used for inference.

  Args:
    images: Images placeholder, from inputs().
    hidden1_units: Size of the first hidden layer.
    hidden2_units: Size of the second hidden layer.

  Returns:
    softmax_linear: Output tensor with the computed logits.
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
        private const int NUM_CLASSES  = 10;
        private const int IMAGE_SIZE   = 28;
        private const int IMAGE_PIXELS = IMAGE_SIZE * IMAGE_SIZE;
    }
}