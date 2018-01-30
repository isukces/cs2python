using System;
using System.Collections.Generic;
using Lang.Python;
using Lang.Python.Numpy;
using Lang.Python.Plot;
using Lang.Python.Tensorflow;

namespace Demo01
{
    /// <summary>
    ///     Some demo code used with copy-paste in unit tests
    /// </summary>
    public class Demo
    {
        public static void ConvertArange()
        {
            var int1 = Np.ARange(5);
            var int2 = Np.ARange(5, 10);
            var int3 = Np.ARange(5, 10, 3);

            var double1 = Np.ARange(5.1);
            var double2 = Np.ARange(5.1, 10);
            var double3 = Np.ARange(5.1, 10, 3);
        }

        public static void ConvertPyPlot()
        {
            var x = Np.ARange(0, 5, 0.1);
            var y = Np.Sin(x);
            PyPlot.Plot(x, y);
        }

        public static void CreateNumpyArrays()
        {
            var list = new[] {1, 2, 3};
            var tmp  = Np.Array(new[] {1.0, 2, 3});
            var tmp2 = Np.Array(new[] {1.0, 2, 3}, order: NumpyArrayOrder.C);
        }

        public static void DoubleWithDemo()
        {
            using(TfScope scope = Tf.NameScope("scopeName"), scope2 = Tf.NameScope("scopeName"))
            {
                Py.Nothing();
            }
        }

        
        public static void DictionaryTest()
        {
            var dictEmpty = new Dictionary<int, string>();
            Console.WriteLine(dictEmpty.Count);
            var dictInitialized = new Dictionary<int, string>
            {
                [1] = "one",
                [2] = "two"
            };
            dictEmpty = dictInitialized;
            dictEmpty.Remove(1);
            dictEmpty[3] = "three";
            dictEmpty.Clear();
            var keys = dictEmpty.Keys;
            var values = dictEmpty.Values;
            var containsKye = dictEmpty.ContainsKey(3);
        }
        
        public static void DictionaryRemove()
        {
            var dictEmpty = new Dictionary<int, string>();            
            dictEmpty.Remove(1);                    
        }
    }
}