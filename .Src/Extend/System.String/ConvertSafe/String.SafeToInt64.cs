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
        ///     Converts the string representation of a number to its 64-bit signed integer
        ///     equivalent.
        /// </summary>
        /// <param name="value">A string containing a number to convert.</param>
        /// <param name="defaultValue">The default value, returned if the parsing fails.</param>
        /// <returns>Returns the converted value, or the given default value if the conversion failed.</returns>
        [Pure]
        [PublicAPI]
        public static Int64 SafeToInt64( [CanBeNull] this String value, Int64 defaultValue = default(Int64) )
            => value.TryParsInt64( out var outValue ) ? outValue : defaultValue;

        /// <summary>
        ///     Converts the string representation of a number in a specified numberStyle and culture-specific
        ///     format to its 64-bit signed integer equivalent.
        /// </summary>
        /// <exception cref="ArgumentNullException">formatProvider can not be null.</exception>
        /// <exception cref="ArgumentException">
        ///     numberStyle is not a <see cref="NumberStyles" /> value. -or-style is not a
        ///     combination of <see cref="NumberStyles.AllowHexSpecifier" /> and <see cref="NumberStyles.HexNumber" />
        ///     values.
        /// </exception>
        /// <param name="value">A string containing a number to convert.</param>
        /// <param name="numberStyle">
        ///     A bitwise combination of enumeration values that indicates the numberStyle elements
        ///     that can be present in value. A typical value to specify is <see cref="NumberStyles.Integer" />.
        /// </param>
        /// <param name="formatProvider">An object that supplies culture-specific formatting information about value.</param>
        /// <param name="defaultValue">The default value, returned if the parsing fails.</param>
        /// <returns>Returns the converted value, or the given default value if the conversion failed.</returns>
        [Pure]
        [PublicAPI]
        public static Int64 SafeToInt64( [CanBeNull] this String value,
                                         NumberStyles numberStyle,
                                         [NotNull] IFormatProvider formatProvider,
                                         Int64 defaultValue = default(Int64) )
        {
            formatProvider.ThrowIfNull( nameof(formatProvider) );

            return value.TryParsInt64( numberStyle, formatProvider, out var outValue ) ? outValue : defaultValue;
        }
    }
}