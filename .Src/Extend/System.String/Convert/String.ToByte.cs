#region Usings

using System;
using System.Globalization;
using JetBrains.Annotations;

#endregion

namespace Extend
{
    public static partial class StringEx
    {
        /// <summary>
        ///     Converts the given string to a byte.
        /// </summary>
        /// <exception cref="ArgumentNullException">The value can not be null.</exception>
        /// <exception cref="FormatException">The value is not of the correct format.</exception>
        /// <exception cref="OverflowException">
        ///     The value represents a number less than System.Byte.MinValue or greater than
        ///     System.Byte.MaxValue.
        /// </exception>
        /// <param name="value">The string to convert.</param>
        /// <returns>Returns a byte value that is equivalent to the number contained in value.</returns>
        [Pure]
        [PublicAPI]
        public static Byte ToByte( [NotNull] this String value )
        {
            value.ThrowIfNull( nameof( value ) );

            return Byte.Parse( value, CultureInfo.CurrentCulture );
        }

        /// <summary>
        ///     Converts the given string to a byte.
        /// </summary>
        /// <exception cref="ArgumentNullException">The value can not be null.</exception>
        /// <exception cref="ArgumentNullException">The format provider can not be null.</exception>
        /// <exception cref="FormatException">The value is not of the correct format.</exception>
        /// <exception cref="OverflowException">
        ///     The value represents a number less than System.Byte.MinValue or greater than
        ///     System.Byte.MaxValue.
        /// </exception>
        /// <param name="value">The string to convert.</param>
        /// <param name="formatProvider">The format provider.</param>
        /// <returns>Returns a byte value that is equivalent to the number contained in value.</returns>
        [Pure]
        [PublicAPI]
        public static Byte ToByte( [NotNull] this String value, [NotNull] IFormatProvider formatProvider )
        {
            value.ThrowIfNull( nameof( value ) );
            formatProvider.ThrowIfNull( nameof( formatProvider ) );

            return Byte.Parse( value, formatProvider );
        }
    }
}