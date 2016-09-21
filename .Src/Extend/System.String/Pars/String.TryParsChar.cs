#region Usings

using System;
using JetBrains.Annotations;

#endregion

namespace Extend
{
    public static partial class StringEx
    {
        /// <summary>
        ///     Converts the value of the specified string to its equivalent Unicode character.
        ///     A return code indicates whether the conversion succeeded or failed.
        /// </summary>
        /// <param name="value">A string that contains a single character.</param>
        /// <param name="outValue">
        ///     When this method returns, contains a Unicode character equivalent to the
        ///     sole character in s, if the conversion succeeded, or an undefined value if
        ///     the conversion failed. The conversion fails if the s parameter is null or
        ///     the length of s is not 1. This parameter is passed uninitialized.
        /// </param>
        /// <returns>Returns true if the parsing was successful, otherwise false.</returns>
        [Pure]
        [PublicAPI]
        public static Boolean TryParsChar( [CanBeNull] this String value, out Char outValue )
            => Char.TryParse( value, out outValue );
    }
}