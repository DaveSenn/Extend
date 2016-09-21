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
        ///     Checks if the given length is valid, if not it uses the length of the string.
        /// </summary>
        /// <exception cref="ArgumentNullException">s can not be null.</exception>
        /// <param name="s">The string to get the substring of.</param>
        /// <param name="length">The number of characters.</param>
        /// <returns>Returns the specified number of characters from the start of the string.</returns>
        [NotNull]
        [Pure]
        [PublicAPI]
        public static String SubstringLeftSafe( [NotNull] this String s, Int32 length )
        {
            s.ThrowIfNull( nameof( s ) );

            return s.Substring( 0, Math.Min( length, s.Length ) );
        }

        /// <summary>
        ///     Returns the specified number of characters from the start index.
        ///     Checks if the given start index and length is valid, if not it uses the length of the string.
        /// </summary>
        /// <exception cref="ArgumentNullException">s can not be null.</exception>
        /// <param name="s">The string to get the substring of.</param>
        /// <param name="startIndex">The start index.</param>
        /// <param name="length">The number of characters.</param>
        /// <returns>Returns the specified number of characters from the start index of the string.</returns>
        [NotNull]
        [Pure]
        [PublicAPI]
        public static String SubstringLeftSafe( [NotNull] this String s, Int32 startIndex, Int32 length )
        {
            s.ThrowIfNull( nameof( s ) );

            return s.Substring( Math.Min( startIndex, s.Length ),
                                Math.Min( length, Math.Max( s.Length - startIndex, 0 ) ) );
        }
    }
}