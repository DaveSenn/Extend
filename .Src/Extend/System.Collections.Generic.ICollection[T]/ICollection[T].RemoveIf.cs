#region Usings

using System;
using System.Collections.Generic;
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
        ///     Removes the given value from the collection, if it matches the predicate.
        /// </summary>
        /// <exception cref="ArgumentNullException">collection can not be null.</exception>
        /// <exception cref="ArgumentNullException">predicate can not be null.</exception>
        /// <typeparam name="T">The type of the items in the collection.</typeparam>
        /// <param name="collection">The collection to act on.</param>
        /// <param name="value">The value to remove.</param>
        /// <param name="predicate">The predicate.</param>
        /// <returns>Returns the given collection.</returns>
        [PublicAPI]
        [NotNull]
        public static ICollection<T> RemoveIf<T>( [NotNull] this ICollection<T> collection, [CanBeNull] T value, [NotNull] Func<T, Boolean> predicate )
        {
            collection.ThrowIfNull( nameof(collection) );
            predicate.ThrowIfNull( nameof(predicate) );

            if ( predicate( value ) )
                collection.Remove( value );
            return collection;
        }
    }
}