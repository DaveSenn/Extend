#region Usings

using System;

#endregion

namespace Extend
{
    /// <summary>
    ///     Class containing some extension methods for <see cref="IComparable{T}" />.
    /// </summary>
    // ReSharper disable once InconsistentNaming
    public static partial class IComparableTEx
    {
        /// <summary>
        ///     Checks if the given value is between (inclusive) the minValue and maxValue.
        /// </summary>
        /// <exception cref="ArgumentNullException">The value can not be null.</exception>
        /// <exception cref="ArgumentNullException">The min value can not be null.</exception>
        /// <exception cref="ArgumentNullException">The max value can not be null.</exception>
        /// <typeparam name="T">The type of the values to compare.</typeparam>
        /// <param name="value">The value to check.</param>
        /// <param name="minValue">The minimum value.</param>
        /// <param name="maxValue">The maximum value.</param>
        /// <returns>Returns true if the given value is between the minValue and maxValue, otherwise false.</returns>
        public static Boolean BetweenInclusive<T>( this T value, T minValue, T maxValue ) where T : IComparable<T>
        {
            value.ThrowIfNull(nameof(value));
            minValue.ThrowIfNull(nameof(minValue));
            maxValue.ThrowIfNull(nameof(maxValue));

            return value.CompareTo( minValue ) >= 0 && value.CompareTo( maxValue ) <= 0;
        }
    }
}