#region Usings

using System;
using System.Collections.Generic;
using JetBrains.Annotations;

#endregion

namespace Extend
{
    /// <summary>
    ///     Key based equality comparer.
    /// </summary>
    /// <typeparam name="TSource">The type of the objects to test for equality.</typeparam>
    /// <typeparam name="TKey">The type of the key to compare.</typeparam>
    public class KeyEqualityComparer<TSource, TKey> : IEqualityComparer<TSource>
    {
        #region Fields

        /// <summary>
        ///     Stores the key comparer.
        /// </summary>
        private readonly IEqualityComparer<TKey> _comparer;

        /// <summary>
        ///     Stores the key selector.
        /// </summary>
        private readonly Func<TSource, TKey> _keySelector;

        #endregion

        #region Ctor

        /// <summary>
        ///     Creates a new instance of the <see cref="KeyEqualityComparer{TSource, TKey}" /> class.
        /// </summary>
        /// <exception cref="ArgumentNullException">keySelector can not be null.</exception>
        /// <param name="keySelector">The key selector.</param>
        /// <param name="comparer">An optional comparer, used to compare the keys.</param>
        public KeyEqualityComparer( [NotNull] Func<TSource, TKey> keySelector, IEqualityComparer<TKey> comparer )
        {
            keySelector.ThrowIfNull( nameof( keySelector ) );

            _keySelector = keySelector;
            _comparer = comparer ?? EqualityComparer<TKey>.Default;
        }

        #endregion

        #region Implementation of IEqualityComparer<in TSource>

        /// <summary>
        ///     Determines whether the specified objects are equal.
        /// </summary>
        /// <returns>
        ///     true if the specified objects are equal; otherwise, false.
        /// </returns>
        /// <param name="x">The first object of type <typeparamref name="TSource" /> to compare.</param>
        /// <param name="y">The second object of type <typeparamref name="TSource" /> to compare.</param>
        [PublicAPI]
        public Boolean Equals( TSource x, TSource y )
            => _comparer.Equals( _keySelector( x ), _keySelector( y ) );

        /// <summary>
        ///     Returns a hash code for the specified object.
        /// </summary>
        /// <returns>
        ///     A hash code for the specified object.
        /// </returns>
        /// <param name="obj">The <see cref="Object" /> for which a hash code is to be returned.</param>
        /// <exception cref="ArgumentNullException">
        ///     The type of <paramref name="obj" /> is a reference type and
        ///     <paramref name="obj" /> is null.
        /// </exception>
        [PublicAPI]
        public Int32 GetHashCode( TSource obj )
            => _comparer.GetHashCode( _keySelector( obj ) );

        #endregion
    }
}