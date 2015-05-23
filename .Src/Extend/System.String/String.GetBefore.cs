#region Usings

using System;

#endregion

namespace Extend
{
    public static partial class StringEx
    {
        /// <summary>
        ///     Gets the part of the string before the specified value, starting at the given start index.
        /// </summary>
        /// <exception cref="ArgumentNullException">The string can not be null.</exception>
        /// <exception cref="ArgumentNullException">value can not be null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">The specified start index is invalid.</exception>
        /// <param name="str">The input string.</param>
        /// <param name="value">The value to search for.</param>
        /// <param name="startIndex">The start index of the string.</param>
        /// <returns>
        ///     The part of the string before the specified value, starting at the given start index.
        ///     Or an empty string if the given string doesn't contain the given value.
        /// </returns>
        public static String GetBefore( this String str, String value, Int32 startIndex = 0 )
        {
            str.ThrowIfNull( () => str );

            return GetBefore( str, value, startIndex, str.Length - startIndex );
        }

        /// <summary>
        ///     Gets the part of the string before the specified value, starting at the given start index
        ///     and ending after the specified number of characters.
        /// </summary>
        /// <exception cref="ArgumentNullException">The string can not be null.</exception>
        /// <exception cref="ArgumentNullException">value can not be null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">The specified range is invalid.</exception>
        /// <param name="str">The input string.</param>
        /// <param name="value">The value to search for.</param>
        /// <param name="startIndex">The start index of the string.</param>
        /// <param name="length">The length of the string, from the start index.</param>
        /// <returns>
        ///     The part of the string before the specified value, starting at the given start index.
        ///     Or an empty string if the given string doesn't contain the given value.
        /// </returns>
        public static String GetBefore( this String str, String value, Int32 startIndex, Int32 length )
        {
            // ReSharper disable once AccessToModifiedClosure
            str.ThrowIfNull( () => str );
            value.ThrowIfNull( () => value );

            if ( startIndex < 0 || length < 0 || startIndex + length > str.Length )
                throw new ArgumentOutOfRangeException( "length", "The specified range is invalid." );

            str = str.Substring( startIndex, length );
            return !str.Contains( value )
                ? String.Empty
                : str.Substring( 0, str.IndexOf( value, StringComparison.Ordinal ) );
        }

        /// <summary>
        ///     Gets the part of the string before the specified value, starting at the given start index.
        /// </summary>
        /// <exception cref="ArgumentNullException">The string can not be null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">The specified start index is invalid.</exception>
        /// <param name="str">The input string.</param>
        /// <param name="value">The value to search for.</param>
        /// <param name="startIndex">The start index of the string.</param>
        /// <returns>
        ///     The part of the string before the specified value, starting at the given start index.
        ///     Or an empty string if the given string doesn't contain the given value.
        /// </returns>
        public static String GetBefore( this String str, Char value, Int32 startIndex = 0 )
        {
            str.ThrowIfNull( () => str );

            return GetBefore( str, value, startIndex, str.Length - startIndex );
        }

        /// <summary>
        ///     Gets the part of the string before the specified value, starting at the given start index
        ///     and ending after the specified number of characters.
        /// </summary>
        /// <exception cref="ArgumentNullException">The string can not be null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">The specified range is invalid.</exception>
        /// <param name="str">The input string.</param>
        /// <param name="value">The value to search for.</param>
        /// <param name="startIndex">The start index of the string.</param>
        /// <param name="length">The length of the string, from the start index.</param>
        /// <returns>
        ///     The part of the string before the specified value, starting at the given start index.
        ///     Or an empty string if the given string doesn't contain the given value.
        /// </returns>
        public static String GetBefore( this String str, Char value, Int32 startIndex, Int32 length )
        {
            // ReSharper disable once AccessToModifiedClosure
            str.ThrowIfNull( () => str );

            if ( startIndex < 0 || length < 0 || startIndex + length > str.Length )
                throw new ArgumentOutOfRangeException( "length", "The specified range is invalid." );

            str = str.Substring( startIndex, length );
            var valueIndex = str.IndexOf( value );
            return valueIndex < 0
                ? String.Empty
                : str.Substring( 0, valueIndex );
        }
    }
}