#region Usings

using System;
using System.Globalization;

#endregion

namespace Extend
{
    public static partial class StringEx
    {
        /// <summary>
        ///     Converts the given string to a Int16.
        /// </summary>
        /// <exception cref="ArgumentNullException">The value can not be null.</exception>
        /// <param name="value">The string to convert.</param>
        /// <returns>Returns the converted Int16.</returns>
        public static Int16 ToInt16( this String value )
        {
            value.ThrowIfNull( () => value );

            return Convert.ToInt16( value, CultureInfo.InvariantCulture );
        }

        /// <summary>
        ///     Converts the given string to a Int16.
        /// </summary>
        /// <exception cref="ArgumentNullException">The value can not be null.</exception>
        /// <exception cref="ArgumentNullException">The format provider can not be null.</exception>
        /// <param name="value">The string to convert.</param>
        /// <param name="formatProvider">The format provider.</param>
        /// <returns>Returns the converted Int16.</returns>
        public static Int16 ToInt16( this String value, IFormatProvider formatProvider )
        {
            value.ThrowIfNull( () => value );
            formatProvider.ThrowIfNull( () => formatProvider );

            return Convert.ToInt16( value, formatProvider );
        }
    }
}