#region Usings

using System;
using System.Linq;

#endregion

namespace Extend
{
    public static partial class StringEx
    {
        /// <summary>
        ///     Removes all numbers from the given string.
        /// </summary>
        /// <exception cref="ArgumentNullException">The string can not be null.</exception>
        /// <param name="str">The input string.</param>
        /// <returns>The given string without any numbers.</returns>
        public static String RemoveNumbers( this String str )
        {
            str.ThrowIfNull( nameof( str ) );

            return new String( str.ToCharArray()
                                  .Where( x => !x.IsNumber() )
                                  .ToArray() );
        }
    }
}