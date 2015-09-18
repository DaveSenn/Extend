#region Usings

using System;
using System.Collections.Generic;
using System.Linq;

#endregion

namespace Extend
{
    /// <summary>
    ///     Class containing some extension methods for <see cref="IDictionary{TKey,TValue}" />.
    /// </summary>
    // ReSharper disable once InconsistentNaming
    public static partial class IDictionaryEx
    {
        /// <summary>
        ///     Checks if the dictionary contains any of the given keys.
        /// </summary>
        /// <exception cref="ArgumentNullException">The dictionary can not be null.</exception>
        /// <exception cref="ArgumentNullException">The keys can not be null.</exception>
        /// <typeparam name="TKey">The type of the key.</typeparam>
        /// <typeparam name="TValue">The type of the value.</typeparam>
        /// <param name="dictionary">The dictionary to act on.</param>
        /// <param name="keys">A list of keys.</param>
        /// <returns>Returns true if the dictionary contains any of the given keys, otherwise false.</returns>
        public static Boolean ContainsAnyKey<TKey, TValue>( this IDictionary<TKey, TValue> dictionary,
                                                            params TKey[] keys )
        {
            dictionary.ThrowIfNull(nameof(dictionary));
            keys.ThrowIfNull(nameof(keys));

            return keys.Any( dictionary.ContainsKey );
        }

        /// <summary>
        ///     Checks if the dictionary contains any of the given keys.
        /// </summary>
        /// <exception cref="ArgumentNullException">The dictionary can not be null.</exception>
        /// <exception cref="ArgumentNullException">The keys can not be null.</exception>
        /// <typeparam name="TKey">The type of the key.</typeparam>
        /// <typeparam name="TValue">The type of the value.</typeparam>
        /// <param name="dictionary">The dictionary to act on.</param>
        /// <param name="keys">A list of keys.</param>
        /// <returns>Returns true if the dictionary contains any of the given keys, otherwise false.</returns>
        public static Boolean ContainsAnyKey<TKey, TValue>( this IDictionary<TKey, TValue> dictionary,
                                                            IEnumerable<TKey> keys )
        {
            dictionary.ThrowIfNull(nameof(dictionary));
            keys.ThrowIfNull(nameof(keys));

            return keys.Any( dictionary.ContainsKey );
        }
    }
}