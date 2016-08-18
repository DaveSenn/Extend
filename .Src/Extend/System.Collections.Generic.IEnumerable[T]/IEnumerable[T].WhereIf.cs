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
        ///     Performs a where predicate on the IEnumerable, if the given condition is true,
        ///     otherwise returns all items of the IEnumerable.
        /// </summary>
        /// <exception cref="ArgumentNullException">The source can not be null.</exception>
        /// <exception cref="ArgumentNullException">The predicate can not be null.</exception>
        /// <typeparam name="T">The type of the items in the IEnumerable.</typeparam>
        /// <param name="source">The IEnumerable containing the items.</param>
        /// <param name="condition">The condition determining whether the where predicate gets applied or not.</param>
        /// <param name="predicate">The where predicate.</param>
        /// <returns>Returns the result of the predicate if the condition is true, otherwise the source IEnumerable.</returns>
        [Pure]
        [PublicAPI]
        [NotNull]
        public static IEnumerable<T> WhereIf<T>( [NotNull] [ItemCanBeNull] this IEnumerable<T> source,
                                                 Boolean condition,
                                                 [NotNull] Func<T, Boolean> predicate )
        {
            source.ThrowIfNull( nameof( source ) );
            predicate.ThrowIfNull( nameof( predicate ) );

            return condition ? source.Where( predicate ) : source;
        }

        /// <summary>
        ///     Performs a where predicate on the IEnumerable, if the given condition is true,
        ///     otherwise returns all items of the IEnumerable.
        /// </summary>
        /// <exception cref="ArgumentNullException">The source can not be null.</exception>
        /// <exception cref="ArgumentNullException">The predicate can not be null.</exception>
        /// <typeparam name="T">The type of the items in the IEnumerable.</typeparam>
        /// <param name="source">The IEnumerable containing the items.</param>
        /// <param name="condition">The condition determining whether the where predicate gets applied or not.</param>
        /// <param name="predicate">The where predicate.</param>
        /// <returns>Returns the result of the predicate if the condition is true, otherwise the source IEnumerable.</returns>
        [Pure]
        [PublicAPI]
        [NotNull]
        public static IEnumerable<T> WhereIf<T>( [NotNull] [ItemCanBeNull] this IEnumerable<T> source,
                                                 Boolean condition,
                                                 [NotNull] Func<T, Int32, Boolean> predicate )
        {
            source.ThrowIfNull( nameof( source ) );
            predicate.ThrowIfNull( nameof( predicate ) );

            return condition ? source.Where( predicate ) : source;
        }
    }
}