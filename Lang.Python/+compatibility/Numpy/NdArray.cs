using System.Collections.Generic;

namespace Lang.Python.Numpy
{
    /*
    public enum NumpyDataType
    {
        // https://docs.scipy.org/doc/numpy-1.13.0/reference/arrays.dtypes.html
        int32,
        complex128
    }
    */


    /// <summary>
    ///     https://docs.scipy.org/doc/numpy-1.13.0/reference/generated/numpy.array.html
    /// </summary>
    [PyName("numpy.ndarray")]
    public class NdArray
    {       
    }

    public abstract class NdArray<T> : NdArray
    {
        /*
        // numpy.array(object, dtype=None, copy=True, order='K', subok=False, ndmin=0)
        public NdArray(IEnumerable<T> obj, bool copy = true, NumpyArrayOrder order = NumpyArrayOrder.K)
        {
        }
        */

        protected NdArray()
        {
        }
    }
     
}