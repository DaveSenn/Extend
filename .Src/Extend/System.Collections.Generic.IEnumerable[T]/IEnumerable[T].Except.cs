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
        ///     Produces the set difference of two sequences by using the specified
        ///     <see cref="System.Collections.Generic.IEqualityComparer{TKey}" /> to compare values.
        /// </summary>
        /// <exception cref="ArgumentNullException">first can not be null.</exception>
        /// <exception cref="ArgumentNullException">second can not be null.</exception>
        /// <exception cref="ArgumentNullException">keySelector can not be null.</exception>
        /// <typeparam name="TSource">The type of the items to compare.</typeparam>
        /// <typeparam name="TKey">The type of the item keys.</typeparam>
        /// <param name="first">
        ///     An <see cref="System.Collections.Generic.IEnumerable{TSource}" /> whose elements that are not also
        ///     in <paramref name="second" /> will be returned.
        /// </param>
        /// <param name="second">
        ///     An <see cref="System.Collections.Generic.IEnumerable{TSource}" /> whose elements that also occur
        ///     in the first sequence will cause those elements to be removed from the returned sequence.
        /// </param>
        /// <param name="keySelector">A function used to select the key of the items to compare.</param>
        /// <param name="comparer">
        ///     An optional <see cref="System.Collections.Generic.IEqualityComparer{TKey}" /> to compare the
        ///     keys of the items.
        /// </param>
        /// <returns>A sequence that contains the set difference of the elements of two sequences.</returns>
        [Pure]
        [PublicAPI]
        [NotNull]
        public static IEnumerable<TSource> Except<TSource, TKey>( [NotNull] [ItemCanBeNull] this IEnumerable<TSource> first,
                                                                  [NotNull] [ItemCanBeNull] IEnumerable<TSource> second,
                                                                  [NotNull] Func<TSource, TKey> keySelector,
                                                                  [CanBeNull] IEqualityComparer<TKey> comparer = null )
        {
            first.ThrowIfNull( nameof( first ) );
            second.ThrowIfNull( nameof( second ) );
            keySelector.ThrowIfNull( nameof( keySelector ) );

            var internalComparer = IEqualityComparerEx.By( keySelector, comparer );

            return first.Except( second, internalComparer );
        }
    }
}