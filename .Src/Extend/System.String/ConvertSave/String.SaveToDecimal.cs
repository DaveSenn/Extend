#region Usings

using System;
using System.Globalization;

#endregion

namespace PortableExtensions
{
    public static partial class StringEx
    {
        /// <summary>
        ///     Converts the given string to a decimal.
        /// </summary>
        /// <exception cref="ArgumentNullException">The value can not be null.</exception>
        /// <param name="value">The string to convert.</param>
        /// <param name="defaultValue">The default value, returned if the parsing fails.</param>
        /// <returns>The decimal.</returns>
        public static Decimal SaveToDecimal( this String value, Decimal? defaultValue = null )
        {
            value.ThrowIfNull( () => value );

            Decimal outValue;
            return value.TryParsDecimal( out outValue ) ? outValue : ( defaultValue ?? outValue );
        }

        /// <summary>
        ///     Converts the given string to a decimal.
        /// </summary>
        /// <exception cref="ArgumentNullException">The value can not be null.</exception>
        /// <exception cref="ArgumentNullException">The format provider can not be null.</exception>
        /// <param name="value">The string to convert.</param>
        /// <param name="numberStyle">
        ///     A bitwise combination of enumeration values that indicates the permitted
        ///     format of value. A typical value to specify is System.Globalization.NumberStyles.Number.
        /// </param>
        /// <param name="formatProvider">An object that supplies culture-specific parsing information about value.</param>
        /// <param name="defaultValue">The default value, returned if the parsing fails.</param>
        /// <returns>The decimal.</returns>
        public static Decimal SaveToDecimal( this String value,
                                             NumberStyles numberStyle,
                                             IFormatProvider formatProvider,
                                             Decimal? defaultValue = null )
        {
            value.ThrowIfNull( () => value );
            formatProvider.ThrowIfNull( () => formatProvider );

            Decimal outValue;
            return value.TryParsDecimal( numberStyle, formatProvider, out outValue )
                ? outValue
                : ( defaultValue ?? outValue );
        }
    }
}