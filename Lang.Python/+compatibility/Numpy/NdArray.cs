using System.Collections.Generic;
using System.Linq;

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
        protected static Complex GetMean(IList<Complex> a)
        {
            if (a.Count == 0) return Complex.Zero;
            var sum = a.Aggregate(Complex.Zero, (current, i) => current + i);
            return sum / a.Count;
        }

        protected static double GetMean(IList<bool> a)
        {
            if (a.Count == 0)
                return 0;
            return a.Count(q => q) / (double)a.Count;
        }

        internal IList<T> InternalData { get; set; }
        internal NdArrayShapeInfo ShapeInfo{ get; set; }
    }
}