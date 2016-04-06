#region Usings

using System;
using JetBrains.Annotations;

#endregion

namespace Extend
{
    public static partial class StringEx
    {
        /// <summary>
        ///     Converts the given string to a decimal.
        /// </summary>
        /// <exception cref="ArgumentNullException">The value can not be null.</exception>
        /// <exception cref="FormatException">The value is not in the correct format.</exception>
        /// <exception cref="OverflowException">
        ///     value represents a number less than <see cref="Decimal.MinValue" /> or greater than
        ///     <see cref="Decimal.MaxValue" />.
        /// </exception>
        /// <param name="value">The string to convert.</param>
        /// <returns>The decimal.</returns>
        [Pure]
        [PublicAPI]
        public static Decimal ToDecimal( [NotNull] this String value )
        {
            value.ThrowIfNull( nameof( value ) );

            return Decimal.Parse( value );
        }

        /// <summary>
        ///     Converts the given string to a decimal.
        /// </summary>
        /// <exception cref="ArgumentNullException">The value can not be null.</exception>
        /// <exception cref="ArgumentNullException">The format provider can not be null.</exception>
        /// <exception cref="FormatException">The value is not in the correct format.</exception>
        /// <exception cref="OverflowException">
        ///     value represents a number less than <see cref="Decimal.MinValue" /> or greater than
        ///     <see cref="Decimal.MaxValue" />.
        /// </exception>
        /// <param name="value">The string to convert.</param>
        /// <param name="formatProvider">The format provider.</param>
        /// <returns>The decimal.</returns>
        [Pure]
        [PublicAPI]
        public static Decimal ToDecimal( [NotNull] this String value, [NotNull] IFormatProvider formatProvider )
        {
            value.ThrowIfNull( nameof( value ) );
            formatProvider.ThrowIfNull( nameof( formatProvider ) );

            return Decimal.Parse( value, formatProvider );
        }
    }
}