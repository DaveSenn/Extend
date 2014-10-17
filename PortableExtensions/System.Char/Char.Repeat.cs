#region Usings

using System;

#endregion

namespace PortableExtensions
{
    /// <summary>
    ///     Class containing some extension methods for <see cref="char" />.
    /// </summary>
    public static partial class CharEx
    {
        /// <summary>
        ///     Reapeats the given Char the specified number of times.
        /// </summary>
        /// <param name="c">The Char to repeat.</param>
        /// <param name="repeatCount">Number of repeats.</param>
        /// <returns>The repeated Char as String.</returns>
        public static String Repeat ( this Char c, Int32 repeatCount )
        {
            return new String( c, repeatCount );
        }
    }
}