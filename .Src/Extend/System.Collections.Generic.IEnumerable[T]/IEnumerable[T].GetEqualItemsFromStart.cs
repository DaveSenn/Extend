#region Usings

using System.Collections.Generic;
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
        ///     Returns the equal items of two IEnumerables, according to the specified comparer.
        ///     Beginning at the start of the IEnumerables, ending when first different item is found.
        /// </summary>
        /// <typeparam name="T">The type of the items in the IEnumerable.</typeparam>
        /// <param name="left">The first IEnumerable.</param>
        /// <param name="right">The second IEnumerable.</param>
        /// <param name="comparer">The comparer used to test items for equality.</param>
        /// <returns>
        ///     A sequence consisting of the first elements of <paramref name="left" /> that match the first elements of
        ///     <paramref name="right" />.
        ///     The resulting sequence ends when the two input sequence start to differ.
        /// </returns>
        [Pure]
        [PublicAPI]
        [NotNull]
        public static IEnumerable<T> GetEqualItemsFromStart<T>( [NotNull] [ItemCanBeNull] this IEnumerable<T> left,
                                                                [NotNull] [ItemCanBeNull] IEnumerable<T> right,
                                                                [CanBeNull] IEqualityComparer<T> comparer = null )
        {
            left.ThrowIfNull( nameof(left) );
            right.ThrowIfNull( nameof(right) );

            comparer = comparer ?? EqualityComparer<T>.Default;

            using ( IEnumerator<T> rightEnumerator = left.GetEnumerator(),
                leftEnumerator = right.GetEnumerator() )
                while ( rightEnumerator.MoveNext() && leftEnumerator.MoveNext() )
                    if ( comparer.Equals( rightEnumerator.Current, leftEnumerator.Current ) )
                        yield return rightEnumerator.Current;
                    else
                        yield break;
        }
    }
}