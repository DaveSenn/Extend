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
        ///     Removes the given value from the collection, if it matches the predicate.
        /// </summary>
        /// <exception cref="ArgumentNullException">The collection can not be null.</exception>
        /// <exception cref="ArgumentNullException">The predicate can not be null.</exception>
        /// <typeparam name="T">The type of the items in the collection.</typeparam>
        /// <param name="collection">The collection to act on.</param>
        /// <param name="value">The value to remove.</param>
        /// <param name="predicate">The predicate.</param>
        /// <returns>Returns the given collection.</returns>
        public static ICollection<T> RemoveIf<T>( this ICollection<T> collection, T value, Func<T, Boolean> predicate )
        {
            collection.ThrowIfNull( () => collection );
            predicate.ThrowIfNull( () => predicate );

            if ( predicate( value ) )
                collection.Remove( value );
            return collection;
        }
    }
}