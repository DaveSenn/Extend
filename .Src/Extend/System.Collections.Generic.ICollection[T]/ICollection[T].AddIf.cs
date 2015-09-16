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
        ///     Adds the specified value to the given value it it satisfies the predicated provided.
        /// </summary>
        /// <exception cref="ArgumentNullException">The collection can not be null.</exception>
        /// <exception cref="ArgumentNullException">The predicate can not be null.</exception>
        /// <typeparam name="T">The type of the items in the given collection..</typeparam>
        /// <param name="collection">The collection to which the item should get added.</param>
        /// <param name="predicate">The predicate.</param>
        /// <param name="value">The value to add.</param>
        /// <returns>True if the value was added to the collection, otherwise false.</returns>
        public static Boolean AddIf<T>( this ICollection<T> collection, Func<T, Boolean> predicate, T value )
        {
            collection.ThrowIfNull( nameof(collection) );
            predicate.ThrowIfNull(nameof(predicate));

            if ( !predicate( value ) )
                return false;

            collection.Add( value );
            return true;
        }
    }
}