#region Using

using System;
using System.Linq;

#endregion

namespace PortableExtensions
{
    /// <summary>
    ///     Class containing some extension methods for <see cref="string" />.
    /// </summary>
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
            str.ThrowIfNull( () => str );

            return new String( str.ToCharArray().Where( x => x.IsLetter() ).ToArray() );
        }
    }
}