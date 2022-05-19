using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode
{
    public enum SortMethod { Ascending, Descending };
    public enum Common { MostCommon, LeastCommon };

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


        public static string Trim(this string input, string pattern)
        {
            return Regex.Replace(input, pattern, "");
        }

        
        //public static IEnumerable<T> OrderBySortMethod<T>(this IEnumerable<T> source, SortMethod sortParam)
        //{
        //    if (sortParam == SortMethod.Descending)
        //         return source = source.OrderByDescending(x => x);
        //    else
        //        return source = source.OrderBy(x => x);
        //}

        public static IOrderedEnumerable<TSource> OrderBySortMethod<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, SortMethod sortParam)
        {
            if (sortParam == SortMethod.Descending)
                return source.OrderByDescending(keySelector);
            else
                return source.OrderBy(keySelector);
        }

    }
}
