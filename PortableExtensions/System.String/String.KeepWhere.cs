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
        ///     Returns a string which only contains the characters matching the given predicate.
        /// </summary>
        /// <exception cref="ArgumentNullException">The string can not be null.</exception>
        /// <exception cref="ArgumentNullException">The predicate can not be null.</exception>
        /// <param name="str">The input string.</param>
        /// <param name="predicate">The predicate.</param>
        /// <returns>Returns a string which only contains the characters matching the given predicate.</returns>
        public static String KeepWhere( this String str, Func<Char, Boolean> predicate )
        {
            str.ThrowIfNull( () => str );
            predicate.ThrowIfNull( () => predicate );

            return new String( str.ToCharArray().Where( predicate ).ToArray() );
        }
    }
}