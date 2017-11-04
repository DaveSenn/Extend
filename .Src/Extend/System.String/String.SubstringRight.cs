#region Usings

using System;
using JetBrains.Annotations;

#endregion

namespace Extend
{
    public static partial class StringEx
    {
        /// <summary>
        ///     Returns the specified number of characters from the end of the string.
        /// </summary>
        /// <exception cref="ArgumentNullException">The string can not be null.</exception>
        /// <param name="str">The string to get the substring of.</param>
        /// <param name="length">The number of characters.</param>
        /// <returns>Returns the specified number of characters from the end of the string.</returns>
        [NotNull]
        [Pure]
        [PublicAPI]
        public static String SubstringRight( [NotNull] this String str, Int32 length )
        {
            str.ThrowIfNull( nameof(str) );

            return str.Substring( str.Length - length );
        }
    }
}