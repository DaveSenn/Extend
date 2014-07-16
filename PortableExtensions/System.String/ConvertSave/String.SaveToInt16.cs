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
        ///     Converts the given string to a Int16.
        /// </summary>
        /// <exception cref="ArgumentNullException">The value can not be null.</exception>
        /// <param name="value">The string to convert.</param>
        /// <param name="defaultValue">The default value, returned if the parsing fails.</param>
        /// <returns>Returns the converted Int16.</returns>
        public static Int16 SaveToInt16( this String value, Int16? defaultValue = null )
        {
            value.ThrowIfNull( () => value );

            Int16 outValue;
            return value.TryParsInt16( out outValue ) ? outValue : ( defaultValue ?? outValue );
        }

        /// <summary>
        ///     Converts the given string to a Int16.
        /// </summary>
        /// <exception cref="ArgumentNullException">The value can not be null.</exception>
        /// <exception cref="ArgumentNullException">The format provider can not be null.</exception>
        /// <param name="value">The string to convert.</param>
        /// <param name="numberStyle">
        ///     A bitwise combination of enumeration values that indicates the numberStyle elements
        ///     that can be present in value. A typical value to specify is <see cref="NumberStyles.Integer" />.
        /// </param>
        /// <param name="formatProvider">An object that supplies culture-specific formatting information about value.</param>
        /// <param name="defaultValue">The default value, returned if the parsing fails.</param>
        /// <returns>Returns the converted Int16.</returns>
        public static Int16 SaveToInt16( this String value,
                                         NumberStyles numberStyle,
                                         IFormatProvider formatProvider,
                                         Int16? defaultValue = null )
        {
            value.ThrowIfNull( () => value );
            formatProvider.ThrowIfNull( () => formatProvider );

            Int16 outValue;
            return value.TryParsInt16( numberStyle, formatProvider, out outValue )
                       ? outValue
                       : ( defaultValue ?? outValue );
        }
    }
}