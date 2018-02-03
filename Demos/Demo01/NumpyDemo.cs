using System.Collections.Generic;
using Lang.Python.Numpy;

namespace Demo01
{
    public class NumpyDemo
    {
        public void NdArrayDemo()
        {
            var a = new[]
            {
                new[] {1, 2, 3},
                new[] {4, 5, 6}
            };
            NdArray2DInt array2 = Np.Array2(a); // regular
            NdArray1D<int[]> array1 = Np.Array1(a); // not regular

            var tmp_sin = Np.Sin(array2);
            // var t1_sin = Np.Sin(array1);
        }
        
    }
}