#region Usings

using System;

#endregion

namespace Extend
{
    public static partial class StringEx
    {
        /// <summary>
        ///     Reverses the given string.
        /// </summary>
        /// <exception cref="ArgumentNullException">The string can not be null.</exception>
        /// <param name="str">The string to reverse.</param>
        /// <returns>The reversed string.</returns>
        public static String Reverse( this String str )
        {
            str.ThrowIfNull(nameof(str));

            return str.Length <= 1
                ? str
                : new String( str.ToCharArray()
                                 .Reverse() );
        }
    }
}