#region Using

using System;
using System.Linq;

#endregion

namespace PortableExtensions
{
    public static partial class StringEx
    {
        /// <summary>
        ///     Checks if the string is alpha.
        /// </summary>
        /// <exception cref="ArgumentNullException">The string can not be null.</exception>
        /// <param name="str">The string to check.</param>
        /// <returns>Returns true if the string is alpha only, otherwise false.</returns>
        public static Boolean IsAlpha( this String str )
        {
            str.ThrowIfNull( () => str );

            return str.ToCharArray().All( x => x.IsLetter() );
        }
    }
}