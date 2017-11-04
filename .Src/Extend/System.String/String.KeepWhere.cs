#region Usings

using System;
using System.Linq;
using JetBrains.Annotations;

#endregion

namespace Extend
{
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
        [NotNull]
        [Pure]
        [PublicAPI]
        public static String KeepWhere( [NotNull] this String str, [NotNull] Func<Char, Boolean> predicate )
        {
            str.ThrowIfNull( nameof(str) );
            predicate.ThrowIfNull( nameof(predicate) );

            return new String( str.ToCharArray()
                                  .Where( predicate )
                                  .ToArray() );
        }
    }
}