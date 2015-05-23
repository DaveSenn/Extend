#region Usings

using System;

#endregion

namespace Extend
{
    public static partial class StringEx
    {
        /// <summary>
        ///     Returns the specified number of characters from the end of the string.
        ///     Checks if the given length is valid, if not it uses the length of the string.
        /// </summary>
        /// <exception cref="ArgumentNullException">The string can not be null.</exception>
        /// <param name="str">The string to get the substring of.</param>
        /// <param name="length">The number of characters.</param>
        /// <returns>Returns the specified number of characters from the end of the string.</returns>
        public static String SubstringRightSafe( this String str, Int32 length )
        {
            str.ThrowIfNull( () => str );

            return str.Substring( Math.Max( 0, str.Length - length ) );
        }
    }
}