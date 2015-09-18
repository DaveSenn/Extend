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
        ///     Gets whether the the IEnumerable contains at least the specified number of items matching the specified predicate.
        /// </summary>
        /// <exception cref="ArgumentNullException">The enumerable can not be null.</exception>
        /// <exception cref="ArgumentNullException">The predicate can not be null.</exception>
        /// <typeparam name="T">The type of the items in the IEnumerable.</typeparam>
        /// <param name="enumerable">The IEnumerable.</param>
        /// <param name="count">The minimum number of items.</param>
        /// <param name="predicate">The predicate.</param>
        /// <returns>
        ///     Returns true if the IEnumerable contains at least the specified number of items matching the specified
        ///     predicate, otherwise false.
        /// </returns>
        public static Boolean MinimumOf<T>( this IEnumerable<T> enumerable, Int32 count, Func<T, Boolean> predicate )
        {
            enumerable.ThrowIfNull( nameof( enumerable ) );
            predicate.ThrowIfNull( nameof( predicate ) );

            return enumerable.Count( predicate ) >= count;
        }

        /// <summary>
        ///     Gets whether the IEnumerable contains at least the specified number of items.
        /// </summary>
        /// <exception cref="ArgumentNullException">The enumerable can not be null.</exception>
        /// <typeparam name="T">The type of the items in the IEnumerable.</typeparam>
        /// <param name="enumerable">The IEnumerable.</param>
        /// <param name="count">The minimum number of items.</param>
        /// <returns>Returns true if the IEnumerable contains at least the specified number of items, otherwise false.</returns>
        public static Boolean MinimumOf<T>( this IEnumerable<T> enumerable, Int32 count )
        {
            enumerable.ThrowIfNull( nameof( enumerable ) );

            return enumerable.Count() >= count;
        }
    }
}