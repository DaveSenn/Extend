#region Usings

using System;
using System.Collections.Generic;
using System.Linq;

#endregion

namespace Extend
{
    /// <summary>
    ///     Class containing some extension methods for <see cref="ICollection{T}" />.
    /// </summary>
    public static partial class CollectionTEx
    {
        /// <summary>
        ///     Removes the given values that satisfy the predicate from the collection.
        /// </summary>
        /// <exception cref="ArgumentNullException">The collection can not be null.</exception>
        /// <exception cref="ArgumentNullException">The predicate can not be null.</exception>
        /// <exception cref="ArgumentNullException">The values can not be null.</exception>
        /// <typeparam name="T">The type of the items in the collection.</typeparam>
        /// <param name="collection">The collection, from which the values should get removed.</param>
        /// <param name="predicate">The predicate.</param>
        /// <param name="values">The values to remove.</param>
        /// <returns>Returns the given collection.</returns>
        public static ICollection<T> RemoveRangeIf<T>( this ICollection<T> collection,
                                                       Func<T, Boolean> predicate,
                                                       params T[] values )
        {
            collection.ThrowIfNull( nameof(collection) );
            predicate.ThrowIfNull( nameof(predicate) );
            values.ThrowIfNull( nameof(values) );

            values.Where( predicate )
                  .ForEach( x => collection.Remove( x ) );
            return collection;
        }

        /// <summary>
        ///     Removes the items of the given IEnumerable that satisfy the predicate from the collection.
        /// </summary>
        /// <exception cref="ArgumentNullException">The collection can not be null.</exception>
        /// <exception cref="ArgumentNullException">The predicate can not be null.</exception>
        /// <exception cref="ArgumentNullException">The enumerable can not be null.</exception>
        /// <typeparam name="T">The type of the items in the collection.</typeparam>
        /// <param name="collection">The collection, from which the values should get removed.</param>
        /// <param name="predicate">The predicate.</param>
        /// <param name="enumerable">A IEnumerable containing the items to remove from the collection.</param>
        /// <returns>Returns the given collection.</returns>
        public static ICollection<T> RemoveRangeIf<T>( this ICollection<T> collection,
                                                       Func<T, Boolean> predicate,
                                                       IEnumerable<T> enumerable )
        {
            collection.ThrowIfNull( nameof(collection) );
            predicate.ThrowIfNull( nameof(predicate) );
            enumerable.ThrowIfNull( nameof(enumerable) );

            enumerable.Where( predicate )
                      .ForEach( x => collection.Remove( x ) );
            return collection;
        }
    }
}