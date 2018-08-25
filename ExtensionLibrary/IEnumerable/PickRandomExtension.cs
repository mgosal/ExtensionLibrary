using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace ExtensionLibrary
{
    public static class PickRandomExtension
    {
        /// <summary>
        /// Returns a random element from IEumerable costing 1 millisecond.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="this"></param>
        /// <returns>Random T</returns>
        public static T PickRandom<T>(this IEnumerable<T> @this)
        {
            if (@this == null) throw new ArgumentNullException("this");
            Thread.Sleep(1);
            var r = new Random(int.Parse(DateTime.Now.Millisecond.ToString().ToCharArray().Last().ToString()));
            var n = r.Next() % @this.Count();
            return @this.ToArray().ElementAt(n);
        }
    }
}
