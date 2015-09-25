#region Usings

using System;

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
        public static String SubstringRight( this String str, Int32 length )
        {
            str.ThrowIfNull( nameof( str ) );

            return str.Substring( str.Length - length );
        }
    }
}