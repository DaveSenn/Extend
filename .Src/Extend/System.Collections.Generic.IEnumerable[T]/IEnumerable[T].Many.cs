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
        ///     Gets whether the IEnumerable contains more than one item matching the given predicate.
        /// </summary>
        /// <exception cref="ArgumentNullException">The enumerable can not be null.</exception>
        /// <exception cref="ArgumentNullException">The predicate can not be null.</exception>
        /// <typeparam name="T">The type of the items in the IEnumerable.</typeparam>
        /// <param name="enumerable">The IEnumerable.</param>
        /// <param name="predicate">The predicate.</param>
        /// <returns>Returns true if the IEnumerable contains more than one item matching the given predicate, otherwise false.</returns>
        public static Boolean Many<T>( this IEnumerable<T> enumerable, Func<T, Boolean> predicate )
        {
            enumerable.ThrowIfNull(nameof(enumerable));
            predicate.ThrowIfNull(nameof(predicate));

            return enumerable.Count( predicate ) > 1;
        }

        /// <summary>
        ///     Gets whether the IEnumerable contains more than one item.
        /// </summary>
        /// <exception cref="ArgumentNullException">The enumerable can not be null.</exception>
        /// <typeparam name="T">The type of the items in the IEnumerable.</typeparam>
        /// <param name="enumerable">The IEnumerable.</param>
        /// <returns>Returns true if the IEnumerable contains more than one item, otherwise false.</returns>
        public static Boolean Many<T>( this IEnumerable<T> enumerable )
        {
            enumerable.ThrowIfNull(nameof(enumerable));

            return enumerable.Count() > 1;
        }
    }
}