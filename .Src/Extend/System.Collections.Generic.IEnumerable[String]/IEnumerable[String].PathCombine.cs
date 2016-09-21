#region Usings

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using JetBrains.Annotations;

#endregion

namespace Extend
{
    /// <summary>
    ///     Class containing some extension methods for <see cref="IEnumerable{T}" />.
    /// </summary>
    // ReSharper disable once InconsistentNaming
    public static class IEnumerableStringEx
    {
        /// <summary>
        ///     Returns a path combined out of the items in the given IEnumerable.
        /// </summary>
        /// <exception cref="ArgumentNullException">The enumerable can not be null.</exception>
        /// <param name="enumerable">The IEnumerable to act on.</param>
        /// <returns>The combined path.</returns>
        [PublicAPI]
        [Pure]
        [NotNull]
        public static String PathCombine( [NotNull] [ItemCanBeNull] this IEnumerable<String> enumerable )
        {
            enumerable.ThrowIfNull( nameof( enumerable ) );

            return Path.Combine( enumerable.ToArray() );
        }
    }
}