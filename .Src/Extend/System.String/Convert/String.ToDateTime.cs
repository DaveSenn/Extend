#region Usings

using System;
using System.Globalization;

#endregion

namespace Extend
{
    public static partial class StringEx
    {
        /// <summary>
        ///     Converts the given string to a date time value.
        /// </summary>
        /// <exception cref="ArgumentNullException">The value can not be null.</exception>
        /// <param name="value">The string to convert.</param>
        /// <returns>The date time value.</returns>
        public static DateTime ToDateTime( this String value )
        {
            value.ThrowIfNull( nameof( value ) );

            return Convert.ToDateTime( value, CultureInfo.InvariantCulture );
        }

        /// <summary>
        ///     Converts the given string to a date time value.
        /// </summary>
        /// <exception cref="ArgumentNullException">The value can not be null.</exception>
        /// <exception cref="ArgumentNullException">The format provider can not be null.</exception>
        /// <param name="value">The string to convert.</param>
        /// <param name="formatProvider">The format provider.</param>
        /// <returns>The date time value.</returns>
        public static DateTime ToDateTime( this String value, IFormatProvider formatProvider )
        {
            value.ThrowIfNull( nameof( value ) );
            formatProvider.ThrowIfNull( nameof( formatProvider ) );

            return Convert.ToDateTime( value, formatProvider );
        }
    }
}