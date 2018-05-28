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
        ///     equivalent.
        /// </summary>
        /// <param name="value">
        ///     A string that contains a number to convert. The string is interpreted using
        ///     the <see cref="NumberStyles.Integer" /> numberStyle.
        ///     The string to pars.
        /// </param>
        /// <param name="defaultValue">The default value, returned if the parsing fails.</param>
        /// <returns>Returns the converted value, or the given default value if the conversion failed.</returns>
        [Pure]
        [PublicAPI]
        public static Byte SafeToByte( [CanBeNull] this String value, Byte defaultValue = default )
            => value.TryParsByte( out var outValue ) ? outValue : defaultValue;

        /// <summary>
        ///     Tries to convert the string representation of a number to its <see cref="Byte" />
        ///     equivalent.
        /// </summary>
        /// <exception cref="ArgumentNullException">formatProvider can not be null.</exception>
        /// <exception cref="ArgumentException">
        ///     numberStyle is not a <see cref="NumberStyles" /> value. -or-style is not a
        ///     combination of <see cref="NumberStyles.AllowHexSpecifier" /> and
        ///     <see cref="NumberStyles.HexNumber" /> values.
        /// </exception>
        /// <param name="value">
        ///     A string that contains a number to convert. The string is interpreted using
        ///     the <see cref="NumberStyles.Integer" /> numberStyle.
        ///     The string to pars.
        /// </param>
        /// <param name="numberStyle">
        ///     A bitwise combination of enumeration values that indicates the numberStyle elements
        ///     that can be present in s. A typical value to specify is <see cref="NumberStyles.Integer" />.
        /// </param>
        /// <param name="formatProvider">
        ///     An object that supplies culture-specific formatting information about s.
        ///     If formatProvider is null, the thread current culture is used.
        /// </param>
        /// <param name="defaultValue">The default value, returned if the parsing fails.</param>
        /// <returns>Returns the converted value, or the given default value if the conversion failed.</returns>
        [Pure]
        [PublicAPI]
        public static Byte SafeToByte( [CanBeNull] this String value,
                                       NumberStyles numberStyle,
                                       [NotNull] IFormatProvider formatProvider,
                                       Byte defaultValue = default )
        {
            formatProvider.ThrowIfNull( nameof(formatProvider) );

            return value.TryParsByte( numberStyle, formatProvider, out var outValue ) ? outValue : defaultValue;
        }
    }
}