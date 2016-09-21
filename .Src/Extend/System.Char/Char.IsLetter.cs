#region Usings

using System;
using JetBrains.Annotations;

#endregion

namespace Extend
{
    /// <summary>
    ///     Class containing some extension methods for <see cref="char" />.
    /// </summary>
    public static partial class CharEx
    {
        /// <summary>
        ///     Indicates whether the specified Unicode character is categorized as a Unicode letter.
        /// </summary>
        /// <param name="c">The Unicode character to evaluate.</param>
        /// <returns>True if the given char is a letter, otherwise false.</returns>
        [PublicAPI]
        [Pure]
        public static Boolean IsLetter( this Char c )
            => Char.IsLetter( c );
    }
}