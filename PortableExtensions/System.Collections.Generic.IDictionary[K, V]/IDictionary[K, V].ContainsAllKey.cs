#region Using

using System;
using System.Collections.Generic;
using System.Linq;

#endregion

namespace PortableExtensions
{
    /// <summary>
    ///     Class containing some extension methods for <see cref="IDictionary{TKey,TValue}" />.
    /// </summary>
    // ReSharper disable once InconsistentNaming
    public static partial class IDictionaryEx
    {
        /// <summary>
        ///     Checks if the dictionary contains all given keys.
        /// </summary>
        /// <exception cref="ArgumentNullException">The dictionary can not be null.</exception>
        /// <exception cref="ArgumentNullException">The keys can not be null.</exception>
        /// <typeparam name="TKey">Type of the key.</typeparam>
        /// <typeparam name="TValue">Type of the value.</typeparam>
        /// <param name="dictionary">The Dictionary to act on.</param>
        /// <param name="keys">A list of keys.</param>
        /// <returns>Returns true if the dictionary contains all keys.</returns>
        public static Boolean ContainsAllKey<TKey, TValue>( this IDictionary<TKey, TValue> dictionary,
                                                            params TKey[] keys )
        {
            dictionary.ThrowIfNull( () => dictionary );
            keys.ThrowIfNull( () => keys );

            return keys.All( dictionary.ContainsKey );
        }

        /// <summary>
        ///     Checks if the dictionary contains all given keys.
        /// </summary>
        /// <exception cref="ArgumentNullException">The dictionary can not be null.</exception>
        /// <exception cref="ArgumentNullException">The keys can not be null.</exception>
        /// <typeparam name="TKey">Type of the key.</typeparam>
        /// <typeparam name="TValue">Type of the value.</typeparam>
        /// <param name="dictionary">The Dictionary to act on.</param>
        /// <param name="keys">A list of keys.</param>
        /// <returns>Returns true if the dictionary contains all keys.</returns>
        public static Boolean ContainsAllKey<TKey, TValue>( this IDictionary<TKey, TValue> dictionary,
                                                            IEnumerable<TKey> keys )
        {
            dictionary.ThrowIfNull( () => dictionary );
            keys.ThrowIfNull( () => keys );

            return keys.All( dictionary.ContainsKey );
        }
    }
}