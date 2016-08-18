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
        ///     Produces the set intersection of two sequences.
        /// </summary>
        /// <exception cref="ArgumentNullException">first can not be null.</exception>
        /// <exception cref="ArgumentNullException">second can not be null.</exception>
        /// <exception cref="ArgumentNullException">keySelector can not be null.</exception>
        /// <typeparam name="TSource">The type of the items to compare.</typeparam>
        /// <typeparam name="TKey">The type of the item keys.</typeparam>
        /// <param name="first">
        ///     An <see cref="System.Collections.Generic.IEnumerable{TSource}" /> whose distinct elements that also
        ///     appear in second will be returned.
        /// </param>
        /// <param name="second">
        ///     An <see cref="System.Collections.Generic.IEnumerable{TSource}" /> whose distinct elements that also
        ///     appear in the first sequence will be returned.
        /// </param>
        /// <param name="keySelector">A function used to select the key of the items to compare.</param>
        /// <param name="comparer">
        ///     An optional <see cref="System.Collections.Generic.IEqualityComparer{TKey}" /> to compare the
        ///     keys of the items.
        /// </param>
        /// <returns>Returns a sequence that contains the elements that form the set intersection of two sequences.</returns>
        [Pure]
        [PublicAPI]
        [CanBeNull]
        public static IEnumerable<TSource> Intersect<TSource, TKey>( [NotNull] [ItemCanBeNull] this IEnumerable<TSource> first,
                                                                     [NotNull] [ItemCanBeNull] IEnumerable<TSource> second,
                                                                     [NotNull] Func<TSource, TKey> keySelector,
                                                                     [CanBeNull] IEqualityComparer<TKey> comparer = null )
        {
            first.ThrowIfNull( nameof( first ) );
            second.ThrowIfNull( nameof( second ) );
            keySelector.ThrowIfNull( nameof( keySelector ) );

            var internalComparer = IEqualityComparerEx.By( keySelector, comparer );

            return first.Intersect( second, internalComparer );
        }
    }
}