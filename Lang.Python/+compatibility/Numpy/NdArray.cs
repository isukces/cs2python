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
        protected static Complex GetMean(Complex[] a)
        {
            if (a.Length == 0) return Complex.Zero;
            var sum = a.Aggregate(Complex.Zero, (current, i) => current + i);
            return sum / a.Length;
        }

        protected static double GetMean(bool[] a)
        {
            if (a.Length == 0)
                return 0;
            return a.Count(q => q) / (double)a.Length;
        }

        protected T[] InternalData;
    }
}