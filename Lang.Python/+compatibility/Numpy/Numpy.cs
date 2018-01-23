using System;
using System.Collections.Generic;

namespace Lang.Python.Numpy
{
    [Module("numpy", true, ClassIsModule = true)]
    public class Numpy
    {
        [DirectCall("array")]        
        public static NdArray<int> Array(
            IEnumerable<int> obj,
            bool             copy  = true,
            NumpyArrayOrder  order = NumpyArrayOrder.K)
        {
            return NdArray.Make(obj, copy, order);
        }

        [DirectCall("array")]
        public static NdArray<double> Array(
            IEnumerable<double> obj,
            bool                copy  = true,
            NumpyArrayOrder     order = NumpyArrayOrder.K)
        {
            return NdArray.Make(obj, copy, order);
        }

        [DirectCall("array")]
        public static NdArray<Complex> Array(
            IEnumerable<Complex> obj,
            bool                 copy  = true,
            NumpyArrayOrder      order = NumpyArrayOrder.K)
        {
            return NdArray.Make(obj, copy, order);
        }

        public static Type Int32 => typeof(int);
    }
}