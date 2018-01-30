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

        [DirectCall("name_scope")]
        public static TfScope NameScope(string scopename)
        {
            return new TfScope(scopename);
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

        
        [PyModule("tensorflow.nn", true, ImportModule ="tensorflow")]
        [ExportAsPyModule]
        public class Nn
        {
            [DirectCall("relu")]
            public static Tensor<T> Relu<T>(Tensor<T> src)
            {
                throw new System.NotImplementedException();
            }
        
            
        }
    }
}