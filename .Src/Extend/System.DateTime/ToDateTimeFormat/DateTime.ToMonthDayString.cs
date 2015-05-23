#region Usings

using System;
using System.Globalization;

#endregion

namespace Extend
{
    /// <summary>
    ///     Class containing some extension methods for <see cref="DateTime" />.
    /// </summary>
    public static partial class DateTimeEx
    {
        /// <summary>
        ///     Converts the DateTime value to a month day string.
        /// </summary>
        /// <param name="dateTime">The DateTime value to convert.</param>
        /// <returns>The given value converted to a month day string.</returns>
        public static String ToMonthDayString( this DateTime dateTime )
        {
            return dateTime.ToString( "m", DateTimeFormatInfo.CurrentInfo );
        }

        /// <summary>
        ///     Converts the DateTime value to a month day string.
        /// </summary>
        /// <exception cref="ArgumentNullException">The format info can not be null.</exception>
        /// <param name="dateTime">The DateTime value to convert.</param>
        /// <param name="formatInfo">The date time format info.</param>
        /// <returns>The given value converted to a month day string.</returns>
        public static String ToMonthDayString( this DateTime dateTime, DateTimeFormatInfo formatInfo )
        {
            formatInfo.ThrowIfNull( () => formatInfo );

            return dateTime.ToString( "m", formatInfo );
        }

        /// <summary>
        ///     Converts the DateTime value to a month day string.
        /// </summary>
        /// <exception cref="ArgumentNullException">The culture can not be null.</exception>
        /// <param name="dateTime">The DateTime value to convert.</param>
        /// <param name="culture">The culture.</param>
        /// <returns>The given value converted to a month day string.</returns>
        public static String ToMonthDayString( this DateTime dateTime, CultureInfo culture )
        {
            culture.ThrowIfNull( () => culture );

            return dateTime.ToString( "m", culture );
        }
    }
}