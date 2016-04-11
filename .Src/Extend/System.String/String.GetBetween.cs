#region Usings

using System;
using JetBrains.Annotations;

#endregion

namespace Extend
{
    public static partial class StringEx
    {
        /// <summary>
        ///     Gets the part of the input string between the before and after value, starting at the given start index.
        /// </summary>
        /// <exception cref="ArgumentNullException">The string can not be null.</exception>
        /// <exception cref="ArgumentNullException">value can not be null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">The specified start index is invalid.</exception>
        /// <param name="s">The input string.</param>
        /// <param name="before">The before value.</param>
        /// <param name="after">The after value.</param>
        /// <param name="startIndex">The start index of the string.</param>
        /// <returns>The part of the string between the before and after value.</returns>
        [NotNull]
        [Pure]
        [PublicAPI]
        public static String GetBetween( [NotNull] this String s, [NotNull] String before, [NotNull] String after, Int32 startIndex = 0 )
        {
            s.ThrowIfNull( nameof( s ) );

            return s.GetBetween( before, after, startIndex, s.Length - startIndex );
        }

        /// <summary>
        ///     Gets the part of the input string between the before and after value, starting at the given start index,
        ///     and ending after the specified number of characters.
        /// </summary>
        /// <exception cref="ArgumentNullException">The string can not be null.</exception>
        /// <exception cref="ArgumentNullException">value can not be null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">The specified range is invalid.</exception>
        /// <param name="s">The input string.</param>
        /// <param name="before">The before value.</param>
        /// <param name="after">The after value.</param>
        /// <param name="startIndex">The start index of the string.</param>
        /// <param name="length">The length of the string, from the start index.</param>
        /// <returns>The part of the string between the before and after value.</returns>
        [NotNull]
        [Pure]
        [PublicAPI]
        public static String GetBetween( [NotNull] this String s, [NotNull] String before, [NotNull] String after, Int32 startIndex, Int32 length )
        {
            s.ThrowIfNull( nameof( s ) );
            before.ThrowIfNull( nameof( before ) );
            after.ThrowIfNull( nameof( after ) );

            if ( startIndex < 0 || startIndex + length > s.Length )
                throw new ArgumentOutOfRangeException( nameof( length ), "The specified range is invalid." );

            s = s.Substring( startIndex, length );

            var beforeIndex = s.IndexOf( before, StringComparison.Ordinal );
            if ( beforeIndex < 0 )
                return String.Empty;

            var actualStartIndex = beforeIndex + before.Length;
            var afterIndex = s.IndexOf( after, actualStartIndex, StringComparison.Ordinal );
            return afterIndex < 0 ? String.Empty : s.Substring( actualStartIndex, afterIndex - actualStartIndex );
        }

        /// <summary>
        ///     Gets the part of the input string between the before and after value, starting at the given start index.
        /// </summary>
        /// <exception cref="ArgumentNullException">The string can not be null.</exception>
        /// <exception cref="ArgumentNullException">value can not be null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">The specified start index is invalid.</exception>
        /// <param name="s">The input string.</param>
        /// <param name="before">The before value.</param>
        /// <param name="after">The after value.</param>
        /// <param name="startIndex">The start index of the string.</param>
        /// <returns>The part of the string between the before and after value.</returns>
        [NotNull]
        [Pure]
        [PublicAPI]
        public static String GetBetween( [NotNull] this String s, Char before, Char after, Int32 startIndex = 0 )
        {
            s.ThrowIfNull( nameof( s ) );

            return s.GetBetween( before, after, startIndex, s.Length - startIndex );
        }

        /// <summary>
        ///     Gets the part of the input string between the before and after value, starting at the given start index,
        ///     and ending after the specified number of characters.
        /// </summary>
        /// <exception cref="ArgumentNullException">The string can not be null.</exception>
        /// <exception cref="ArgumentNullException">value can not be null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">The specified range is invalid.</exception>
        /// <param name="s">The input string.</param>
        /// <param name="before">The before value.</param>
        /// <param name="after">The after value.</param>
        /// <param name="startIndex">The start index of the string.</param>
        /// <param name="length">The length of the string, from the start index.</param>
        /// <returns>The part of the string between the before and after value.</returns>
        [NotNull]
        [Pure]
        [PublicAPI]
        public static String GetBetween( [NotNull] this String s, Char before, Char after, Int32 startIndex, Int32 length )
        {
            s.ThrowIfNull( nameof( s ) );

            if ( startIndex < 0 || length < 0 || startIndex + length > s.Length )
                throw new ArgumentOutOfRangeException( nameof( length ), "The specified range is invalid." );

            s = s.Substring( startIndex, length );

            var beforeIndex = s.IndexOf( before );
            if ( beforeIndex < 0 )
                return String.Empty;

            var actualStartIndex = beforeIndex + 1;
            var afterIndex = s.IndexOf( after, actualStartIndex );
            return afterIndex < 0
                ? String.Empty
                : s.Substring( actualStartIndex, afterIndex - actualStartIndex );
        }
    }
}