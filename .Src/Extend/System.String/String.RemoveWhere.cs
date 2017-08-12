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
        ///     Removes some characters from the given string, based on the predicate specified.
        /// </summary>
        /// <exception cref="ArgumentNullException">s can not be null.</exception>
        /// <exception cref="ArgumentNullException">predicate can not be null.</exception>
        /// <param name="s">The input string.</param>
        /// <param name="predicate">The predicate.</param>
        /// <returns>Returns the input string without any of the removed characters.</returns>
        [NotNull]
        [Pure]
        [PublicAPI]
        public static String RemoveWhere( [NotNull] this String s, [NotNull] Func<Char, Boolean> predicate )
        {
            s.ThrowIfNull( nameof(s) );
            predicate.ThrowIfNull( nameof(predicate) );

            return new String( s.ToCharArray()
                                .Where( x => !predicate( x ) )
                                .ToArray() );
        }
    }
}