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

        public static List<TOut> MapToList<TIn, TOut>(this NdArray<TIn> items, Func<TIn, TOut> func)
        {
            throw new NotImplementedException();
        }


        public static List<TOut> MapToList<TIn, TOut>(this IEnumerable<TIn> items, Func<TIn, TOut> func)
        {
            return MapToList(items.ToArray(), func);
        }

        public static List<TOut> MapToList<TIn, TOut>(this IReadOnlyList<TIn> items, Func<TIn, TOut> func)
        {
            var result = new List<TOut>(items.Count);
            for (var index = 0; index < items.Count; index++)
            {
                var i = items[index];
                result.Add(func(i));
            }

            return result;
        }
    }
}