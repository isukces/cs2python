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
            NdArray2D<int> tmp = Np.Array(a);
        }
        
    }
}