using System;
using System.Collections.Generic;
using System.Linq;

namespace Lang.Python.Numpy
{
    [PyModule("numpy", true)]
    [ExportAsPyModule]
    public class Np
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

        [DirectCall("cos")]
        public static List<double> Cos(List<double> x)
        {
            return x.MapToList(Math.Cos);
        }

        [DirectCall("sin")]
        public static List<double> Sin(List<double> x)
        {
            return x.MapToList(Math.Sin);
        }

        public static Type Int32 => typeof(int);
    }
}