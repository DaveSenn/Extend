#region Usings

using System;
using JetBrains.Annotations;

#endregion

namespace Extend
{
    public static partial class StringEx
    {
        /// <summary>
        ///     Returns the specified number of characters from the start of the string.
        /// </summary>
        /// <exception cref="ArgumentNullException">s can not be null.</exception>
        /// <param name="s">The string to get the substring of.</param>
        /// <param name="length">The number of characters.</param>
        /// <returns>Returns the specified number of characters from the start of the string.</returns>
        [NotNull]
        [Pure]
        [PublicAPI]
        public static String SubstringLeft( [NotNull] this String s, Int32 length )
        {
            s.ThrowIfNull( nameof(s) );

            return s.Substring( 0, length );
        }
    }
}