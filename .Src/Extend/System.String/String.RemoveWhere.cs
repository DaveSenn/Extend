#region Usings

using System;
using System.Linq;

#endregion

namespace Extend
{
    public static partial class StringEx
    {
        /// <summary>
        ///     Removes some characters from the given string, based on the predicate specified.
        /// </summary>
        /// <exception cref="ArgumentNullException">The string can not be null.</exception>
        /// <exception cref="ArgumentNullException">The predicate can not be null.</exception>
        /// <param name="str">The input string.</param>
        /// <param name="predicate">The predicate.</param>
        /// <returns>The input string without any of the removed characters.</returns>
        public static String RemoveWhere( this String str, Func<Char, Boolean> predicate )
        {
            str.ThrowIfNull(nameof(str));
            predicate.ThrowIfNull(nameof(predicate));

            return new String( str.ToCharArray()
                                  .Where( x => !predicate( x ) )
                                  .ToArray() );
        }
    }
}