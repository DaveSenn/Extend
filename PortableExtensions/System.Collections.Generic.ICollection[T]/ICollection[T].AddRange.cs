#region Usings

using System;
using System.Collections.Generic;

#endregion

namespace PortableExtensions
{
    /// <summary>
    ///     Class containing some extension methods for <see cref="ICollection{T}" />.
    /// </summary>
    public static partial class CollectionTEx
    {
        /// <summary>
        ///     Adds the given range of values to the collection.
        /// </summary>
        /// <exception cref="ArgumentNullException">The collection can not be null.</exception>
        /// <exception cref="ArgumentNullException">The values can not be null.</exception>
        /// <typeparam name="T">The type of the items in the collection.</typeparam>
        /// <param name="collection">The collection to which the values should get added.</param>
        /// <param name="values">The values to add.</param>
        /// <returns>Returns the given collection.</returns>
        public static ICollection<T> AddRange<T> ( this ICollection<T> collection, params T[] values )
        {
            collection.ThrowIfNull( () => collection );
            values.ThrowIfNull( () => values );

            values.ForEach( collection.Add );
            return collection;
        }

        /// <summary>
        ///     Adds the items of the given IEnumerable to the collection.
        /// </summary>
        /// <exception cref="ArgumentNullException">The collection can not be null.</exception>
        /// <exception cref="ArgumentNullException">The enumerable can not be null.</exception>
        /// <typeparam name="T">The type of the items in the collection.</typeparam>
        /// <param name="collection">The collection to which the values should get added.</param>
        /// <param name="enumerable">The IEnumerable containing the items.</param>
        /// <returns>Returns the given collection.</returns>
        public static ICollection<T> AddRange<T> ( this ICollection<T> collection, IEnumerable<T> enumerable )
        {
            collection.ThrowIfNull( () => collection );
            enumerable.ThrowIfNull( () => enumerable );

            enumerable.ForEach( collection.Add );
            return collection;
        }
    }
}