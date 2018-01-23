using System;

namespace Lang.Python.Tensorflow
{
    public class Tensor
    {
    }

    public class Tensor<T> : Tensor
    {
        public Tensor(
            [ScriptName("op")]          object op,
            [ScriptName("value_index")] int    valueIndex
            // [ScriptName("dtype")]       Type dtype
        )
        {
            // https://www.tensorflow.org/api_docs/python/tf/Tensor
            /*
            __init__(
                op,
                value_index,
                dtype
            )
            Creates a new Tensor.

                Args:
            op: An Operation. Operation that computes this tensor.
                value_index: An int     . Index of the operation's endpoint that produces this tensor.
                dtype: A DType. Type    of elements stored in this tensor.
                */
        }

        
        [DirectCall("")]
        public static Tensor<T> operator +(Tensor<T> a, Tensor<T> b)
        {
            throw new NotImplementedException();
        }

        // a: Tensor of type float16, float32, float64, int32, complex64, complex128 and rank > 1.
        /*device
The name of the device on which this tensor will be produced, or None.

dtype
The DType of elements in this tensor.

graph
The Graph that contains this tensor.

name
The string name of this tensor.

op
The Operation that produces this tensor as an output.

shape
Returns the TensorShape that represents the shape of this tensor.*/

        /// <summary>
        ///     The name of the device on which this tensor will be produced, or None.
        /// </summary>
        [ScriptName("device")]
        public object Device { get; set; }

        /// <summary>
        ///     The DType of elements in this tensor.
        /// </summary>
        [ScriptName("dtype")]
        public Type Dtype { get; set; }

        /// <summary>
        ///     The Graph that contains this tensor.
        /// </summary>
        [ScriptName("graph")]
        public Graph Graph { get; set; }


        /// <summary>
        ///     The string name of this tensor.
        /// </summary>
        [ScriptName("name")]
        public string Name { get; set; }

        /// <summary>
        ///     The Operation that produces this tensor as an output.
        /// </summary>
        [ScriptName("op")]
        public object Op { get; set; }

        /// <summary>
        ///     Returns the TensorShape that represents the shape of this tensor.*/
        /// </summary>
        [ScriptName("shape")]
        public TensorShape Shape { get; }
    }
}