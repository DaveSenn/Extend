#region Usings

using System;
using System.Linq;

#endregion

namespace Extend
{
    public static partial class StringEx
    {
        /// <summary>
        ///     Removes all characters which aren't letters.
        /// </summary>
        /// <exception cref="ArgumentNullException">The string can not be null.</exception>
        /// <param name="str">The input string.</param>
        /// <returns>A new string containing the letters of the input string.</returns>
        public static String KeepLetters( this String str )
        {
            str.ThrowIfNull(nameof(str));

            return new String( str.ToCharArray()
                                  .Where( x => x.IsLetter() )
                                  .ToArray() );
        }
    }
}