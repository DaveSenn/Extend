#region Usings

using System;

#endregion

namespace PortableExtensions
{
    public static partial class StringEx
    {
        /// <summary>
        ///     Gets the part of the input string between the before and after value, starting at the given start index.
        /// </summary>
        /// <exception cref="ArgumentNullException">The string can not be null.</exception>
        /// <exception cref="ArgumentNullException">value can not be null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">The specified start index is invalid.</exception>
        /// <param name="str">The input string.</param>
        /// <param name="before">The before value.</param>
        /// <param name="after">The after value.</param>
        /// <param name="startIndex">The start index of the string.</param>
        /// <returns>The part of the string between the before and after value.</returns>
        public static String GetBetween ( this String str, String before, String after, Int32 startIndex = 0 )
        {
            str.ThrowIfNull( () => str );

            return GetBetween( str, before, after, startIndex, str.Length - startIndex );
        }

        /// <summary>
        ///     Gets the part of the input string between the before and after value, starting at the given start index,
        ///     and ending after the specified number of characters.
        /// </summary>
        /// <exception cref="ArgumentNullException">The string can not be null.</exception>
        /// <exception cref="ArgumentNullException">value can not be null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">The specified range is invalid.</exception>
        /// <param name="str">The input string.</param>
        /// <param name="before">The before value.</param>
        /// <param name="after">The after value.</param>
        /// <param name="startIndex">The start index of the string.</param>
        /// <param name="length">The length of the string, from the start index.</param>
        /// <returns>The part of the string between the before and after value.</returns>
        public static String GetBetween ( this String str, String before, String after, Int32 startIndex, Int32 length )
        {
            // ReSharper disable once AccessToModifiedClosure
            str.ThrowIfNull( () => str );
            before.ThrowIfNull( () => before );
            after.ThrowIfNull( () => after );

            if ( startIndex < 0 || startIndex + length > str.Length )
                throw new ArgumentOutOfRangeException( "length", "The specified range is invalid." );

            str = str.Substring( startIndex, length );

            var beforeIndex = str.IndexOf( before, StringComparison.Ordinal );
            if ( beforeIndex < 0 )
                return String.Empty;

            var actualStartIndex = beforeIndex + before.Length;
            var afterIndex = str.IndexOf( after, actualStartIndex, StringComparison.Ordinal );
            return afterIndex < 0 ? String.Empty : str.Substring( actualStartIndex, afterIndex - actualStartIndex );
        }

        /// <summary>
        ///     Gets the part of the input string between the before and after value, starting at the given start index.
        /// </summary>
        /// <exception cref="ArgumentNullException">The string can not be null.</exception>
        /// <exception cref="ArgumentNullException">value can not be null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">The specified start index is invalid.</exception>
        /// <param name="str">The input string.</param>
        /// <param name="before">The before value.</param>
        /// <param name="after">The after value.</param>
        /// <param name="startIndex">The start index of the string.</param>
        /// <returns>The part of the string between the before and after value.</returns>
        public static String GetBetween ( this String str, Char before, Char after, Int32 startIndex = 0 )
        {
            str.ThrowIfNull( () => str );

            return GetBetween( str, before, after, startIndex, str.Length - startIndex );
        }

        /// <summary>
        ///     Gets the part of the input string between the before and after value, starting at the given start index,
        ///     and ending after the specified number of characters.
        /// </summary>
        /// <exception cref="ArgumentNullException">The string can not be null.</exception>
        /// <exception cref="ArgumentNullException">value can not be null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">The specified range is invalid.</exception>
        /// <param name="str">The input string.</param>
        /// <param name="before">The before value.</param>
        /// <param name="after">The after value.</param>
        /// <param name="startIndex">The start index of the string.</param>
        /// <param name="length">The length of the string, from the start index.</param>
        /// <returns>The part of the string between the before and after value.</returns>
        public static String GetBetween ( this String str, Char before, Char after, Int32 startIndex, Int32 length )
        {
            // ReSharper disable once AccessToModifiedClosure
            str.ThrowIfNull( () => str );
            before.ThrowIfNull( () => before );
            after.ThrowIfNull( () => after );

            if ( startIndex < 0 || length < 0 || startIndex + length > str.Length )
                throw new ArgumentOutOfRangeException( "length", "The specified range is invalid." );

            str = str.Substring( startIndex, length );

            var beforeIndex = str.IndexOf( before );
            if ( beforeIndex < 0 )
                return String.Empty;

            var actualStartIndex = beforeIndex + 1;
            var afterIndex = str.IndexOf( after, actualStartIndex );
            return afterIndex < 0
                ? String.Empty
                : str.Substring( actualStartIndex, afterIndex - actualStartIndex );
        }
    }
}