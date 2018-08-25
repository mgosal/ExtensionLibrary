using System;
using System.Collections.Generic;
using System.Linq;

namespace ExtensionLibrary
{
    public static class RandomizeExtension
    {
        /// <summary>
        /// Shuffle items in IEnumerable
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="target"></param>
        /// <returns></returns>
        public static IEnumerable<T> Randomize<T>(this IEnumerable<T> target)
        {
            return target.OrderBy(x => (new Random().Next()));
        }
    }
}
