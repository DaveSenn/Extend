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
        ///     Checks if the string is alpha numeric.
        /// </summary>
        /// <exception cref="ArgumentNullException">The string can not be null.</exception>
        /// <param name="str">The string to check.</param>
        /// <returns>Returns true if the string is alpha numeric, otherwise false.</returns>
        public static Boolean IsAlphaNumeric( this string str )
        {
            str.ThrowIfNull( () => str );

            return str.ToCharArray().All( x => x.IsLetter() || x.IsNumber() );
        }
    }
}