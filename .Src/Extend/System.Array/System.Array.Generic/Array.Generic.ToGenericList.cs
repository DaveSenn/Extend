#region Usings

using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;

#endregion

namespace Extend
{
    /// <summary>
    ///     Class containing some extension methods for <see cref="Array" />.
    /// </summary>
    public static partial class ArrayEx
    {
        /// <summary>
        ///     Converts the given array to a list using the specified selector.
        /// </summary>
        /// <exception cref="ArgumentNullException">items can not be null.</exception>
        /// <exception cref="ArgumentNullException">selector can not be null.</exception>
        /// <param name="items">The array containing the items.</param>
        /// <param name="selector">The selector.</param>
        /// <typeparam name="TArray">The type of the items in the array.</typeparam>
        /// <typeparam name="TResult">The type of the items in the list.</typeparam>
        /// <returns>The items of the array as list.</returns>
        [PublicAPI]
        [NotNull]
        [Pure]
        public static List<TResult> ToGenericList<TArray, TResult>( [NotNull] this TArray[] items, [NotNull] Func<TArray, TResult> selector )
        {
            items.ThrowIfNull( nameof(items) );
            selector.ThrowIfNull( nameof(selector) );

            return items
                   .Select( selector )
                   .ToList();
        }
    }
}