#region Usings

using System;

#endregion

namespace PortableExtensions
{
    public static partial class StringEx
    {
        /// <summary>
        ///     Converts the value of the specified string to its equivalent Unicode character.
        ///     A return code indicates whether the conversion succeeded or failed.
        /// </summary>
        /// <exception cref="ArgumentNullException">The value can not be null.</exception>
        /// <param name="value">A string that contains a single character.</param>
        /// <param name="outValue">
        ///     When this method returns, contains a Unicode character equivalent to the
        ///     sole character in s, if the conversion succeeded, or an undefined value if
        ///     the conversion failed. The conversion fails if the s parameter is null or
        ///     the length of s is not 1. This parameter is passed uninitialized.
        /// </param>
        /// <returns>Returns true if the parsing was successful, otherwise false.</returns>
        public static Boolean TryParsChar( this String value, out Char outValue )
        {
            value.ThrowIfNull( () => value );

            return Char.TryParse( value, out outValue );
        }
    }
}