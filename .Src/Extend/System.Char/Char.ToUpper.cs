#region Usings

using System;

#endregion

namespace Extend
{
    /// <summary>
    ///     Class containing some extension methods for <see cref="char" />.
    /// </summary>
    public static partial class CharEx
    {
        /// <summary>
        ///     Converts the value of a Unicode character to its uppercase equivalent.
        /// </summary>
        /// <param name="c">The Unicode character to convert.</param>
        /// <returns>
        ///     The uppercase equivalent of <paramref name="c" />, or the unchanged value of <paramref name="c" /> if
        ///     <paramref name="c" /> is already uppercase, has no uppercase equivalent, or is not alphabetic.
        /// </returns>
        public static Char ToUpper( this Char c )
        {
            return Char.ToUpper( c );
        }
    }
}