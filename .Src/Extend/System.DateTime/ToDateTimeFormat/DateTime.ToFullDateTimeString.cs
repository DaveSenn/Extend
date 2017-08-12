#region Usings

using System;
using System.Globalization;
using JetBrains.Annotations;

#endregion

namespace Extend
{
    /// <summary>
    ///     Class containing some extension methods for <see cref="DateTime" />.
    /// </summary>
    public static partial class DateTimeEx
    {
        /// <summary>
        ///     Converts the DateTime value to a full date time string.
        /// </summary>
        /// <param name="dateTime">The DateTime value to convert.</param>
        /// <returns>The given value converted to a full date time string.</returns>
        [PublicAPI]
        [Pure]
        [NotNull]
        public static String ToFullDateTimeString( this DateTime dateTime )
            => dateTime.ToString( "F", DateTimeFormatInfo.CurrentInfo );

        /// <summary>
        ///     Converts the DateTime value to a full date time string.
        /// </summary>
        /// <exception cref="ArgumentNullException">The format info can not be null.</exception>
        /// <param name="dateTime">The DateTime value to convert.</param>
        /// <param name="formatInfo">The date time format info.</param>
        /// <returns>The given value converted to a full date time string.</returns>
        [PublicAPI]
        [Pure]
        [NotNull]
        public static String ToFullDateTimeString( this DateTime dateTime, [NotNull] DateTimeFormatInfo formatInfo )
        {
            formatInfo.ThrowIfNull( nameof(formatInfo) );

            return dateTime.ToString( "F", formatInfo );
        }

        /// <summary>
        ///     Converts the DateTime value to a full date time string.
        /// </summary>
        /// <exception cref="ArgumentNullException">The culture can not be null.</exception>
        /// <param name="dateTime">The DateTime value to convert.</param>
        /// <param name="culture">The culture.</param>
        /// <returns>The given value converted to a full date time string.</returns>
        [PublicAPI]
        [Pure]
        [NotNull]
        public static String ToFullDateTimeString( this DateTime dateTime, [NotNull] CultureInfo culture )
        {
            culture.ThrowIfNull( nameof(culture) );

            return dateTime.ToString( "F", culture );
        }
    }
}