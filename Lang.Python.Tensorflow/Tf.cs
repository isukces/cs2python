using System;

namespace Lang.Python.Tensorflow
{
    /// <summary>
    ///     Tensorflow module
    /// </summary>
    // [ScriptName("tensorflow")]
    [Module("tensorflow", true, ClassIsModule = true)]
    public class Tf
    {
        [DirectCall("matmul")]
        public static Tensor<T> MatMul<T>(
            [ScriptName("a")]           Tensor<T> a,
            [ScriptName("b")]           Tensor<T> b,
            [ScriptName("transpose_a")] bool      transposeA = false,
            [ScriptName("transpose_b")] bool      transposeB = false,
            [ScriptName("adjoint_a")]   bool      adjointA   = false,
            [ScriptName("adjoint_b")]   bool      adjointB   = false,
            [ScriptName("a_is_sparse")] bool      aIsSparse  = false,
            [ScriptName("b_is_sparse")] bool      bIsSparse  = false,
            [ScriptName("name")]        string    name       = null)
        {
            // https://www.tensorflow.org/api_docs/python/tf/matmul
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
            [ScriptName("shape")]  int[]  shape,
            [ScriptName("mean")]   double mean   = 0.0,
            [ScriptName("stddev")] double stddev = 1.0,
            // [ScriptName("dtype")]  TfDataType dtype  = TfDataType.float32, // implicit double
            [ScriptName("seed")] int?   seed = null,
            [ScriptName("name")] string name = null
        )
        {
            // https://www.tensorflow.org/api_docs/python/tf/truncated_normal
            throw new NotImplementedException();
        }

        [DirectCall("zeros")]
        public static Tensor<T> Zeros<T>(
            [ScriptName("shape")] int[]        shape,
            [ScriptName("dtype")] PyNumberType dtype,
            [ScriptName("name")]  string       name = null)
        {
            throw new NotImplementedException();
        }

        [DirectCall("zeros")]
        public static Tensor<double> ZerosDouble(
            [ScriptName("shape")] int[]  shape,
            [ScriptName("name")]  string name = null)
        {
            throw new NotImplementedException();
        }

        [DirectCall("name_scope")]
        public static TfScope NameScope(string scopename)
        {
            return new TfScope(scopename);
        }

        [DirectCall("variable")]
        public static TfVariable<T> Variable<T>(
            [ScriptName("initial_value")]  T      initialValue,
            [ScriptName("trainable")]      bool   trainable     = true,
            [ScriptName("collections")]    object collections   = null,
            [ScriptName("validate_shape")] bool   validateShape = true,
            [ScriptName("caching_device")] object cachingDevice = null,
            [ScriptName("name")]           object name          = null,
            [ScriptName("variable_def")]   object variableDef   = null,
            [ScriptName("dtype")]          object dtype         = null,
            [ScriptName("expected_shape")] object expectedShape = null,
            [ScriptName("import_scope")]   object importScope   = null,
            [ScriptName("constraint")]     object constraint    = null
        )
        {
            return new TfVariable<T>(initialValue, trainable, collections, validateShape, cachingDevice,
                name, variableDef, dtype, expectedShape, importScope, constraint);
        }
    }
}