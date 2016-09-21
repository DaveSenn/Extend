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
        ///     Indicates whether the specified Unicode character is categorized as a lowercase letter.
        /// </summary>
        /// <param name="c">The Unicode character to evaluate.</param>
        /// <returns>True if the given char is a lowercase letter, otherwise false.</returns>
        [PublicAPI]
        [Pure]
        public static Boolean IsLower( this Char c )
            => Char.IsLower( c );
    }
}