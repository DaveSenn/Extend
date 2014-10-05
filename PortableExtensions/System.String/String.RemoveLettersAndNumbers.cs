#region Using

using System;
using System.Linq;

#endregion

namespace PortableExtensions
{
    public static partial class StringEx
    {
        /// <summary>
        ///     Removes all letters and numbers from the given string.
        /// </summary>
        /// <exception cref="ArgumentNullException">The string can not be null.</exception>
        /// <param name="str">The input string.</param>
        /// <returns>The given string without any letters or numbers.</returns>
        public static String RemoveLettersAndNumbers( this String str )
        {
            str.ThrowIfNull( () => str );

            return new String( str.ToCharArray().Where( x => !x.IsNumber() && !x.IsLetter() ).ToArray() );
        }
    }
}