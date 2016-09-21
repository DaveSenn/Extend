#region Usings

using System;
using JetBrains.Annotations;

#endregion

namespace Extend
{
    public static partial class StringEx
    {
        /// <summary>
        ///     Converts the given string to a double.
        /// </summary>
        /// <exception cref="ArgumentNullException">The value can not be null.</exception>
        /// <exception cref="FormatException">value does not represent a number in a valid format.</exception>
        /// <exception cref="OverflowException">
        ///     value represents a number that is less than <see cref="Double.MinValue" /> or
        ///     greater than <see cref="Double.MaxValue" />.
        /// </exception>
        /// <param name="value">The string to convert.</param>
        /// <returns>The double.</returns>
        [Pure]
        [PublicAPI]
        public static Double ToDouble( [NotNull] this String value )
        {
            value.ThrowIfNull( nameof( value ) );

            return Double.Parse( value );
        }

        /// <summary>
        ///     Converts the given string to a double.
        /// </summary>
        /// <exception cref="ArgumentNullException">The value can not be null.</exception>
        /// <exception cref="ArgumentNullException">The format provider can not be null.</exception>
        /// <exception cref="FormatException">value does not represent a number in a valid format.</exception>
        /// <exception cref="OverflowException">
        ///     value represents a number that is less than <see cref="Double.MinValue" /> or
        ///     greater than <see cref="Double.MaxValue" />.
        /// </exception>
        /// <param name="value">The string to convert.</param>
        /// <param name="formatProvider">The format provider.</param>
        /// <returns>The double.</returns>
        [Pure]
        [PublicAPI]
        public static Double ToDouble( [NotNull] this String value, [NotNull] IFormatProvider formatProvider )
        {
            value.ThrowIfNull( nameof( value ) );
            formatProvider.ThrowIfNull( nameof( formatProvider ) );

            return Double.Parse( value, formatProvider );
        }
    }
}