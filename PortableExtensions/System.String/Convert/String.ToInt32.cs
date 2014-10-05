#region Using

using System;
using System.Globalization;

#endregion

namespace PortableExtensions
{
    public static partial class StringEx
    {
        /// <summary>
        ///     Converts the given string to a Int32.
        /// </summary>
        /// <exception cref="ArgumentNullException">The value can not be null.</exception>
        /// <param name="value">The string to convert.</param>
        /// <returns>The Int32.</returns>
        public static Int32 ToInt32( this String value )
        {
            value.ThrowIfNull( () => value );

            return Convert.ToInt32( value, CultureInfo.InvariantCulture );
        }

        /// <summary>
        ///     Converts the given string to a Int32.
        /// </summary>
        /// <exception cref="ArgumentNullException">The value can not be null.</exception>
        /// <exception cref="ArgumentNullException">The format provider can not be null.</exception>
        /// <param name="value">The string to convert.</param>
        /// <param name="formatProvider">The format provider.</param>
        /// <returns>The Int32.</returns>
        public static Int32 ToInt32( this String value, IFormatProvider formatProvider )
        {
            value.ThrowIfNull( () => value );
            formatProvider.ThrowIfNull( () => formatProvider );

            return Convert.ToInt32( value, formatProvider );
        }
    }
}