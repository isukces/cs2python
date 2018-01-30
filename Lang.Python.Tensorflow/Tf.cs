using System;

namespace Lang.Python.Tensorflow
{
    /// <summary>
    ///     Tensorflow module
    /// </summary>
    // [ScriptName("tensorflow")]
    [PyModule("tensorflow", true)]
    [ExportAsPyModule]
    public class Tf
    {
        [DirectCall("matmul")]
        public static Tensor<T> MatMul<T>(
            [PyName("a")]           Tensor<T> a,
            [PyName("b")]           Tensor<T> b,
            [PyName("transpose_a")] bool      transposeA = false,
            [PyName("transpose_b")] bool      transposeB = false,
            [PyName("adjoint_a")]   bool      adjointA   = false,
            [PyName("adjoint_b")]   bool      adjointB   = false,
            [PyName("a_is_sparse")] bool      aIsSparse  = false,
            [PyName("b_is_sparse")] bool      bIsSparse  = false,
            [PyName("name")]        string    name       = null)
        {
            // https://www.tensorflow.org/api_docs/python/tf/matmul
            throw new NotImplementedException();
        }

        [DirectCall("name_scope")]
        public static TfScope NameScope(string scopename)
        {
            return new TfScope(scopename);
        }

        [DirectCall("reduce_mean")]
        public static Tensor<T> ReduceMean<T>(
            [PyName("input_tensor")]      Tensor<T> inputTensor,
            [PyName("axis")]              object    axis             = null,
            [PyName("keepdims")]          bool?     keepdims         = null,
            [PyName("name")]              string    name             = null,
            [PyName("reduction_indices")] object    reductionIndices = null,
            [PyName("keep_dims")]         bool?     keepDims         = null)
        {
            // https://www.tensorflow.org/api_docs/python/tf/reduce_mean
            throw new NotImplementedException();
        }

        [DirectCall("to_int64")]
        public static Tensor<long> ToInt64<T>(Tensor<T> x, string name = "ToInt64")
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// </summary>
        /// <param name="shape">A 1-D integer Tensor or Python array. The shape of the output tensor.</param>
        /// <param name="mean">A 0-D Tensor or Python value of type dtype. The mean of the truncated normal distribution.</param>
        /// <param name="stddev">
        ///     A 0-D Tensor or Python value of type dtype. The standard deviation of the truncated normal
        ///     distribution.
        /// </param>
        /// <param name="dtype">The type of the output.</param>
        /// <param name="seed">
        ///     A Python integer. Used to create a random seed for the distribution. See tf.set_random_seed for
        ///     behavior.
        /// </param>
        /// <param name="name">A name for the operation (optional).</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        [DirectCall("truncated_normal")]
        public static Tensor<double> TruncatedNormal(
            [PyName("shape")]  int[]  shape,
            [PyName("mean")]   double mean   = 0.0,
            [PyName("stddev")] double stddev = 1.0,
            // [ScriptName("dtype")]  TfDataType dtype  = TfDataType.float32, // implicit double
            [PyName("seed")] int?   seed = null,
            [PyName("name")] string name = null
        )
        {
            // https://www.tensorflow.org/api_docs/python/tf/truncated_normal
            throw new NotImplementedException();
        }

        [DirectCall("Variable")]
        public static TfVariable<T> Variable<T>(
            [PyName("initial_value")]  T      initialValue,
            [PyName("trainable")]      bool   trainable     = true,
            [PyName("collections")]    object collections   = null,
            [PyName("validate_shape")] bool   validateShape = true,
            [PyName("caching_device")] object cachingDevice = null,
            [PyName("name")]           object name          = null,
            [PyName("variable_def")]   object variableDef   = null,
            [PyName("dtype")]          object dtype         = null,
            [PyName("expected_shape")] object expectedShape = null,
            [PyName("import_scope")]   object importScope   = null,
            [PyName("constraint")]     object constraint    = null
        )
        {
            return new TfVariable<T>(initialValue, trainable, collections, validateShape, cachingDevice,
                name, variableDef, dtype, expectedShape, importScope, constraint);
        }

        [DirectCall("zeros")]
        public static Tensor<T> Zeros<T>(
            [PyName("shape")] int[]        shape,
            [PyName("dtype")] PyNumberType dtype,
            [PyName("name")]  string       name = null)
        {
            throw new NotImplementedException();
        }

        [DirectCall("zeros")]
        public static Tensor<double> ZerosDouble(
            [PyName("shape")] int[]  shape,
            [PyName("name")]  string name = null)
        {
            throw new NotImplementedException();
        }


        [PyModule("tensorflow.nn", true, ImportModule = "tensorflow")]
        [ExportAsPyModule]
        public class Nn
        {
            [DirectCall("relu")]
            public static Tensor<T> Relu<T>(Tensor<T> src)
            {
                throw new NotImplementedException();
            }


