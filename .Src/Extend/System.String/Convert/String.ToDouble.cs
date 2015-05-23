#region Usings

using System;
using System.Globalization;

#endregion

namespace Extend
{
    public static partial class StringEx
    {
        /// <summary>
        ///     Converts the given string to a double.
        /// </summary>
        /// <exception cref="ArgumentNullException">The value can not be null.</exception>
        /// <param name="value">The string to convert.</param>
        /// <returns>The double.</returns>
        public static Double ToDouble( this String value )
        {
            value.ThrowIfNull( () => value );

            return Convert.ToDouble( value, CultureInfo.InvariantCulture );
        }

        /// <summary>
        ///     Converts the given string to a double.
        /// </summary>
        /// <exception cref="ArgumentNullException">The value can not be null.</exception>
        /// <exception cref="ArgumentNullException">The format provider can not be null.</exception>
        /// <param name="value">The string to convert.</param>
        /// <param name="formatProvider">The format provider.</param>
        /// <returns>The double.</returns>
        public static Double ToDouble( this String value, IFormatProvider formatProvider )
        {
            value.ThrowIfNull( () => value );
            formatProvider.ThrowIfNull( () => formatProvider );

            return Convert.ToDouble( value, formatProvider );
        }
    }
}