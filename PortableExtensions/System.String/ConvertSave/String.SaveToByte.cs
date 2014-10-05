#region Using

using System;
using System.Globalization;

#endregion

namespace PortableExtensions
{
    public static partial class StringEx
    {
        /// <summary>
        ///     Converts the given string to a byte.
        /// </summary>
        /// <exception cref="ArgumentNullException">The value can not be null.</exception>
        /// <param name="value">The string to convert.</param>
        /// <param name="defaultValue">The default value, returned if the parsing fails.</param>
        /// <returns>The byte.</returns>
        public static Byte SaveToByte( this String value, Byte? defaultValue = null )
        {
            value.ThrowIfNull( () => value );

            Byte outValue;
            return value.TryParsByte( out outValue ) ? outValue : ( defaultValue ?? outValue );
        }

        /// <summary>
        ///     Converts the given string to a byte.
        /// </summary>
        /// <exception cref="ArgumentNullException">The value can not be null.</exception>
        /// <exception cref="ArgumentNullException">The format formatProvider can not be null.</exception>
        /// <param name="value">The string to convert.</param>
        /// <param name="numberStyle">The number format.</param>
        /// <param name="formatProvider">The format formatProvider.</param>
        /// <param name="defaultValue">The default value, returned if the parsing fails.</param>
        /// <returns>The byte.</returns>
        public static Byte SaveToByte( this String value,
                                       NumberStyles numberStyle,
                                       IFormatProvider formatProvider,
                                       Byte? defaultValue = null )
        {
            value.ThrowIfNull( () => value );
            formatProvider.ThrowIfNull( () => formatProvider );

            Byte outValue;
            return value.TryParsByte( numberStyle, formatProvider, out outValue )
                       ? outValue
                       : ( defaultValue ?? outValue );
        }
    }
}