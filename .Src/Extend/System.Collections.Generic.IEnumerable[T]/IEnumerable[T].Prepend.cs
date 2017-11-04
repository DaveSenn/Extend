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
        ///     Prepends the given item to the given sequence.
        /// </summary>
        /// <exception cref="ArgumentNullException">source can not be null.</exception>
        /// <typeparam name="T">The type of the items in the IEnumerable.</typeparam>
        /// <param name="source">The sequence to prepend an item to.</param>
        /// <param name="item">The item to prepend.</param>
        /// <returns>The source sequence preceded by the prepended item.</returns>
        [Pure]
        [PublicAPI]
        [NotNull]
        public static IEnumerable<T> Prepend<T>( [NotNull] [ItemCanBeNull] this IEnumerable<T> source, [CanBeNull] T item )
        {
            source.ThrowIfNull( nameof(source) );

            return new[] { item }.Concat( source );
        }
    }
}