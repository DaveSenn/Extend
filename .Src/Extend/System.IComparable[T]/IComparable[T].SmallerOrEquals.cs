#region Usings

using System;
using JetBrains.Annotations;

#endregion

namespace Extend
{
    /// <summary>
    ///     Class containing some extension methods for <see cref="IComparable" />.
    /// </summary>
    // ReSharper disable once InconsistentNaming
    public static partial class IComparableTEx
    {
        /// <summary>
        ///     Checks if the value is smaller or equals to the given compare value.
        /// </summary>
        /// <exception cref="ArgumentNullException">The value can not be null.</exception>
        /// <exception cref="ArgumentNullException">The compare value can not be null.</exception>
        /// <param name="value">The value to check.</param>
        /// <param name="compareValue">The value to compare with.</param>
        /// <returns>
        ///     Returns true if the value is smaller or equals to the given compare value,
        ///     otherwise false.
        /// </returns>
        [Pure]
        [PublicAPI]
        public static Boolean SmallerOrEquals<T>( [NotNull] this T value, [NotNull] T compareValue ) where T : IComparable<T>
        {
            value.ThrowIfNull( nameof(value) );
            compareValue.ThrowIfNull( nameof(compareValue) );

            return value.CompareTo( compareValue ) <= 0;
        }
    }
}