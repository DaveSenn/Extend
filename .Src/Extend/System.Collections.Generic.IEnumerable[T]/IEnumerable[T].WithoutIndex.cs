#region Usings

using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;

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
        ///     Removes the indexes from a IEnumerable of indexed elements, returning only the elements themselves.
        /// </summary>
        /// <exception cref="ArgumentNullException">source can not be null.</exception>
        /// <typeparam name="T">The type of the items in the given IEnumerable.</typeparam>
        /// <param name="source">The IEnumerable to remove the indexes from.</param>
        /// <returns>A IEnumerable of elements without their associated indexes.</returns>
        [Pure]
        [PublicAPI]
        [NotNull]
        public static IEnumerable<T> WithoutIndex<T>( [NotNull] [ItemNotNull] this IEnumerable<IIndexedItem<T>> source )
        {
            source.ThrowIfNull( nameof( source ) );

            return source.Select( indexed => indexed.Item );
        }
    }
}