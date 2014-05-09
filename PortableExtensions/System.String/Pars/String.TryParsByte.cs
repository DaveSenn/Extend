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
        ///     Tries to convert the string representation of a number to its System.Byte
        ///     equivalent, and returns a value that indicates whether the conversion succeeded.
        /// </summary>
        /// <exception cref="ArgumentNullException">The value can not be null.</exception>
        /// <param name="value">
        ///     A string that contains a number to convert. The string is interpreted using
        ///     the System.Globalization.NumberStyles.Integer style.
        ///     The string to pars.
        /// </param>
        /// <param name="outValue">
        ///     The parsed value.
        ///     When this method returns, contains the System.Byte value equivalent to the
        ///     number contained in s if the conversion succeeded, or zero if the conversion
        ///     failed. This parameter is passed uninitialized.
        /// </param>
        /// <returns>Returns true if the parsing was successful, otherwise false.</returns>
        public static Boolean TryParsByte( this String value, out Byte outValue )
        {
            value.ThrowIfNull( () => value );

            return Byte.TryParse( value, NumberStyles.Any, CultureInfo.InvariantCulture, out outValue );
        }

        /// <summary>
        ///     Converts the string representation of a number in a specified style and culture-specific
        ///     format to its System.Byte equivalent. A return value indicates whether the
        ///     conversion succeeded or failed.
        /// </summary>
        /// <param name="value">
        ///     A string containing a number to convert. The string is interpreted using
        ///     the style specified by style.
        /// </param>
        /// <param name="style">
        ///     A bitwise combination of enumeration values that indicates the style elements
        ///     that can be present in s. A typical value to specify is System.Globalization.NumberStyles.Integer.
        /// </param>
        /// <param name="provider">
        ///     An object that supplies culture-specific formatting information about s.
        ///     If provider is null, the thread current culture is used.
        /// </param>
        /// <param name="outValue">
        ///     When this method returns, contains the 8-bit unsigned integer value equivalent
        ///     to the number contained in s if the conversion succeeded, or zero if the
        ///     conversion failed. The conversion fails if the s parameter is null or System.String.Empty,
        ///     is not of the correct format, or represents a number less than System.Byte.MinValue
        ///     or greater than System.Byte.MaxValue. This parameter is passed uninitialized.
        /// </param>
        /// <returns>Returns true if the parsing was successful, otherwise false.</returns>
        public static Boolean TryParsByte( this String value, NumberStyles style, IFormatProvider provider,
                                           out Byte outValue )
        {
            value.ThrowIfNull( () => value );
            provider.ThrowIfNull( () => provider );

            return Byte.TryParse( value, style, provider, out outValue );
        }
    }
}