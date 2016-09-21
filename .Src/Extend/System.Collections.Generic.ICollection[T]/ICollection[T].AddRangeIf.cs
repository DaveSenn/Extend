#region Usings

using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;

#endregion

namespace Extend
{
    /// <summary>
    ///     Class containing some extension methods for <see cref="ICollection{T}" />.
    /// </summary>
    public static partial class CollectionTEx
    {
        /// <summary>
        ///     Adds all given values who satisfies the predicate to the collection.
        /// </summary>
        /// <exception cref="ArgumentNullException">collection can not be null.</exception>
        /// <exception cref="ArgumentNullException">predicate can not be null.</exception>
        /// <exception cref="ArgumentNullException">values can not be null.</exception>
        /// <typeparam name="T">The type of the items in the collection.</typeparam>
        /// <param name="collection">The collection to which the values should get added.</param>
        /// <param name="predicate">The predicate.</param>
        /// <param name="values">The values to add.</param>
        /// <returns>Returns the given collection.</returns>
        [PublicAPI]
        [NotNull]
        public static ICollection<T> AddRangeIf<T>( [NotNull] this ICollection<T> collection,
                                                    [NotNull] Func<T, Boolean> predicate,
                                                    [NotNull] params T[] values )
        {
            collection.ThrowIfNull( nameof( collection ) );
            predicate.ThrowIfNull( nameof( predicate ) );
            values.ThrowIfNull( nameof( values ) );

            values
                .Where( predicate )
                .ForEach( collection.Add );
            return collection;
        }

        /// <summary>
        ///     Adds all items of the given IEnumerable who satisfies the predicate to the collection.
        /// </summary>
        /// <exception cref="ArgumentNullException">collection can not be null.</exception>
        /// <exception cref="ArgumentNullException">predicate can not be null.</exception>
        /// <exception cref="ArgumentNullException">enumerable can not be null.</exception>
        /// <typeparam name="T">The type of the items in the collection.</typeparam>
        /// <param name="collection">The collection to which the values should get added.</param>
        /// <param name="predicate">The predicate.</param>
        /// <param name="enumerable">The IEnumerable containing the items.</param>
        /// <returns>Returns the given collection.</returns>
        [PublicAPI]
        [NotNull]
        public static ICollection<T> AddRangeIf<T>( [NotNull] this ICollection<T> collection,
                                                    [NotNull] Func<T, Boolean> predicate,
                                                    [NotNull] IEnumerable<T> enumerable )
        {
            collection.ThrowIfNull( nameof( collection ) );
            predicate.ThrowIfNull( nameof( predicate ) );
            enumerable.ThrowIfNull( nameof( enumerable ) );

            enumerable
                .Where( predicate )
                .ForEach( collection.Add );
            return collection;
        }
    }
}