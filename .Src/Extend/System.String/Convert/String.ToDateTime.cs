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
        ///     Converts the given string to a date time value.
        /// </summary>
        /// <exception cref="ArgumentNullException">The value can not be null.</exception>
        /// <exception cref="FormatException">Value does not contain a valid string representation of a date and time.</exception>
        /// <param name="value">The string to convert.</param>
        /// <returns>Returns the date time value.</returns>
        [Pure]
        [PublicAPI]
        public static DateTime ToDateTime( [NotNull] this String value )
        {
            value.ThrowIfNull( nameof( value ) );

            return DateTime.Parse( value, CultureInfo.CurrentCulture );
        }

        /// <summary>
        ///     Converts the given string to a date time value.
        /// </summary>
        /// <exception cref="ArgumentNullException">The value can not be null.</exception>
        /// <exception cref="ArgumentNullException">The format provider can not be null.</exception>
        /// <exception cref="FormatException">Value does not contain a valid string representation of a date and time.</exception>
        /// <param name="value">The string to convert.</param>
        /// <param name="formatProvider">The format provider.</param>
        /// <returns>Returns the date time value.</returns>
        [Pure]
        [PublicAPI]
        public static DateTime ToDateTime( [NotNull] this String value, [NotNull] IFormatProvider formatProvider )
        {
            value.ThrowIfNull( nameof( value ) );
            formatProvider.ThrowIfNull( nameof( formatProvider ) );

            return DateTime.Parse( value, formatProvider );
        }
    }
}