#region Using

using System;
using System.Globalization;

#endregion

namespace PortableExtensions
{
    /// <summary>
    ///     Class containing some extension methods for <see cref="string" />.
    /// </summary>
    public static partial class StringEx
    {
        /// <summary>
        ///     replace
        /// </summary>
        /// <exception cref="ArgumentNullException">The value can not be null.</exception>
        /// <exception cref="ArgumentNullException">The format can not be null.</exception>
        /// <exception cref="ArgumentNullException">The format provider can not be null.</exception>
        /// <param name="value">The string to pars.</param>
        /// <param name="outValue">The parsed value.</param>
        /// <param name="format">The format of the date time value in the string</param>
        /// <param name="formatProvider">The format provider.</param>
        /// <param name="dateTimeStyle">The date time style.</param>
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
        ///     replace
        /// </summary>
        /// <exception cref="ArgumentNullException">The value can not be null.</exception>
        /// <exception cref="ArgumentNullException">The formats can not be null.</exception>
        /// <exception cref="ArgumentNullException">The format provider can not be null.</exception>
        /// <param name="value">The string to pars.</param>
        /// <param name="outValue">The parsed value.</param>
        /// <param name="formats">The formats of the date time value in the string</param>
        /// <param name="formatProvider">The format provider.</param>
        /// <param name="dateTimeStyle">The date time style.</param>
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