#region Usings

using System;
using System.Linq;

#endregion

namespace Extend
{
    public static partial class StringEx
    {
        /// <summary>
        ///     Extracts all letters of the input string.
        /// </summary>
        /// <exception cref="ArgumentNullException">The string can not be null.</exception>
        /// <param name="str">The string to extract the letters from.</param>
        /// <returns>The extracted letters.</returns>
        public static String ExtractLetters( this String str )
        {
            str.ThrowIfNull( () => str );

            return new String( str.ToCharArray()
                                  .Where( x => x.IsLetter() )
                                  .ToArray() );
        }
    }
}