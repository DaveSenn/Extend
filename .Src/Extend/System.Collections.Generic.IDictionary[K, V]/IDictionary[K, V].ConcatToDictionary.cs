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
        ///     Concatenates the given sequences.
        /// </summary>
        /// <exception cref="ArgumentNullException">first can not be null.</exception>
        /// <exception cref="ArgumentNullException">second can not be null.</exception>
        /// <exception cref="ArgumentException">An element with the same key already exists in the dictionary.</exception>
        /// <typeparam name="TValue">The type of the values.</typeparam>
        /// <typeparam name="TKey">The type of the keys.</typeparam>
        /// <param name="first">The first sequence to concatenate.</param>
        /// <param name="second">The second sequence to concatenate.</param>
        /// <returns>
        ///     Returns an <see cref="IDictionary{TKey,TValue}" /> that contains the concatenated elements of the two input
        ///     sequences.
        /// </returns>
        [PublicAPI]
        [NotNull]
        [Pure]
        public static IDictionary<TValue, TKey> ConcatToDictionary<TValue, TKey>(
            [NotNull] this IEnumerable<KeyValuePair<TValue, TKey>> first,
            [NotNull] IEnumerable<KeyValuePair<TValue, TKey>> second )
        {
            first.ThrowIfNull( nameof(first) );
            second.ThrowIfNull( nameof(second) );

            return first
                .Concat( second )
                .ToDictionary( x => x.Key, x => x.Value );
        }
    }
}