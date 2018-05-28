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
        ///     Converts the specified string representation of a date and time to its <see cref="DateTime" /> equivalent.
        /// </summary>
        /// <param name="value">A <see cref="String" /> containing a date and time to convert.</param>
        /// <param name="defaultValue">The default value, returned if the parsing fails.</param>
        /// <returns>Returns the converted value, or the given default value if the conversion failed.</returns>
        [Pure]
        [PublicAPI]
        public static DateTime SafeToDateTime( [CanBeNull] this String value, DateTime defaultValue = default )
            => value.TryParsDateTime( out var outValue ) ? outValue : defaultValue;

        /// <summary>
        ///     Converts the specified string representation of a date and time to its <see cref="DateTime" /> equivalent using the
        ///     specified culture-specific format information and formatting style.
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
        /// <param name="defaultValue">The default value, returned if the parsing fails.</param>
        /// <returns>Returns the converted value, or the given default value if the conversion failed.</returns>
        [Pure]
        [PublicAPI]
        public static DateTime SafeToDateTime( [CanBeNull] this String value,
                                               [NotNull] IFormatProvider formatProvider,
                                               DateTimeStyles dateTimeStyle,
                                               DateTime defaultValue = default )
        {
            formatProvider.ThrowIfNull( nameof(formatProvider) );

            return value.TryParsDateTime( formatProvider, dateTimeStyle, out var outValue ) ? outValue : defaultValue;
        }
    }
}