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
        ///     Executes the given action for each item in the IEnumerable in a reversed order.
        /// </summary>
        /// <exception cref="ArgumentNullException">The enumerable can not be null.</exception>
        /// <exception cref="ArgumentNullException">The action can not be null.</exception>
        /// <remarks>It's save to remove items from the IEnumerable within the loop.</remarks>
        /// <param name="enumerable">The IEnumerable to act on.</param>
        /// <param name="action">The action to execute for each item in the IEnumerable.</param>
        [Pure]
        [PublicAPI]
        [NotNull]
        public static IEnumerable<T> ForEachReverse<T>( [NotNull] [ItemCanBeNull] this IEnumerable<T> enumerable, [NotNull] Action<T> action )
        {
            enumerable.ThrowIfNull( nameof( enumerable ) );
            action.ThrowIfNull( nameof( action ) );

            var list = enumerable.ToList();
            for ( var i = list.Count - 1; i >= 0; i-- )
                action( list[i] );

            return list;
        }
    }
}