using System;
using System.Collections.Generic;

namespace ExtensionLibrary
{
    static class ForEachExtension
    {
        /// <summary>
        /// Perform action on each item in IEnumerable
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="action"></param>
        public static void ForEach<T>(this IEnumerable<T> source, Action<T> action)
        {
            foreach (var item in source)
                action(item);
        }
    }
}