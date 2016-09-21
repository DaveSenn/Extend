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
        /// <typeparam name="T">The type of the items in the list.</typeparam>
        /// <returns>The items of the array as list.</returns>
        [PublicAPI]
        [Pure]
        public static List<T> ToList<T>( [NotNull] this Array items, [NotNull] Func<Object, T> selector )
        {
            items.ThrowIfNull( nameof( items ) );
            selector.ThrowIfNull( nameof( selector ) );

            return ( from Object item in items
                     select selector( item ) ).ToList();
        }
    }
}