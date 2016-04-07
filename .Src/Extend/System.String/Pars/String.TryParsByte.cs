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
        ///     Tries to convert the string representation of a number to its <see cref="Byte" />
        ///     equivalent, and returns a value that indicates whether the conversion succeeded.
        /// </summary>
        /// <param name="value">
        ///     A string that contains a number to convert. The string is interpreted using
        ///     the <see cref="NumberStyles.Integer" /> numberStyle.
        ///     The string to pars.
        /// </param>
        /// <param name="outValue">
        ///     The parsed value.
        ///     When this method returns, contains the <see cref="Byte" /> value equivalent to the
        ///     number contained in s if the conversion succeeded, or zero if the conversion
        ///     failed. This parameter is passed uninitialized.
        /// </param>
        /// <returns>Returns true if the parsing was successful, otherwise false.</returns>
        [Pure]
        [PublicAPI]
        public static Boolean TryParsByte( [CanBeNull] this String value, out Byte outValue )
            => Byte.TryParse( value, out outValue );

        /// <summary>
        ///     Converts the string representation of a number in a specified numberStyle and culture-specific
        ///     format to its <see cref="Byte" /> equivalent. A return value indicates whether the
        ///     conversion succeeded or failed.
        /// </summary>
        /// <exception cref="ArgumentNullException">formatProvider can not be null.</exception>
        /// <exception cref="ArgumentException">
        ///     numberStyle is not a <see cref="NumberStyles" /> value. -or-style is not a
        ///     combination of <see cref="NumberStyles.AllowHexSpecifier" /> and
        ///     <see cref="NumberStyles.HexNumber" /> values.
        /// </exception>
        /// <param name="value">
        ///     A string containing a number to convert. The string is interpreted using
        ///     the numberStyle specified by numberStyle.
        /// </param>
        /// <param name="numberStyle">
        ///     A bitwise combination of enumeration values that indicates the numberStyle elements
        ///     that can be present in s. A typical value to specify is <see cref="NumberStyles.Integer" />.
        /// </param>
        /// <param name="formatProvider">
        ///     An object that supplies culture-specific formatting information about s.
        ///     If formatProvider is null, the thread current culture is used.
        /// </param>
        /// <param name="outValue">
        ///     When this method returns, contains the 8-bit unsigned integer value equivalent
        ///     to the number contained in s if the conversion succeeded, or zero if the
        ///     conversion failed. The conversion fails if the s parameter is null or <see cref="String.Empty" />,
        ///     is not of the correct format, or represents a number less than <see cref="Byte.MinValue" />
        ///     or greater than <see cref="Byte.MaxValue" />. This parameter is passed uninitialized.
        /// </param>
        /// <returns>Returns true if the parsing was successful, otherwise false.</returns>
        [Pure]
        [PublicAPI]
        public static Boolean TryParsByte( [CanBeNull] this String value,
                                           NumberStyles numberStyle,
                                           [NotNull] IFormatProvider formatProvider,
                                           out Byte outValue )
        {
            formatProvider.ThrowIfNull( nameof( formatProvider ) );

            return Byte.TryParse( value, numberStyle, formatProvider, out outValue );
        }
    }
}