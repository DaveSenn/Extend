#region Usings

using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;

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
        ///     Gets all keys of the given dictionary.
        /// </summary>
        /// <exception cref="ArgumentNullException">The dictionary can not be null.</exception>
        /// <typeparam name="TKey">Type of the key.</typeparam>
        /// <typeparam name="TValue">Type of the value.</typeparam>
        /// <param name="dictionary">The Dictionary to act on.</param>
        /// <returns>Returns all keys of the given dictionary.</returns>
        [PublicAPI]
        [Pure]
        [NotNull]
        public static IEnumerable<TKey> GetAllKeys<TKey, TValue>( [NotNull] this IDictionary<TKey, TValue> dictionary )
        {
            dictionary.ThrowIfNull( nameof( dictionary ) );

            return dictionary.Select( x => x.Key );
        }
    }
}