#region Usings

using System;
using System.Collections.Generic;

#endregion

namespace Extend
{
    /// <summary>
    ///     Class containing some extension methods for <see cref="IEnumerable{T}" />.
    /// </summary>
    // ReSharper disable once InconsistentNaming
    public static partial class IEnumerableTEx
    {
        /// <summary>
        ///     Converts the given sequence to a new <see cref="HashSet{T}" />.
        /// </summary>
        /// <exception cref="ArgumentNullException">collection can not be null.</exception>
        /// <typeparam name="T">The type of the items in the collection.</typeparam>
        /// <param name="collection">The source collection.</param>
        /// <returns>Returns the new created <see cref="HashSet{T}" />.</returns>
        public static HashSet<T> ToHashSet<T>( this IEnumerable<T> collection )
        {
            collection.ThrowIfNull( nameof(collection) );

            return new HashSet<T>( collection );
        }
    }
}