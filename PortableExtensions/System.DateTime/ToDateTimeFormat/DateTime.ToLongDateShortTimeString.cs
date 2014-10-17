#region Usings

using System;
using System.Globalization;

#endregion

namespace PortableExtensions
{
    /// <summary>
    ///     Class containing some extension methods for <see cref="DateTime" />.
    /// </summary>
    public static partial class DateTimeEx
    {
        /// <summary>
        ///     Converts the DateTime value to a long date short time string.
        /// </summary>
        /// <param name="dateTime">The DateTime value to convert.</param>
        /// <returns>The given value converted to a long date short time string.</returns>
        public static String ToLongDateShortTimeString ( this DateTime dateTime )
        {
            return dateTime.ToString( "f", DateTimeFormatInfo.CurrentInfo );
        }

        /// <summary>
        ///     Converts the DateTime value to a long date short time string.
        /// </summary>
        /// <exception cref="ArgumentNullException">The format info can not be null.</exception>
        /// <param name="dateTime">The DateTime value to convert.</param>
        /// <param name="formatInfo">The date time format info.</param>
        /// <returns>The given value converted to a long date short time string.</returns>
        public static String ToLongDateShortTimeString ( this DateTime dateTime, DateTimeFormatInfo formatInfo )
        {
            formatInfo.ThrowIfNull( () => formatInfo );

            return dateTime.ToString( "f", formatInfo );
        }

        /// <summary>
        ///     Converts the DateTime value to a long date short time string.
        /// </summary>
        /// <exception cref="ArgumentNullException">The culture can not be null.</exception>
        /// <param name="dateTime">The DateTime value to convert.</param>
        /// <param name="culture">The culture.</param>
        /// <returns>The given value converted to a long date short time string.</returns>
        public static String ToLongDateShortTimeString ( this DateTime dateTime, CultureInfo culture )
        {
            culture.ThrowIfNull( () => culture );

            return dateTime.ToString( "f", culture );
        }
    }
}