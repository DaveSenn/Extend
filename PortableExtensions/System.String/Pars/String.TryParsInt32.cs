#region Using

using System;
using System.Globalization;

#endregion

namespace PortableExtensions
{
    /// <summary>
    ///     Class containing some extension methods for <see cref="string" />.
    /// </summary>
    public static partial class StringEx
    {
        /// <summary>
        ///     Converts the string representation of a number to its 32-bit signed integer
        ///     equivalent. A return value indicates whether the conversion succeeded or
        ///     failed.
        /// </summary>
        /// <exception cref="ArgumentNullException">The value can not be null.</exception>
        /// <param name="value">A string containing a number to convert.</param>
        /// <param name="outValue">
        ///     When this method returns, contains the 32-bit signed integer value equivalent
        ///     to the number contained in s, if the conversion succeeded, or zero if the
        ///     conversion failed. The conversion fails if the s parameter is null or System.String.Empty,
        ///     is not of the correct format, or represents a number less than System.Int32.MinValue
        ///     or greater than System.Int32.MaxValue. This parameter is passed uninitialized.
        /// </param>
        /// <returns>Returns true if the parsing was successful, otherwise false.</returns>
        public static Boolean TryParsInt32( this String value, out Int32 outValue )
        {
            value.ThrowIfNull( () => value );

            return Int32.TryParse( value, NumberStyles.Any, CultureInfo.InvariantCulture, out outValue );
        }

        /// <summary>
        ///     Converts the string representation of a number in a specified numberStyles and culture-specific
        ///     format to its 32-bit signed integer equivalent. A return value indicates
        ///     whether the conversion succeeded or failed.
        /// </summary>
        /// <param name="value">
        ///     A string containing a number to convert. The string is interpreted using
        /// </param>
        /// <param name="numberStyles">
        ///     A bitwise combination of enumeration values that indicates the numberStyles elements
        ///     that can be present in value. A typical value to specify is <see cref="NumberStyles.Integer"/>.
        /// </param>
        /// <param name="formatProvider">An object that supplies culture-specific formatting information about value.</param>
        /// <param name="outValue">
        ///     When this method returns, contains the 32-bit signed integer value equivalent
        ///     to the number contained in s, if the conversion succeeded, or zero if the
        ///     conversion failed. The conversion fails if the s parameter is null or System.String.Empty,
        ///     is not in a format compliant with numberStyles, or represents a number less than
        ///     System.Int32.MinValue or greater than System.Int32.MaxValue. This parameter
        ///     is passed uninitialized.
        /// </param>
        /// <returns>Returns true if the parsing was successful, otherwise false.</returns>
        public static Boolean TryParsInt32( this String value, NumberStyles numberStyles, IFormatProvider formatProvider,
                                            out Int32 outValue )
        {
            value.ThrowIfNull( () => value );
            formatProvider.ThrowIfNull( () => formatProvider );

            return Int32.TryParse( value, numberStyles, formatProvider, out outValue );
        }
    }
}