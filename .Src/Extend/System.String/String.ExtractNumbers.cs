#region Usings

using System;
using System.Linq;

#endregion

namespace Extend
{
    public static partial class StringEx
    {
        /// <summary>
        ///     Extracts all numbers of the input string.
        /// </summary>
        /// <exception cref="ArgumentNullException">The string can not be null.</exception>
        /// <param name="str">The string to extract the numbers from.</param>
        /// <returns>The extracted numbers.</returns>
        public static String ExtractNumbers( this String str )
        {
            str.ThrowIfNull( () => str );

            return new String( str.ToCharArray()
                                  .Where( x => x.IsNumber() )
                                  .ToArray() );
        }
    }
}