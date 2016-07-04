#region Usings

using System;
using System.Collections.Generic;
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
        ///     Checks if the value is not present in the given array.
        /// </summary>
        /// <exception cref="ArgumentNullException">values can not be null.</exception>
        /// <param name="value">The value to search for.</param>
        /// <param name="values">A IEnumerable containing the values.</param>
        /// <typeparam name="T">The type of the value.</typeparam>
        /// <returns>>Returns true if the value is not present in the array.</returns>
        [Pure]
        [PublicAPI]
        public static Boolean IsNotIn<T>( [CanBeNull] this T value, [NotNull] params T[] values )
            => !IsIn( value, values );

        /// <summary>
        ///     Checks if the value is not present in the given IEnumerable.
        /// </summary>
        /// <exception cref="ArgumentNullException">values can not be null.</exception>
        /// <param name="value">The value to search for.</param>
        /// <param name="values">A IEnumerable containing the values.</param>
        /// <typeparam name="T">The type of the value.</typeparam>
        /// <returns>>Returns true if the value is not present in the IEnumerable.</returns>
        [Pure]
        [PublicAPI]
        public static Boolean IsNotIn<T>( [CanBeNull] this T value, [NotNull] IEnumerable<T> values )
            => !IsIn( value, values );
    }
}