#region Usings

using System;
using System.Collections.Generic;

#endregion

namespace Extend
{
    /// <summary>
    ///     Class containing some extension methods for <see cref="IEqualityComparer{T}" />.
    /// </summary>
    // ReSharper disable once InconsistentNaming
    public static class IEqualityComparerEx
    {
        /// <summary>
        ///     Creates an equality comparer based on the specified comparison key and key comparer.
        /// </summary>
        /// <exception cref="ArgumentNullException">keySelector can not be null.</exception>
        /// <typeparam name="TSource">The type of the objects to test for equality.</typeparam>
        /// <typeparam name="TKey">The type of the key to compare.</typeparam>
        /// <param name="keySelector">A function that returns the comparison key.</param>
        /// <param name="comparer">An optional comparer, used to compare the keys.</param>
        /// <returns>Returns an equality comparer based on the specified comparison key and key comparer.</returns>
        public static IEqualityComparer<TSource> By<TSource, TKey>( Func<TSource, TKey> keySelector, IEqualityComparer<TKey> comparer = null )
        {
            keySelector.ThrowIfNull( nameof( keySelector ) );

            return new KeyEqualityComparer<TSource, TKey>( keySelector, comparer );
        }
    }
}