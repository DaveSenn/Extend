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
        ///     Concatenates the given sequences in a safe manner.
        /// </summary>
        /// <remarks>
        ///     Duplicated key are getting removed.
        /// </remarks>
        /// <exception cref="ArgumentNullException">first can not be null.</exception>
        /// <exception cref="ArgumentNullException">second can not be null.</exception>
        /// <typeparam name="TValue">The type of the values.</typeparam>
        /// <typeparam name="TKey">The type of the keys.</typeparam>
        /// <param name="first">The first sequence to concatenate.</param>
        /// <param name="second">The second sequence to concatenate.</param>
        /// <returns>
        ///     Returns an <see cref="IDictionary{TKey,TValue}" /> that contains the concatenated elements of the two input
        ///     sequences.
        /// </returns>
        public static IDictionary<TValue, TKey> ConcatToDictionarySafe<TValue, TKey>(
            this IEnumerable<KeyValuePair<TValue, TKey>> first,
            IEnumerable<KeyValuePair<TValue, TKey>> second )
        {
            first.ThrowIfNull( () => first );
            second.ThrowIfNull( () => second );

            return first.Concat( second )
                        .GroupBy( x => x.Key )
                        .ToDictionary( x => x.Key, x => x.First().Value );
        }
    }
}