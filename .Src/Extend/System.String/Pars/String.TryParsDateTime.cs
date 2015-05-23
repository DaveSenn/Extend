#region Usings

using System;
using System.Globalization;

#endregion

namespace PortableExtensions
{
    public static partial class StringEx
    {
        /// <summary>
        ///     Converts the specified string representation of a date and time to its <see cref="DateTime" /> equivalent and
        ///     returns a value that
        ///     indicates whether the conversion succeeded.
        /// </summary>
        /// <exception cref="ArgumentNullException">value can not be null.</exception>
        /// <param name="value">A <see cref="String" /> containing a date and time to convert.</param>
        /// <param name="result">
        ///     When this method returns, contains the <see cref="DateTime" /> value equivalent to the date and time contained in
        ///     <paramref name="value" />, if the conversion succeeded, or
        ///     <see cref="DateTime.MinValue" /> if the conversion failed. The conversion fails if the <paramref name="value" />
        ///     parameter is
        ///     <value>null</value>
        ///     , is an empty string (""),
        ///     or does not contain a valid string representation of a date and time. This parameter is passed uninitialized.
        /// </param>
        /// <returns>
        ///     <value>true</value>
        ///     if the s parameter was converted successfully; otherwise,
        ///     <value>false</value>
        ///     .
        /// </returns>
        public static Boolean TryParsDateTime( this String value, out DateTime result )
        {
            value.ThrowIfNull( () => value );

            return DateTime.TryParse( value, CultureInfo.InvariantCulture, DateTimeStyles.None, out result );
        }

        /// <summary>
        ///     Converts the specified string representation of a date and time to its <see cref="DateTime" /> equivalent using the
        ///     specified culture-specific format information and formatting style, and returns a value that indicates whether the
        ///     conversion succeeded.
        /// </summary>
        /// <exception cref="ArgumentNullException">The value can not be null.</exception>
        /// <exception cref="ArgumentNullException">The format provider can not be null.</exception>
        /// <param name="value">A <see cref="String" /> containing a date and time to convert.</param>
        /// <param name="formatProvider">
        ///     An object that supplies culture-specific formatting information about
        ///     <paramref name="value" />.
        /// </param>
        /// <param name="dateTimeStyle">
        ///     A bitwise combination of enumeration values that defines how to interpret the parsed date in relation to the
        ///     current time zone or the current date.
        ///     A typical value to specify is <see cref="DateTimeStyles.None" />.
        /// </param>
        /// <param name="result">
        ///     When this method returns, contains the <see cref="DateTime" /> value equivalent to the date and time contained in
        ///     <paramref name="value" />, if the conversion succeeded, or
        ///     <see cref="DateTime.MinValue" /> if the conversion failed. The conversion fails if the <paramref name="value" />
        ///     parameter is
        ///     <value>null</value>
        ///     , is an empty string (""),
        ///     or does not contain a valid string representation of a date and time. This parameter is passed uninitialized.
        /// </param>
        /// <returns>
        ///     <value>true</value>
        ///     if the s parameter was converted successfully; otherwise,
        ///     <value>false</value>
        ///     .
        /// </returns>
        public static Boolean TryParsDateTime( this String value,
                                               IFormatProvider formatProvider,
                                               DateTimeStyles dateTimeStyle,
                                               out DateTime result )
        {
            value.ThrowIfNull( () => value );
            formatProvider.ThrowIfNull( () => formatProvider );

            return DateTime.TryParse( value, formatProvider, dateTimeStyle, out result );
        }
    }
}