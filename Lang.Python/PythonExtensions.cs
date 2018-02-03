using System;
using System.Collections.Generic;
using System.Linq;
using Lang.Python.Numpy;

namespace Lang.Python
{
    public static class PythonExtensions
    {
        public static IEnumerable<T> AsEnumerable<T>(this NdArray<T> x)
        {
            throw new NotImplementedException();
        }

        public static IList<double> IntToDouble(this IList<int> l)
        {
            var r = new double[l.Count];
            for (int i = 0; i < l.Count; i++)
                r[i] = l[i];
            return r;
        }

        public static List<TOut> PyMap<TIn, TOut>(this NdArray<TIn> items, Func<TIn, TOut> func)
        {
            throw new NotImplementedException();
        }


        public static PyList<TOut> PyMap<TIn, TOut>(this IEnumerable<TIn> items, Func<TIn, TOut> func)
        {
            return PyMap(items.ToArray(), func);
        }

        public static PyList<TOut> PyMap<TIn, TOut>(this IReadOnlyList<TIn> items, Func<TIn, TOut> func)
        {
            var result = new List<TOut>(items.Count);
            for (var index = 0; index < items.Count; index++)
            {
                var i = items[index];
                result.Add(func(i));
            }

            return new PyList<TOut>(result);
        }

        public static IList<T> ToIListCastOrConvert<T>(this IEnumerable<T> x)
        {
            return x is IList<T> list ? list : x.ToList();
        }
    }
}