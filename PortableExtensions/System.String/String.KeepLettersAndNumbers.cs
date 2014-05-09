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
        ///     Removes all characters which aren't letters or numbers.
        /// </summary>
        /// <exception cref="ArgumentNullException">The string can not be null.</exception>
        /// <param name="str">The input string.</param>
        /// <returns>A new string containing the letters and numbers of the input string.</returns>
        public static String KeepLettersAndNumbers( this String str )
        {
            str.ThrowIfNull( () => str );

            return new String( str.ToCharArray().Where( x => x.IsNumber() || x.IsLetter() ).ToArray() );
        }
    }
}