#region Using

using System;
using System.Collections.Generic;
using System.Linq;

#endregion

namespace PortableExtensions
{
    /// <summary>
    ///     Class containing some extension methods for <see cref="IEnumerable{T}" />.
    /// </summary>
    // ReSharper disable once InconsistentNaming
    public static partial class IEnumerableTEx
    {
        /// <summary>
        ///     Checks if the given IEnumerable is not null and contains some items.
        /// </summary>
        /// <exception cref="ArgumentNullException">The enumerable can not be null.</exception>
        /// <typeparam name="T">The type of the items in the IEnumerable.</typeparam>
        /// <param name="enumerable">The IEnumerable to act on.</param>
        /// <returns>Returns true if the IEnumerable is not null or empty, otherwise false.</returns>
        public static Boolean AnyAndNotNull<T>( this IEnumerable<T> enumerable )
        {
            return enumerable != null && enumerable.Any();
        }

        /// <summary>
        ///     Checks if the given IEnumerable is not null and contains some items
        ///     which mates the given predicate.
        /// </summary>
        /// <exception cref="ArgumentNullException">The enumerable can not be null.</exception>
        /// <exception cref="ArgumentNullException">The predicate can not be null.</exception>
        /// <typeparam name="T">The type of the items in the IEnumerable.</typeparam>
        /// <param name="enumerable">The IEnumerable to act on.</param>
        /// <param name="predicate">The predicate.</param>
        /// <returns>Returns true if the IEnumerable is not null or empty, otherwise false.</returns>
        public static Boolean AnyAndNotNull<T>( this IEnumerable<T> enumerable, Func<T, Boolean> predicate )
        {
            predicate.ThrowIfNull( () => predicate );

            return enumerable != null && enumerable.Any( predicate );
        }
    }
}