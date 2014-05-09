#region Using

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
        ///     Checks if the collection contains any of the given values.
        /// </summary>
        /// <exception cref="ArgumentNullException">The collection can not be null.</exception>
        /// <exception cref="ArgumentNullException">The values can not be null.</exception>
        /// <typeparam name="T">The type of the items in the collection.</typeparam>
        /// <param name="collection">The collection to check.</param>
        /// <param name="values">A list of values.</param>
        /// <returns>Returns true if the collection contains any of the given values, otherwise false.</returns>
        public static Boolean ContainsAny<T>( this ICollection<T> collection, params T[] values )
        {
            collection.ThrowIfNull( () => collection );
            values.ThrowIfNull( () => values );

            return collection.Any( values.Contains );
        }
    }
}