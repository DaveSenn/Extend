#region Usings

using System;

#endregion

namespace PortableExtensions
{
    public static partial class StringEx
    {
        /// <summary>
        ///     A string extension method that truncates.
        /// </summary>
        /// <param name="str">The string to truncate.</param>
        /// <param name="maxLength">The maximum length of the truncated string.</param>
        /// <param name="suffix">The stuffix of the truncated string.</param>
        /// <returns>The truncated string.</returns>
        public static String Truncate( this String str, Int32 maxLength, String suffix = "..." )
        {
            if ( str.IsEmpty() || str.Length <= maxLength )
                return str;

            return str.Substring( 0, Math.Max( 0, maxLength - suffix.Length ) )
                      .ConcatAll( suffix );
        }
    }
}