            /// <summary>
            ///     Computes sparse softmax cross entropy between logits and labels.
            /// </summary>
            /// <param name="sentinel">Used to prevent positional parameters. Internal, do not use.</param>
            /// <param name="labels">
            ///     Tensor of shape [d_0, d_1, ..., d_{r-1}] (where r is rank of labels and result) and dtype int32 or
            ///     int64. Each entry in labels must be an index in [0, num_classes). Other values will raise an exception when this op
            ///     is run on CPU, and return NaN for corresponding loss and gradient rows on GPU.
            /// </param>
            /// <param name="logits">
            ///     Unscaled log probabilities of shape [d_0, d_1, ..., d_{r-1}, num_classes] and dtype float32 or
            ///     float64.
            /// </param>
            /// <param name="name">A name for the operation (optional).</param>
            /// <returns></returns>
            /// <exception cref="NotImplementedException"></exception>
            [DirectCall("sparse_softmax_cross_entropy_with_logits")]
            public static Tensor<double> SparseSoftmaxCrossEntropyWithLogits(
                [PyName("_sentinel")] object         sentinel = null,
                [PyName("labels")]    Tensor<int>    labels   = null,
                [PyName("logits")]    Tensor<double> logits   = null,
                [PyName("name")]      string         name     = null)
            {
                throw new NotImplementedException();
            }

            /// <summary>
            ///     Computes sparse softmax cross entropy between logits and labels.
            /// </summary>
            /// <param name="sentinel">Used to prevent positional parameters. Internal, do not use.</param>
            /// <param name="labels">
            ///     Tensor of shape [d_0, d_1, ..., d_{r-1}] (where r is rank of labels and result) and dtype int32 or
            ///     int64. Each entry in labels must be an index in [0, num_classes). Other values will raise an exception when this op
            ///     is run on CPU, and return NaN for corresponding loss and gradient rows on GPU.
            /// </param>
            /// <param name="logits">
            ///     Unscaled log probabilities of shape [d_0, d_1, ..., d_{r-1}, num_classes] and dtype float32 or
            ///     float64.
            /// </param>
            /// <param name="name">A name for the operation (optional).</param>
            /// <returns></returns>
            /// <exception cref="NotImplementedException"></exception>
            [DirectCall("sparse_softmax_cross_entropy_with_logits")]
            public static Tensor<double> SparseSoftmaxCrossEntropyWithLogits(
                [PyName("_sentinel")] object         sentinel = null,
                [PyName("labels")]    Tensor<long>   labels   = null,
                [PyName("logits")]    Tensor<double> logits   = null,
                [PyName("name")]      string         name     = null)
            {
                throw new NotImplementedException();
            }


            /// <summary>
            ///     Computes sparse softmax cross entropy between logits and labels.
            /// </summary>
            /// <param name="sentinel">Used to prevent positional parameters. Internal, do not use.</param>
            /// <param name="labels">
            ///     Tensor of shape [d_0, d_1, ..., d_{r-1}] (where r is rank of labels and result) and dtype int32 or
            ///     int64. Each entry in labels must be an index in [0, num_classes). Other values will raise an exception when this op
            ///     is run on CPU, and return NaN for corresponding loss and gradient rows on GPU.
            /// </param>
            /// <param name="logits">
            ///     Unscaled log probabilities of shape [d_0, d_1, ..., d_{r-1}, num_classes] and dtype float32 or
            ///     float64.
            /// </param>
            /// <param name="name">A name for the operation (optional).</param>
            /// <returns></returns>
            /// <exception cref="NotImplementedException"></exception>
            [DirectCall("sparse_softmax_cross_entropy_with_logits")]
            public static Tensor<float> SparseSoftmaxCrossEntropyWithLogits(
                [PyName("_sentinel")] object        sentinel = null,
                [PyName("labels")]    Tensor<int>   labels   = null,
                [PyName("logits")]    Tensor<float> logits   = null,
                [PyName("name")]      string        name     = null)
            {
                throw new NotImplementedException();
            }

            /// <summary>
            ///     Computes sparse softmax cross entropy between logits and labels.
            /// </summary>
            /// <param name="sentinel">Used to prevent positional parameters. Internal, do not use.</param>
            /// <param name="labels">
            ///     Tensor of shape [d_0, d_1, ..., d_{r-1}] (where r is rank of labels and result) and dtype int32 or
            ///     int64. Each entry in labels must be an index in [0, num_classes). Other values will raise an exception when this op
            ///     is run on CPU, and return NaN for corresponding loss and gradient rows on GPU.
            /// </param>
            /// <param name="logits">
            ///     Unscaled log probabilities of shape [d_0, d_1, ..., d_{r-1}, num_classes] and dtype float32 or
            ///     float64.
            /// </param>
            /// <param name="name">A name for the operation (optional).</param>
            /// <returns></returns>
            /// <exception cref="NotImplementedException"></exception>
            [DirectCall("sparse_softmax_cross_entropy_with_logits")]
            public static Tensor<float> SparseSoftmaxCrossEntropyWithLogits(
                [PyName("_sentinel")] object        sentinel = null,
                [PyName("labels")]    Tensor<long>  labels   = null,
                [PyName("logits")]    Tensor<float> logits   = null,
                [PyName("name")]      string        name     = null)
            {
                throw new NotImplementedException();
            }
        }
    }
}