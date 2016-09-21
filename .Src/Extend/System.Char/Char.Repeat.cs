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
        ///     Repeats the given Char the specified number of times.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">repeatCount is less than zero.</exception>
        /// <param name="c">The Char to repeat.</param>
        /// <param name="repeatCount">Number of repeats.</param>
        /// <returns>The repeated Char as String.</returns>
        [PublicAPI]
        [Pure]
        public static String Repeat( this Char c, Int32 repeatCount )
            => new String( c, repeatCount );
    }
}