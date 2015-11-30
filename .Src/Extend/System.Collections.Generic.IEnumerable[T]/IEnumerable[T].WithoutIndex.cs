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
        ///     Removes the indexes from a IEnumerable of indexed elements, returning only the elements themselves.
        /// </summary>
        /// <typeparam name="T">The type of the items in the given IEnumerable.</typeparam>
        /// <param name="source">The IEnumerable to remove the indexes from.</param>
        /// <returns>A IEnumerable of elements without their associated indexes.</returns>
        public static IEnumerable<T> WithoutIndex<T>( this IEnumerable<IIndexedItem<T>> source )
        {
            return source.Select( indexed => indexed.Item );
        }
    }
}