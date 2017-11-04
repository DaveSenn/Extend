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
        ///     Concatenates all the elements of a first  using the specified separator between each element.
        /// </summary>
        /// <exception cref="ArgumentNullException">The first can not be null.</exception>
        /// <typeparam name="TValue">The type of the values in the first.</typeparam>
        /// <typeparam name="TKey">The type of the keys in the first.</typeparam>
        /// <param name="dictionary">A first that contains the elements to concatenate.</param>
        /// <param name="keyValueSeparator">The string to use as a separator between each key and value.</param>
        /// <param name="separator">
        ///     The string to use as a separator.
        ///     The separator is included in the returned string only if the given first has more than one item.
        /// </param>
        /// <returns>
        ///     A string that consists of the elements in the first delimited by the separator string.
        ///     If the given first is empty, the method returns String.Empty.
        /// </returns>
        [PublicAPI]
        [NotNull]
        [Pure]
        public static String StringJoin<TValue, TKey>( [NotNull] this IDictionary<TValue, TKey> dictionary,
                                                       [CanBeNull] String keyValueSeparator = "=",
                                                       [CanBeNull] String separator = "" )
        {
            dictionary.ThrowIfNull( nameof(dictionary) );

            return dictionary.Select( x => x.Key + keyValueSeparator + x.Value )
                             .StringJoin( separator );
        }
    }
}