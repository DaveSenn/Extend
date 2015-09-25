#region Usings

using System;
using System.Globalization;

#endregion

namespace Extend
{
    public static partial class StringEx
    {
        /// <summary>
        ///     Converts the string representation of a number to its System.Decimal equivalent.
        ///     A return value indicates whether the conversion succeeded or failed.
        /// </summary>
        /// <exception cref="ArgumentNullException">The value can not be null.</exception>
        /// <param name="value">The string representation of the number to convert.</param>
        /// <param name="outValue">
        ///     The parsed value.
        ///     When this method returns, contains the System.Decimal number that is equivalent
        ///     to the numeric value contained in s, if the conversion succeeded, or is zero
        ///     if the conversion failed. The conversion fails if the s parameter is null
        ///     or System.String.Empty, is not a number in a valid format, or represents
        ///     a number less than System.Decimal.MinValue or greater than System.Decimal.MaxValue.
        ///     This parameter is passed uninitialized.
        /// </param>
        /// <returns>Returns true if the parsing was successful, otherwise false.</returns>
        public static Boolean TryParsDecimal( this String value, out Decimal outValue )
        {
            value.ThrowIfNull(nameof(value));

            return Decimal.TryParse( value, NumberStyles.Any, CultureInfo.InvariantCulture, out outValue );
        }

        /// <summary>
        ///     Converts the string representation of a number to its System.Decimal equivalent
        ///     using the specified numberStyle and culture-specific format. A return value indicates
        ///     whether the conversion succeeded or failed.
        /// </summary>
        /// <param name="value">The string representation of the number to convert.</param>
        /// <param name="numberStyle">
        ///     A bitwise combination of enumeration values that indicates the permitted
        ///     format of value. A typical value to specify is System.Globalization.NumberStyles.Number.
        /// </param>
        /// <param name="formatProvider">An object that supplies culture-specific parsing information about value.</param>
        /// <param name="outValue">
        ///     When this method returns, contains the System.Decimal number that is equivalent
        ///     to the numeric value contained in s, if the conversion succeeded, or is zero
        ///     if the conversion failed. The conversion fails if the s parameter is null
        ///     or System.String.Empty, is not in a format compliant with numberStyle, or represents
        ///     a number less than System.Decimal.MinValue or greater than System.Decimal.MaxValue.
        ///     This parameter is passed uninitialized.
        /// </param>
        /// <returns>Returns true if the parsing was successful, otherwise false.</returns>
        public static Boolean TryParsDecimal( this String value,
                                              NumberStyles numberStyle,
                                              IFormatProvider formatProvider,
                                              out Decimal outValue )
        {
            value.ThrowIfNull(nameof(value));
            formatProvider.ThrowIfNull(nameof(formatProvider));

            return Decimal.TryParse( value, NumberStyles.Any, CultureInfo.InvariantCulture, out outValue );
        }
    }
}