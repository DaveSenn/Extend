#region Usings

using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;

#endregion

namespace Extend
{
    /// <summary>
    ///     Class containing some extension methods for <see cref="IEnumerable{T}" />.
    /// </summary>
    // ReSharper disable once InconsistentNaming
    public static partial class IEnumerableTEx
    {
        /// <summary>
        ///     Returns all unique items, based on the given predicate.
        /// </summary>
        /// <exception cref="ArgumentNullException">The enumerable can not be null.</exception>
        /// <exception cref="ArgumentNullException">The predicate can not be null.</exception>
        /// <param name="enumerable">The IEnumerable.</param>
        /// <param name="predicate">The Predicate.</param>
        /// <typeparam name="T">The type of the items in the IEnumerable.</typeparam>
        /// <typeparam name="TKey">The input type of the predicate.</typeparam>
        [Pure]
        [PublicAPI]
        [NotNull]
        public static IEnumerable<T> Distinct<T, TKey>( [NotNull] [ItemCanBeNull] this IEnumerable<T> enumerable, [NotNull] Func<T, TKey> predicate )
        {
            enumerable.ThrowIfNull( nameof(enumerable) );
            predicate.ThrowIfNull( nameof(predicate) );

            return enumerable.GroupBy( predicate )
                             .Select( g => g )
                             .Select( x => x.First() );
        }
    }
}