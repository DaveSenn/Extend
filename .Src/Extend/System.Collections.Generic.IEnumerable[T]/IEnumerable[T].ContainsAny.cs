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
        ///     Checks if the IEnumerable contains any of the given values.
        /// </summary>
        /// <exception cref="ArgumentNullException">The enumerable can not be null.</exception>
        /// <exception cref="ArgumentNullException">The values can not be null.</exception>
        /// <typeparam name="T">The type of the items in the IEnumerable.</typeparam>
        /// <param name="enumerable">The IEnumerable to act on.</param>
        /// <param name="values">The values to search for.</param>
        /// <returns>Returns true if the IEnumerable contains any of the given values, otherwise false.</returns>
        public static Boolean ContainsAny<T>( this IEnumerable<T> enumerable, params T[] values )
        {
            enumerable.ThrowIfNull(nameof(enumerable));
            values.ThrowIfNull(nameof(values));

            return values.Any( enumerable.Contains );
        }

        /// <summary>
        ///     Checks if the IEnumerable contains any of the values of the given IEnumerable.
        /// </summary>
        /// <exception cref="ArgumentNullException">The enumerable can not be null.</exception>
        /// <exception cref="ArgumentNullException">The values can not be null.</exception>
        /// <typeparam name="T">The type of the items in the IEnumerable.</typeparam>
        /// <param name="enumerable">The IEnumerable to act on.</param>
        /// <param name="values">The IEnumerable containing the values to search for.</param>
        /// <returns>
        ///     Returns true if the IEnumerable contains any of the values of the given IEnumerable,
        ///     otherwise false.
        /// </returns>
        public static Boolean ContainsAny<T>( this IEnumerable<T> enumerable, IEnumerable<T> values )
        {
            enumerable.ThrowIfNull(nameof(enumerable));
            values.ThrowIfNull(nameof(values));

            return values.Any( enumerable.Contains );
        }
    }
}