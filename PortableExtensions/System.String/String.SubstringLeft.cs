#region Usings

using System;

#endregion

namespace PortableExtensions
{
    public static partial class StringEx
    {
        /// <summary>
        ///     Returns the specified number of characters from the start of the string.
        /// </summary>
        /// <exception cref="ArgumentNullException">The string can not be null.</exception>
        /// <param name="str">The string to get the substring of.</param>
        /// <param name="length">The number of characters.</param>
        /// <returns>Returns the specified number of characters from the start of the string.</returns>
        public static String SubstringLeft( this String str, Int32 length )
        {
            str.ThrowIfNull( () => str );

            return str.Substring( 0, length );
        }
    }
}