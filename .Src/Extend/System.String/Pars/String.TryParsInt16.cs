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
        ///     Converts the string representation of a number to its 16-bit signed integer
        ///     equivalent. A return value indicates whether the conversion succeeded or
        ///     failed.
        /// </summary>
        /// <param name="value">A string containing a number to convert.</param>
        /// <param name="outValue">
        ///     When this method returns, contains the 16-bit signed integer value equivalent
        ///     to the number contained in s, if the conversion succeeded, or zero if the
        ///     conversion failed. The conversion fails if the s parameter is null or <see cref="String.Empty" />,
        ///     is not of the correct format, or represents a number less than <see cref="Int16.MinValue" />
        ///     or greater than <see cref="Int16.MaxValue" />. This parameter is passed uninitialized.
        /// </param>
        /// <returns>Returns true if the parsing was successful, otherwise false.</returns>
        [Pure]
        [PublicAPI]
        public static Boolean TryParsInt16( [CanBeNull] this String value, out Int16 outValue )
            => Int16.TryParse( value, out outValue );

        /// <summary>
        ///     Converts the string representation of a number in a specified numberStyle and culture-specific
        ///     format to its 16-bit signed integer equivalent. A return value indicates
        ///     whether the conversion succeeded or failed.
        /// </summary>
        /// <exception cref="ArgumentNullException">formatProvider can not be null.</exception>
        /// <exception cref="ArgumentException">
        ///     numberStyle is not a <see cref="NumberStyles" /> value. -or-style is not a
        ///     combination of <see cref="NumberStyles.AllowHexSpecifier" /> and <see cref="NumberStyles.HexNumber" />
        ///     values.
        /// </exception>
        /// <param name="value">
        ///     A string containing a number to convert. The string is interpreted using
        /// </param>
        /// <param name="numberStyle">
        ///     A bitwise combination of enumeration values that indicates the numberStyle elements
        ///     that can be present in value. A typical value to specify is <see cref="NumberStyles.Integer" />.
        /// </param>
        /// <param name="formatProvider">An object that supplies culture-specific formatting information about value.</param>
        /// <param name="outValue">
        ///     When this method returns, contains the 16-bit signed integer value equivalent
        ///     to the number contained in s, if the conversion succeeded, or zero if the
        ///     conversion failed. The conversion fails if the s parameter is null or <see cref="System.String.Empty" />,
        ///     is not in a format compliant with numberStyle, or represents a number less than
        ///     <see cref="System.Int16.MinValue" /> or greater than <see cref="System.Int16.MaxValue" />. This parameter
        ///     is passed uninitialized.
        /// </param>
        /// <returns>Returns true if the parsing was successful, otherwise false.</returns>
        [Pure]
        [PublicAPI]
        public static Boolean TryParsInt16( [CanBeNull] this String value,
                                            NumberStyles numberStyle,
                                            [NotNull] IFormatProvider formatProvider,
                                            out Int16 outValue )
        {
            formatProvider.ThrowIfNull( nameof( formatProvider ) );

            return Int16.TryParse( value, numberStyle, formatProvider, out outValue );
        }
    }
}