using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pancakes.Engine.Utilities
{
    /// <summary>
    /// A collection of convenience methods for common .NET idioms.
    /// </summary>
    public static class DotNetExtensions
    {
        /// <summary>
        /// A LINQ-like foreach loop.
        /// </summary>
        /// <typeparam name="T">Type of the enumeration.</typeparam>
        /// <param name="list">Enumerable to iterate over.</param>
        /// <param name="action">Action to perform each iteration.</param>
        public static void ForEach<T>(this IEnumerable<T> list, Action<T> action)
        {
            foreach (var item in list)
            {
                action(item);
            }
        }

        /// <summary>
        /// Sets the given value for the given key.  If the key/value pair
        /// doesn't exist, it will be added to the dictionary.
        /// </summary>
        /// <param name="dict"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public static void ReplaceOrAdd<T, V>(this Dictionary<T, V> dict, T key, V value)
        {
            V obj;
            var has = dict.TryGetValue(key, out obj);

            if (has)
                dict[key] = value;
            else
                dict.Add(key, value);
        }
    }
}
