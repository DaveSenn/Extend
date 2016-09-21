#region Usings

using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;

#endregion

namespace Extend
{
    /// <summary>
    ///     Class containing some extension methods for <see cref="object" />.
    /// </summary>
    public static partial class ObjectEx
    {
        /// <summary>
        ///     Checks if the value is present in the given array.
        /// </summary>
        /// <exception cref="ArgumentNullException">The values can not be null.</exception>
        /// <param name="value">The value to search for.</param>
        /// <param name="values">A IEnumerable containing the values.</param>
        /// <typeparam name="T">The type of the value.</typeparam>
        /// <returns>>Returns true if the value is present in the array.</returns>
        [Pure]
        [PublicAPI]
        public static Boolean IsIn<T>( [CanBeNull] this T value, [NotNull] params T[] values )
        {
            values.ThrowIfNull( nameof( values ) );

            return Array.IndexOf( values, value ) != -1;
        }

        /// <summary>
        ///     Checks if the value is present in the given IEnumerable.
        /// </summary>
        /// <exception cref="ArgumentNullException">The values can not be null.</exception>
        /// <param name="value">The value to search for.</param>
        /// <param name="values">A IEnumerable containing the values.</param>
        /// <typeparam name="T">The type of the value.</typeparam>
        /// <returns>>Returns true if the value is present in the IEnumerable.</returns>
        [Pure]
        [PublicAPI]
        public static Boolean IsIn<T>( [CanBeNull] this T value, [NotNull] IEnumerable<T> values )
        {
            values.ThrowIfNull( nameof( values ) );

            return values.Contains( value );
        }
    }
}