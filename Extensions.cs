using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    public static class Extensions
    {
        public static IEnumerable<(T1, T1)> Tuplify<T1>(this IEnumerable<T1> source)
        {
            var array = source.ToArray();
            for (int i = 0; i < array.Length - 1; i++)
            {
                yield return (array[i], array[i + 1]);
            }
        }

    }
}
