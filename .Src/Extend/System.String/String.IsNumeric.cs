#region Usings

using System;
using System.Linq;

#endregion

namespace Extend
{
    public static partial class StringEx
    {
        /// <summary>
        ///     Checks if the string is numeric.
        /// </summary>
        /// <exception cref="ArgumentNullException">The string can not be null.</exception>
        /// <param name="str">The string to check.</param>
        /// <returns>Returns true if the string is numeric only, otherwise false.</returns>
        public static Boolean IsNumeric( this String str )
        {
            str.ThrowIfNull(nameof(str));

            return str.ToCharArray()
                      .All( x => x.IsNumber() );
        }
    }
}