using System;
using System.Collections.Generic;

namespace Lang.Python
{
    public static class PythonExtensions
    {
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