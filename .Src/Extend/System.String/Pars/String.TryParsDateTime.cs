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
        ///     Converts the specified string representation of a date and time to its <see cref="DateTime" /> equivalent and
        ///     returns a value that
        ///     indicates whether the conversion succeeded.
        /// </summary>
        /// <param name="value">A <see cref="String" /> containing a date and time to convert.</param>
        /// <param name="result">
        ///     When this method returns, contains the <see cref="DateTime" /> value equivalent to the date and time contained in
        ///     <paramref name="value" />, if the conversion succeeded, or <see cref="DateTime.MinValue" /> if the conversion
        ///     failed. The conversion fails if the <paramref name="value" />
        ///     parameter is null, is an empty string (""), or does not contain a valid string representation of a date and time.
        ///     This parameter is passed uninitialized.
        /// </param>
        /// <returns>Returns true if the s parameter was converted successfully; otherwise, false.</returns>
        [Pure]
        [PublicAPI]
        public static Boolean TryParsDateTime( [CanBeNull] this String value, out DateTime result )
            => DateTime.TryParse( value, out result );

        /// <summary>
        ///     Converts the specified string representation of a date and time to its <see cref="DateTime" /> equivalent using the
        ///     specified culture-specific format information and formatting style, and returns a value that indicates whether the
        ///     conversion succeeded.
        /// </summary>
        /// <exception cref="ArgumentNullException">The format provider can not be null.</exception>
        /// <exception cref="ArgumentException">
        ///     dateTimeStyle is not a valid <see cref="DateTimeStyles" /> value.-or-styles contains
        ///     an invalid combination of <see cref="DateTimeStyles" /> values (for example, both
        ///     <see cref="DateTimeStyles.AssumeLocal" /> and <see cref="DateTimeStyles.AssumeUniversal" />).
        /// </exception>
        /// <param name="value">A <see cref="String" />containing a date and time to convert.</param>
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
        ///     <paramref name="value" />, if the conversion succeeded, or <see cref="DateTime.MinValue" /> if the conversion
        ///     failed. The conversion fails if the <paramref name="value" /> parameter is
        ///     null, is an empty string (""), or does not contain a valid string representation of a date and time.
        ///     This parameter is passed uninitialized.
        /// </param>
        /// <returns>Returns true if the s parameter was converted successfully; otherwise, false.</returns>
        [Pure]
        [PublicAPI]
        public static Boolean TryParsDateTime( [CanBeNull] this String value,
                                               [NotNull] IFormatProvider formatProvider,
                                               DateTimeStyles dateTimeStyle,
                                               out DateTime result )
        {
            formatProvider.ThrowIfNull( nameof( formatProvider ) );

            return DateTime.TryParse( value, formatProvider, dateTimeStyle, out result );
        }
    }
}