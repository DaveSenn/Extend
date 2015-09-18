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
        ///     Adds the values of the given dictionary to the dictionary.
        /// </summary>
        /// <exception cref="ArgumentNullException">The dictionary can not be null.</exception>
        /// <exception cref="ArgumentNullException">The other dictionary can not be null.</exception>
        /// <param name="dictionary">The dictionary to add the items to.</param>
        /// <param name="otherDictionary">The dictionary containing the items to add.</param>
        /// <typeparam name="TKey">The type of the keys.</typeparam>
        /// <typeparam name="TValue">The type of the values.</typeparam>
        /// <returns>Returns the dictionary containing all the items..</returns>
        public static IDictionary<TKey, TValue> AddRange<TKey, TValue>( this IDictionary<TKey, TValue> dictionary,
                                                                        IDictionary<TKey, TValue> otherDictionary )
        {
            dictionary.ThrowIfNull( nameof( dictionary ) );
            otherDictionary.ThrowIfNull( nameof( otherDictionary ) );

            otherDictionary.ForEach( x => dictionary.Add( x.Key, x.Value ) );
            return dictionary;
        }
    }
}