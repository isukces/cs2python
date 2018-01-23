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


    public enum NumpyArrayOrder
    {
        K,
        A,
        C,

        F
        /*
        order : {‘K’, ‘A’, ‘C’, ‘F’}, optional
    
    Specify the memory layout of the array. If object is not an array, the newly created array will be in C order (row major) unless ‘F’ is specified, in which case it will be in Fortran order (column major). If object is an array the following holds.
    
    order	no copy	copy=True
    ‘K’	unchanged	F & C order preserved, otherwise most similar order
    ‘A’	unchanged	F order if input is F and not C, otherwise C order
    ‘C’	C order	C order
    ‘F’	F order	F order
    */
    }

    /// <summary>
    ///     https://docs.scipy.org/doc/numpy-1.13.0/reference/generated/numpy.array.html
    /// </summary>
    [ScriptName("numpy.ndarray")]
    public class NdArray
    {
        internal static NdArray<T> Make<T>(IEnumerable<T> obj, bool copy = true,
            NumpyArrayOrder                               order          = NumpyArrayOrder.K)
        {
            return new NdArray<T>(obj, copy, order);
        }
    }

    public class NdArray<T> : NdArray
    {
        // numpy.array(object, dtype=None, copy=True, order='K', subok=False, ndmin=0)¶
        public NdArray(IEnumerable<T> obj, bool copy = true, NumpyArrayOrder order = NumpyArrayOrder.K)
        {
        }



    }
}