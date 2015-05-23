#region Usings

using System;
using System.Globalization;

#endregion

namespace Extend
{
    public static partial class StringEx
    {
        /// <summary>
        ///     Converts the specified string representation of a date and time to its DateTime equivalent using the specified
        ///     format,
        ///     culture-specific format information, and style.
        ///     The format of the string representatiomust match the specified format exactly.
        ///     The method returns a value that indicates whether the conversion succeeded.
        /// </summary>
        /// <exception cref="ArgumentNullException">value can not be null.</exception>
        /// <exception cref="ArgumentNullException">format can not be null.</exception>
        /// <exception cref="ArgumentNullException">format provider can not be null.</exception>
        /// <param name="value">A <see cref="String" /> containing a date and time to convert.</param>
        /// <param name="format">The required format of s. See the Remarks section for more information.</param>
        /// <param name="formatProvider">
        ///     An object that supplies culture-specific formatting information about
        ///     <paramref name="value" />.
        /// </param>
        /// <param name="dateTimeStyle">
        ///     A bitwise combination of one or more enumeration values that indicate the permitted format
        ///     of <paramref name="value" />.
        /// </param>
        /// <param name="outValue">
        ///     When this method returns, contains the s<see cref="DateTime" /> value equivalent to the date and time contained in
        ///     <paramref name="value" />,
        ///     if the conversion succeeded, or <see cref="DateTime.MinValue" /> if the conversion failed.
        ///     The conversion fails if either the s or format parameter is null, is an empty string, or does not contain a date
        ///     and time that correspond to the pattern specified in format.
        ///     This parameter is passed uninitialized.
        /// </param>
        /// <returns>Returns true if the parsing was successful, otherwise false.</returns>
        public static Boolean TryParsDateTimeExact( this String value,
                                                    String format,
                                                    IFormatProvider formatProvider,
                                                    DateTimeStyles dateTimeStyle,
                                                    out DateTime outValue )
        {
            value.ThrowIfNull( () => value );
            format.ThrowIfNull( () => format );
            formatProvider.ThrowIfNull( () => formatProvider );

            return DateTime.TryParseExact( value, format, formatProvider, dateTimeStyle, out outValue );
        }

        /// <summary>
        ///     Converts the specified string representation of a date and time to its <see cref="DateTime" /> equivalent using the
        ///     specified array of formats,
        ///     culture-specific format information, and style. The format of the string representation must match at least one of
        ///     the specified formats exactly.
        ///     The method returns a value that indicates whether the conversion succeeded.
        /// </summary>
        /// <remarks>
        ///     The DateTime.TryParseExact(String, String[], IFormatProvider, DateTimeStyles, DateTime) method parses the string
        ///     representation
        ///     of a date that matches any one of the patterns assigned to the formats parameter.
        ///     It is like the DateTime.ParseExact(String, String[], IFormatProvider, DateTimeStyles) method, except the
        ///     TryParseExact method does not throw an exception if the conversion fails.
        /// </remarks>
        /// <exception cref="ArgumentNullException">value can not be null.</exception>
        /// <exception cref="ArgumentNullException">formats can not be null.</exception>
        /// <exception cref="ArgumentNullException">format provider can not be null.</exception>
        /// <param name="value">A <see cref="String" /> containing a date and time to convert.</param>
        /// <param name="formats">An array of allowable formats of s. See the Remarks section for more information.</param>
        /// <param name="formatProvider">
        ///     An object that supplies culture-specific formatting information about
        ///     <paramref name="value" />.
        /// </param>
        /// <param name="dateTimeStyle">
        ///     A bitwise combination of one or more enumeration values that indicate the permitted format
        ///     of <paramref name="value" />.
        /// </param>
        /// <param name="outValue">
        ///     When this method returns, contains the s<see cref="DateTime" /> value equivalent to the date and time contained in
        ///     <paramref name="value" />,
        ///     if the conversion succeeded, or <see cref="DateTime.MinValue" /> if the conversion failed.
        ///     The conversion fails if either the s or format parameter is null, is an empty string, or does not contain a date
        ///     and time that correspond to the pattern specified in format.
        ///     This parameter is passed uninitialized.
        /// </param>
        /// <returns>Returns true if the parsing was successful, otherwise false.</returns>
        public static Boolean TryParsDateTimeExact( this String value,
                                                    String[] formats,
                                                    IFormatProvider formatProvider,
                                                    DateTimeStyles dateTimeStyle,
                                                    out DateTime outValue )
        {
            value.ThrowIfNull( () => value );
            formats.ThrowIfNull( () => formats );
            formatProvider.ThrowIfNull( () => formatProvider );

            return DateTime.TryParseExact( value, formats, formatProvider, dateTimeStyle, out outValue );
        }
    }
}