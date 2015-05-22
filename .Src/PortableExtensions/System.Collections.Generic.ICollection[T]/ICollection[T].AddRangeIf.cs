#region Usings

using System;
using System.Collections.Generic;
using System.Linq;

#endregion

namespace PortableExtensions
{
    /// <summary>
    ///     Class containing some extension methods for <see cref="ICollection{T}" />.
    /// </summary>
    public static partial class CollectionTEx
    {
        /// <summary>
        ///     Adds all given values who satisfies the predicate to the collection.
        /// </summary>
        /// <exception cref="ArgumentNullException">The collection can not be null.</exception>
        /// <exception cref="ArgumentNullException">The predicate can not be null.</exception>
        /// <exception cref="ArgumentNullException">The values can not be null.</exception>
        /// <typeparam name="T">The type of the items in the collection.</typeparam>
        /// <param name="collection">The collection to which the values should get added.</param>
        /// <param name="predicate">The predicate.</param>
        /// <param name="values">The values to add.</param>
        /// <returns>Returns the given collection.</returns>
        public static ICollection<T> AddRangeIf<T>( this ICollection<T> collection,
                                                    Func<T, Boolean> predicate,
                                                    params T[] values )
        {
            collection.ThrowIfNull( () => collection );
            predicate.ThrowIfNull( () => predicate );
            values.ThrowIfNull( () => values );

            values.Where( predicate )
                  .ForEach( collection.Add );
            return collection;
        }

        /// <summary>
        ///     Adds all items of the given IEnumerable who satisfies the predicate to the collection.
        /// </summary>
        /// <exception cref="ArgumentNullException">The collection can not be null.</exception>
        /// <exception cref="ArgumentNullException">The predicate can not be null.</exception>
        /// <exception cref="ArgumentNullException">The enumerable can not be null.</exception>
        /// <typeparam name="T">The type of the items in the collection.</typeparam>
        /// <param name="collection">The collection to which the values should get added.</param>
        /// <param name="predicate">The predicate.</param>
        /// <param name="enumerable">The IEnumerable containing the items.</param>
        /// <returns>Returns the given collection.</returns>
        public static ICollection<T> AddRangeIf<T>( this ICollection<T> collection,
                                                    Func<T, Boolean> predicate,
                                                    IEnumerable<T> enumerable )
        {
            collection.ThrowIfNull( () => collection );
            predicate.ThrowIfNull( () => predicate );
            enumerable.ThrowIfNull( () => enumerable );

            enumerable.Where( predicate )
                      .ForEach( collection.Add );
            return collection;
        }
    }
}