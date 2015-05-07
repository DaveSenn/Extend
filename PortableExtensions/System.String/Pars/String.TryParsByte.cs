#region Usings

using System;
using System.Globalization;

#endregion

namespace PortableExtensions
{
    public static partial class StringEx
    {
        /// <summary>
        ///     Tries to convert the string representation of a number to its System.Byte
        ///     equivalent, and returns a value that indicates whether the conversion succeeded.
        /// </summary>
        /// <exception cref="ArgumentNullException">The value can not be null.</exception>
        /// <param name="value">
        ///     A string that contains a number to convert. The string is interpreted using
        ///     the System.Globalization.NumberStyles.Integer numberStyle.
        ///     The string to pars.
        /// </param>
        /// <param name="outValue">
        ///     The parsed value.
        ///     When this method returns, contains the System.Byte value equivalent to the
        ///     number contained in s if the conversion succeeded, or zero if the conversion
        ///     failed. This parameter is passed uninitialized.
        /// </param>
        /// <returns>Returns true if the parsing was successful, otherwise false.</returns>
        public static Boolean TryParsByte( this String value, out Byte outValue )
        {
            value.ThrowIfNull( () => value );

            return Byte.TryParse( value, NumberStyles.Any, CultureInfo.InvariantCulture, out outValue );
        }

        /// <summary>
        ///     Converts the string representation of a number in a specified numberStyle and culture-specific
        ///     format to its System.Byte equivalent. A return value indicates whether the
        ///     conversion succeeded or failed.
        /// </summary>
        /// <param name="value">
        ///     A string containing a number to convert. The string is interpreted using
        ///     the numberStyle specified by numberStyle.
        /// </param>
        /// <param name="numberStyle">
        ///     A bitwise combination of enumeration values that indicates the numberStyle elements
        ///     that can be present in s. A typical value to specify is System.Globalization.NumberStyles.Integer.
        /// </param>
        /// <param name="formatProvider">
        ///     An object that supplies culture-specific formatting information about s.
        ///     If formatProvider is null, the thread current culture is used.
        /// </param>
        /// <param name="outValue">
        ///     When this method returns, contains the 8-bit unsigned integer value equivalent
        ///     to the number contained in s if the conversion succeeded, or zero if the
        ///     conversion failed. The conversion fails if the s parameter is null or System.String.Empty,
        ///     is not of the correct format, or represents a number less than System.Byte.MinValue
        ///     or greater than System.Byte.MaxValue. This parameter is passed uninitialized.
        /// </param>
        /// <returns>Returns true if the parsing was successful, otherwise false.</returns>
        public static Boolean TryParsByte( this String value,
                                           NumberStyles numberStyle,
                                           IFormatProvider formatProvider,
                                           out Byte outValue )
        {
            value.ThrowIfNull( () => value );
            formatProvider.ThrowIfNull( () => formatProvider );

            return Byte.TryParse( value, numberStyle, formatProvider, out outValue );
        }
    }
}