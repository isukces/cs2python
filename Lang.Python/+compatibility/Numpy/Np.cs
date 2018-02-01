using System;
using System.Collections.Generic;
using System.Linq;

namespace Lang.Python.Numpy
{
    [PyModule("numpy", true)]
    [ExportAsPyModule]
    public partial class Np
    {
        [DirectCall("arange")]
        public static List<int> ARange(int stop)
        {
            var result = new List<int>(stop);
            result.AddRange(Enumerable.Range(0, stop));
            return result;
            // https://docs.scipy.org/doc/numpy-1.13.0/reference/generated/numpy.arange.html
            // numpy.arange([start, ]stop, [step, ]dtype = None)
        }

        [DirectCall("arange")]
        public static List<int> ARange(int start, int stop, int step = 1)
        {
            var result = new List<int>();
            for (var i = start; i < stop; i += step)
                result.Add(i);
            return result;
        }

        [DirectCall("arange")]
        public static List<double> ARange(double stop)
        {
            var result = new List<double>((int)stop);
            result.AddRange(Enumerable.Range(0, (int)stop).Select(a => (double)a));
            return result;
        }

        [DirectCall("arange")]
        public static List<double> ARange(double start, double stop, double step = 1)
        {
            var result = new List<double>();
            for (var i = start; i < stop; i += step)
                result.Add(i);
            return result;
        }

        [DirectCall("linSpace")]
        public NdArray1D<double> LinSpace(
            double start,
            double stop,
            int num      = 50,
            bool   endpoint = true
            /* , retstep=False, dtype=None */)
        {
            var delta = (start - stop) / (endpoint ? num - 1 : num);
            double[] array = new double[num];
            for (int i = 0; i < num; i++)
                array[i] = start + i * delta;
            if (endpoint)
                array[num - 1] = stop;
            return Array(array);
        }
 

        public static Type Int32 => typeof(int);
    }
}