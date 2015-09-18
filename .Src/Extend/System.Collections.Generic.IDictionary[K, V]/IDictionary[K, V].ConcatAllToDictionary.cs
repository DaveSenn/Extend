#region Usings

using System;
using System.Collections.Generic;

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
        /// <exception cref="ArgumentNullException">dictionary can not be null.</exception>
        /// <exception cref="ArgumentNullException">dictionaries can not be null.</exception>
        /// <exception cref="ArgumentException">An element with the same key already exists in the dictionary.</exception>
        /// <typeparam name="TValue">The type of the values.</typeparam>
        /// <typeparam name="TKey">The type of the keys.</typeparam>
        /// <param name="dictionary">The first dictionary to concatenate.</param>
        /// <param name="dictionaries">The other dictionaries to concatenate.</param>
        /// <returns>
        ///     Returns an <see cref="IDictionary{TKey,TValue}" /> that contains the concatenated elements of the given
        ///     sequences.
        /// </returns>
        public static IDictionary<TValue, TKey> ConcatAllToDictionary<TValue, TKey>(
            this IDictionary<TValue, TKey> dictionary,
            params IDictionary<TValue, TKey>[] dictionaries )
        {
            dictionary.ThrowIfNull(nameof(dictionary));
            dictionaries.ThrowIfNull(nameof(dictionaries));

            var result = dictionary;
            dictionaries.ForEach( x =>
            {
                if ( x == null )
                    return;
                x.ForEach( y => result.Add( y.Key, y.Value ) );
            } );

            return result;
        }
    }
}