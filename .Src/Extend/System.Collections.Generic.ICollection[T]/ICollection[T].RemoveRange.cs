#region Usings

using System;
using System.Collections.Generic;

#endregion

namespace Extend
{
    /// <summary>
    ///     Class containing some extension methods for <see cref="ICollection{T}" />.
    /// </summary>
    public static partial class CollectionTEx
    {
        /// <summary>
        ///     Removes the given values from the collection.
        /// </summary>
        /// <exception cref="ArgumentNullException">The collection can not be null.</exception>
        /// <exception cref="ArgumentNullException">The values can not be null.</exception>
        /// <typeparam name="T">The type of the items in the collection.</typeparam>
        /// <param name="collection">The collection, from which the values should get removed.</param>
        /// <param name="values">The values to remove.</param>
        /// <returns>Returns the given collection.</returns>
        public static ICollection<T> RemoveRange<T>( this ICollection<T> collection, params T[] values )
        {
            collection.ThrowIfNull( () => collection );
            values.ThrowIfNull( () => values );

            values.ForEach( x => collection.Remove( x ) );
            return collection;
        }

        /// <summary>
        ///     Removes the given values from the collection.
        /// </summary>
        /// <exception cref="ArgumentNullException">The collection can not be null.</exception>
        /// <exception cref="ArgumentNullException">The enumerable can not be null.</exception>
        /// <typeparam name="T">The type of the items in the collection.</typeparam>
        /// <param name="collection">The collection, from which the values should get removed.</param>
        /// <param name="enumerable">A IEnumerable containing the items to remove from the collection.</param>
        /// <returns>Returns the given collection.</returns>
        public static ICollection<T> RemoveRange<T>( this ICollection<T> collection, IEnumerable<T> enumerable )
        {
            collection.ThrowIfNull( () => collection );
            enumerable.ThrowIfNull( () => enumerable );

            enumerable.ForEach( x => collection.Remove( x ) );
            return collection;
        }
    }
}