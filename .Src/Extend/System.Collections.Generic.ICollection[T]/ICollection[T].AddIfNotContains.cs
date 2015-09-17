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
        ///     Adds the given value to the collection if the collection doesn't contains it already.
        /// </summary>
        /// <exception cref="ArgumentNullException">The collection can not be null.</exception>
        /// <typeparam name="T">The type of the items in the collection.</typeparam>
        /// <param name="collection">The collection to which the item should get added.</param>
        /// <param name="value">The value. to add</param>
        /// <returns>True if the value was added to the collection, otherwise false.</returns>
        public static Boolean AddIfNotContains<T>( this ICollection<T> collection, T value )
        {
            collection.ThrowIfNull( nameof(collection) );

            if ( collection.Contains( value ) )
                return false;

            collection.Add( value );
            return true;
        }
    }
}