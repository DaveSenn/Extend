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
        ///     Converts the value of a Unicode character to its lowercase equivalent.
        /// </summary>
        /// <param name="c">The Unicode character to convert.</param>
        /// <returns>
        ///     The lowercase equivalent of <paramref name="c" />, or the unchanged value of <paramref name="c" />, if
        ///     <paramref name="c" /> is already lowercase or not alphabetic.
        /// </returns>
        public static Char ToLower( this Char c ) => Char.ToLower( c );
    }
}