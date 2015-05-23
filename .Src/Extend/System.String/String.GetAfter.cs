#region Usings

using System;

#endregion

namespace Extend
{
    public static partial class StringEx
    {
        /// <summary>
        ///     Gets the part of the string after the specified value, starting at the given start index.
        /// </summary>
        /// <exception cref="ArgumentNullException">str can not be null.</exception>
        /// <exception cref="ArgumentNullException">value can not be null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">The specified start index is invalid.</exception>
        /// <param name="str">The input string.</param>
        /// <param name="value">The value to search.</param>
        /// <param name="startIndex">The start index of the substring.</param>
        /// <returns>The string after the specified value.</returns>
        public static String GetAfter( this String str, String value, Int32 startIndex = 0 )
        {
            str.ThrowIfNull( () => str );

            return GetAfter( str, value, startIndex, str.Length - startIndex );
        }

        /// <summary>
        ///     Gets the part of the string after the specified value, starting at the given start index
        ///     and ending after the specified number of characters.
        /// </summary>
        /// <exception cref="ArgumentNullException">The string can not be null.</exception>
        /// <exception cref="ArgumentNullException">value can not be null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">The specified range is invalid.</exception>
        /// <param name="str">The input string.</param>
        /// <param name="value">The value to search.</param>
        /// <param name="startIndex">The start index of the string.</param>
        /// <param name="length">The length of the string, from the start index.</param>
        /// <returns>The string after the specified value.</returns>
        public static String GetAfter( this String str, String value, Int32 startIndex, Int32 length )
        {
            // ReSharper disable once AccessToModifiedClosure
            str.ThrowIfNull( () => str );
            value.ThrowIfNull( () => value );

            if ( startIndex < 0 || length < 0 || startIndex + length > str.Length )
                throw new ArgumentOutOfRangeException( "length", "The specified range is invalid." );

            str = str.Substring( startIndex, length );
            return !str.Contains( value )
                ? String.Empty
                : str.Substring( str.IndexOf( value, StringComparison.Ordinal ) + value.Length );
        }

        /// <summary>
        ///     Gets the part of the string after the specified value, starting at the given start index.
        /// </summary>
        /// <exception cref="ArgumentNullException">The string can not be null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">The specified start index is invalid.</exception>
        /// <param name="str">The input string.</param>
        /// <param name="value">The value to search.</param>
        /// <param name="startIndex">The start index of the substring.</param>
        /// <returns>The string after the specified value.</returns>
        public static String GetAfter( this String str, Char value, Int32 startIndex = 0 )
        {
            str.ThrowIfNull( () => str );

            return GetAfter( str, value, startIndex, str.Length - startIndex );
        }

        /// <summary>
        ///     Gets the part of the string after the specified value, starting at the given start index
        ///     and ending after the specified number of characters.
        /// </summary>
        /// <exception cref="ArgumentNullException">The string can not be null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">The specified range is invalid.</exception>
        /// <param name="str">The input string.</param>
        /// <param name="value">The value to search.</param>
        /// <param name="startIndex">The start index of the string.</param>
        /// <param name="length">The length of the string, from the start index.</param>
        /// <returns>The string after the specified value.</returns>
        public static String GetAfter( this String str, Char value, Int32 startIndex, Int32 length )
        {
            // ReSharper disable once AccessToModifiedClosure
            str.ThrowIfNull( () => str );

            if ( startIndex < 0 || length < 0 || startIndex + length > str.Length )
                throw new ArgumentOutOfRangeException( "length", "The specified range is invalid." );

            str = str.Substring( startIndex, length );
            var valueIndex = str.IndexOf( value );
            return valueIndex < 0
                ? String.Empty
                : str.Substring( valueIndex + 1 );
        }
    }
}