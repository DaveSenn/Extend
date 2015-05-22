#region Usings

using System;

#endregion

namespace PortableExtensions
{
    public static partial class StringEx
    {
        /// <summary>
        ///     Returns the specified number of characters from the start of the string.
        ///     Checks if the given length is valid, if not it uses the length of the string.
        /// </summary>
        /// <exception cref="ArgumentNullException">The string can not be null.</exception>
        /// <param name="str">The string to get the substring of.</param>
        /// <param name="length">The number of characters.</param>
        /// <returns>Returns the specified number of characters from the start of the string.</returns>
        public static String SubstringLeftSafe( this String str, Int32 length )
        {
            str.ThrowIfNull( () => str );

            return str.Substring( 0, Math.Min( length, str.Length ) );
        }

        /// <summary>
        ///     Returns the specified number of characters from the start index.
        ///     Checks if the given start index and length is valid, if not it uses the length of the string.
        /// </summary>
        /// <exception cref="ArgumentNullException">The string can not be null.</exception>
        /// <param name="str">The string to get the substring of.</param>
        /// <param name="startIndex">The start index.</param>
        /// <param name="length">The number of characters.</param>
        /// <returns>Returns the specified number of characters from the start index of the string.</returns>
        public static String SubstringLeftSafe( this String str, Int32 startIndex, Int32 length )
        {
            str.ThrowIfNull( () => str );

            return str.Substring( Math.Min( startIndex, str.Length ),
                                  Math.Min( length, Math.Max( str.Length - startIndex, 0 ) ) );
        }
    }
}