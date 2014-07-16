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
        ///     Converts the given string to a double.
        /// </summary>
        /// <exception cref="ArgumentNullException">The value can not be null.</exception>
        /// <param name="value">The string to convert.</param>
        /// <param name="defaultValue">The default value, returned if the parsing fails.</param>
        /// <returns>The double.</returns>
        public static Double SaveToDouble( this String value, Double? defaultValue = null )
        {
            value.ThrowIfNull( () => value );

            Double outValue;
            return value.TryParsDouble( out outValue ) ? outValue : ( defaultValue ?? outValue );
        }

        /// <summary>
        ///     Converts the given string to a double.
        /// </summary>
        /// <exception cref="ArgumentNullException">The value can not be null.</exception>
        /// <exception cref="ArgumentNullException">The format provider can not be null.</exception>
        /// <param name="value">The string to convert.</param>
        /// <param name="numberStyle">
        ///     A bitwise combination of <see cref="NumberStyles" /> values that indicates
        ///     the permitted format of s. A typical value to specify is <see cref="NumberStyles.Float" />
        ///     combined with <see cref="NumberStyles.AllowThousands" />
        /// </param>
        /// <param name="formatProvider">
        ///     An <see cref="IFormatProvider" /> that supplies culture-specific formatting information
        ///     about s.
        /// </param>
        /// <param name="defaultValue">The default value, returned if the parsing fails.</param>
        /// <returns>The double.</returns>
        public static Double SaveToDouble( this String value,
                                           NumberStyles numberStyle,
                                           IFormatProvider formatProvider,
                                           Double? defaultValue = null )
        {
            value.ThrowIfNull( () => value );
            formatProvider.ThrowIfNull( () => formatProvider );

            Double outValue;
            return value.TryParsDouble( numberStyle, formatProvider, out outValue )
                       ? outValue
                       : ( defaultValue ?? outValue );
        }
    }
}