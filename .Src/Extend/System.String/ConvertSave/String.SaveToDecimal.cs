#region Usings

using System;
using System.Globalization;
using JetBrains.Annotations;

#endregion

namespace Extend
{
    public static partial class StringEx
    {
        /// <summary>
        ///     Converts the string representation of a number to its <see cref="Decimal" /> equivalent.
        /// </summary>
        /// <param name="value">The string representation of the number to convert.</param>
        /// <param name="defaultValue">The default value, returned if the parsing fails.</param>
        /// <returns>Returns the converted value, or the given default value if the conversion failed.</returns>
        [Pure]
        [PublicAPI]
        public static Decimal SaveToDecimal( [CanBeNull] this String value, Decimal defaultValue = default(Decimal) )
            => value.TryParsDecimal( out var outValue ) ? outValue : defaultValue;

        /// <summary>
        ///     Converts the string representation of a number to its System.Decimal equivalent
        ///     using the specified numberStyle and culture-specific format.
        /// </summary>
        /// <exception cref="ArgumentNullException">formatProvider can not be null.</exception>
        /// <exception cref="ArgumentException">
        ///     numberStyle is not a System.Globalization.NumberStyles value. -or-style is the
        ///     <see cref="NumberStyles.AllowHexSpecifier" />  value.
        /// </exception>
        /// <param name="value">The string representation of the number to convert.</param>
        /// <param name="numberStyle">
        ///     A bitwise combination of enumeration values that indicates the permitted
        ///     format of value. A typical value to specify is System.Globalization.NumberStyles.Number.
        /// </param>
        /// <param name="formatProvider">An object that supplies culture-specific parsing information about value.</param>
        /// <param name="defaultValue">The default value, returned if the parsing fails.</param>
        /// <returns>Returns the converted value, or the given default value if the conversion failed.</returns>
        [Pure]
        [PublicAPI]
        public static Decimal SaveToDecimal( [CanBeNull] this String value,
                                             NumberStyles numberStyle,
                                             [NotNull] IFormatProvider formatProvider,
                                             Decimal defaultValue = default(Decimal) )
        {
            formatProvider.ThrowIfNull( nameof(formatProvider) );

            return value.TryParsDecimal( numberStyle, formatProvider, out var outValue ) ? outValue : defaultValue;
        }
    }
}