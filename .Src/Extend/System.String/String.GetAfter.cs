#region Usings

using System;
using JetBrains.Annotations;

#endregion

namespace Extend
{
    public static partial class StringEx
    {
        /// <summary>
        ///     Gets the part of the string after the specified value, starting at the given start index.
        /// </summary>
        /// <exception cref="ArgumentNullException">s can not be null.</exception>
        /// <exception cref="ArgumentNullException">value can not be null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">The specified start index is invalid.</exception>
        /// <param name="s">The input string.</param>
        /// <param name="value">The value to search.</param>
        /// <param name="startIndex">The start index of the substring.</param>
        /// <returns>The string after the specified value.</returns>
        [NotNull]
        [Pure]
        [PublicAPI]
        public static String GetAfter( [NotNull] this String s, [NotNull] String value, Int32 startIndex = 0 )
        {
            s.ThrowIfNull( nameof( s ) );

            return s.GetAfter( value, startIndex, s.Length - startIndex );
        }

        /// <summary>
        ///     Gets the part of the string after the specified value, starting at the given start index
        ///     and ending after the specified number of characters.
        /// </summary>
        /// <exception cref="ArgumentNullException">The string can not be null.</exception>
        /// <exception cref="ArgumentNullException">value can not be null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">The specified range is invalid.</exception>
        /// <param name="s">The input string.</param>
        /// <param name="value">The value to search.</param>
        /// <param name="startIndex">The start index of the string.</param>
        /// <param name="length">The length of the string, from the start index.</param>
        /// <returns>The string after the specified value.</returns>
        [NotNull]
        [Pure]
        [PublicAPI]
        public static String GetAfter( [NotNull] this String s, [NotNull] String value, Int32 startIndex, Int32 length )
        {
            s.ThrowIfNull( nameof( s ) );
            value.ThrowIfNull( nameof( value ) );

            if ( startIndex < 0 || length < 0 || startIndex + length > s.Length )
                throw new ArgumentOutOfRangeException( nameof( length ), "The specified range is invalid." );

            s = s.Substring( startIndex, length );
            return !s.Contains( value )
                ? String.Empty
                : s.Substring( s.IndexOf( value, StringComparison.Ordinal ) + value.Length );
        }

        /// <summary>
        ///     Gets the part of the string after the specified value, starting at the given start index.
        /// </summary>
        /// <exception cref="ArgumentNullException">The string can not be null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">The specified start index is invalid.</exception>
        /// <param name="s">The input string.</param>
        /// <param name="value">The value to search.</param>
        /// <param name="startIndex">The start index of the substring.</param>
        /// <returns>The string after the specified value.</returns>
        [NotNull]
        [Pure]
        [PublicAPI]
        public static String GetAfter( [NotNull] this String s, Char value, Int32 startIndex = 0 )
        {
            s.ThrowIfNull( nameof( s ) );

            return s.GetAfter( value, startIndex, s.Length - startIndex );
        }

        /// <summary>
        ///     Gets the part of the string after the specified value, starting at the given start index
        ///     and ending after the specified number of characters.
        /// </summary>
        /// <exception cref="ArgumentNullException">The string can not be null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">The specified range is invalid.</exception>
        /// <param name="s">The input string.</param>
        /// <param name="value">The value to search.</param>
        /// <param name="startIndex">The start index of the string.</param>
        /// <param name="length">The length of the string, from the start index.</param>
        /// <returns>The string after the specified value.</returns>
        [NotNull]
        [Pure]
        [PublicAPI]
        public static String GetAfter( [NotNull] this String s, Char value, Int32 startIndex, Int32 length )
        {
            s.ThrowIfNull( nameof( s ) );

            if ( startIndex < 0 || length < 0 || startIndex + length > s.Length )
                throw new ArgumentOutOfRangeException( nameof( length ), "The specified range is invalid." );

            s = s.Substring( startIndex, length );
            var valueIndex = s.IndexOf( value );
            return valueIndex < 0
                ? String.Empty
                : s.Substring( valueIndex + 1 );
        }
    }
}