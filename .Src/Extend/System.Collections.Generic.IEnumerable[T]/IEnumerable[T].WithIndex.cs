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
        ///     Associates an index to each element of the source IEnumerable.
        /// </summary>
        /// <exception cref="ArgumentNullException">source can not be null.</exception>
        /// <typeparam name="T">The type of the items in the given IEnumerable.</typeparam>
        /// <param name="source">The source IEnumerable.</param>
        /// <returns>A sequence of elements paired with their index in the sequence.</returns>
        [Pure]
        [PublicAPI]
        [NotNull]
        public static IEnumerable<IIndexedItem<T>> WithIndex<T>( [NotNull] [ItemCanBeNull] this IEnumerable<T> source )
        {
            source.ThrowIfNull( nameof(source) );

            return source.Select( ( item, index ) => new IndexedItem<T>( index, item ) );
        }
    }
}