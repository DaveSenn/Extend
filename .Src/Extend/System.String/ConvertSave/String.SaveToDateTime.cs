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
        /// <param name="defaultValue">The default value, returned if the parsing fails.</param>
        /// <returns>The date time value.</returns>
        public static DateTime SaveToDateTime( this String value, DateTime? defaultValue = null )
        {
            value.ThrowIfNull( nameof( value ) );

            DateTime outValue;
            return value.TryParsDateTime( out outValue ) ? outValue : ( defaultValue ?? outValue );
        }

        /// <summary>
        ///     Converts the given string to a date time value.
        /// </summary>
        /// <exception cref="ArgumentNullException">The value can not be null.</exception>
        /// <exception cref="ArgumentNullException">The format provider can not be null.</exception>
        /// <param name="value">The string to convert.</param>
        /// <param name="formatProvider">The format provider.</param>
        /// <param name="dateTimeStyle">The date time style.</param>
        /// <param name="defaultValue">The default value, returned if the parsing fails.</param>
        /// <returns>The date time value.</returns>
        public static DateTime SaveToDateTime( this String value,
                                               IFormatProvider formatProvider,
                                               DateTimeStyles dateTimeStyle,
                                               DateTime? defaultValue = null )
        {
            value.ThrowIfNull( nameof( value ) );
            formatProvider.ThrowIfNull( nameof( formatProvider ) );

            DateTime outValue;
            return value.TryParsDateTime( formatProvider, dateTimeStyle, out outValue )
                ? outValue
                : ( defaultValue ?? outValue );
        }
    }
}