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
        /// <param name="value">The string to pars.</param>
        /// <param name="outValue">The parsed value.</param>
        /// <returns>Returns true if the parsing was successful, otherwise false.</returns>
        public static Boolean TryParsDateTime( this String value, out DateTime outValue )
        {
            value.ThrowIfNull( () => value );

            return DateTime.TryParse( value, CultureInfo.InvariantCulture, DateTimeStyles.None, out outValue );
        }

        /// <summary>
        ///     replace
        /// </summary>
        /// <exception cref="ArgumentNullException">The value can not be null.</exception>
        /// <exception cref="ArgumentNullException">The format provider can not be null.</exception>
        /// <param name="value">The string to pars.</param>
        /// <param name="outValue">The parsed value.</param>
        /// <param name="formatProvider">The format provider.</param>
        /// <param name="dateTimeStyle">The date time style.</param>
        /// <returns>Returns true if the parsing was successful, otherwise false.</returns>
        public static Boolean TryParsDateTime( this String value,
                                               IFormatProvider formatProvider,
                                               DateTimeStyles dateTimeStyle,
                                               out DateTime outValue )
        {
            value.ThrowIfNull( () => value );
            formatProvider.ThrowIfNull( () => formatProvider );

            return DateTime.TryParse( value, formatProvider, dateTimeStyle, out outValue );
        }
    }
}