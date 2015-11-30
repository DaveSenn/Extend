#region Usings

using System.Collections.Generic;
using System.Linq;

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
        /// <typeparam name="T">The type of the items in the given IEnumerable.</typeparam>
        /// <param name="source">The source IEnumerable.</param>
        /// <returns>A sequence of elements paired with their index in the sequence.</returns>
        public static IEnumerable<IIndexedItem<T>> WithIndex<T>( this IEnumerable<T> source )
        {
            return source.Select( ( item, index ) => new IndexedItem<T>( index, item ) );
        }
    }
}