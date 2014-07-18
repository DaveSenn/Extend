#region Using

using System;

#endregion

namespace PortableExtensions
{
    /// <summary>
    ///     Class containing some extension methods for <see cref="string" />.
    /// </summary>
    public static partial class StringEx
    {
        /// <summary>
        ///     Gets the part of the string before the specified value, starting at the given start index.
        /// </summary>
        /// <exception cref="ArgumentNullException">The string can not be null.</exception>
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

            if ( startIndex < 0 || startIndex + length > str.Length )
                throw new ArgumentOutOfRangeException( "The specified range is invalid." );

            str = str.Substring( startIndex, length );
            if ( !str.Contains( value ) )
                return String.Empty;

            return str.Substring( 0, str.IndexOf( value, StringComparison.Ordinal ) );
        }
    }
}