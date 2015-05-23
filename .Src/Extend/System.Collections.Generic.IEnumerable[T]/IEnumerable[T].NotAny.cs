#region Usings

using System;
using System.Collections.Generic;
using System.Linq;

#endregion

namespace Extend
{
    /// <summary>
    ///     Class containing some extension methods for <see cref="IEnumerable{T}" />.
    /// </summary>
    // ReSharper disable once InconsistentNaming
    public static partial class IEnumerableTEx
    {
        /// <summary>
        ///     Determines whether the given IEnumerable contains no items, or not.
        /// </summary>
        /// <exception cref="ArgumentNullException">The enumerable can not be null.</exception>
        /// <param name="enumerable">The IEnumerable to check.</param>
        /// <typeparam name="T">The type of the items in the IEnumerable.</typeparam>
        /// <returns>Returns true if the IEnumerable doesn't contain any items, otherwise false.</returns>
        public static Boolean NotAny<T>( this IEnumerable<T> enumerable )
        {
            enumerable.ThrowIfNull( () => enumerable );

            return !enumerable.Any();
        }

        /// <summary>
        ///     Determines whether the given IEnumerable contains no items matching the given predicate, or not.
        /// </summary>
        /// <exception cref="ArgumentNullException">The enumerable can not be null.</exception>
        /// <exception cref="ArgumentNullException">The predicate can not be null.</exception>
        /// <param name="enumerable">The IEnumerable to check.</param>
        /// <param name="predicate">The predicate.</param>
        /// <typeparam name="T">The type of the items in the IEnumerable.</typeparam>
        /// <returns>Returns true if the IEnumerable doesn't contain any items, otherwise false.</returns>
        public static Boolean NotAny<T>( this IEnumerable<T> enumerable, Func<T, Boolean> predicate )
        {
            enumerable.ThrowIfNull( () => enumerable );
            predicate.ThrowIfNull( () => predicate );

            return !enumerable.Any( predicate );
        }
    }
}