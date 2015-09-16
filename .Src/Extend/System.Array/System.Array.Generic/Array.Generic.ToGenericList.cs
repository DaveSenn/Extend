#region Usings

using System;
using System.Collections.Generic;
using System.Linq;

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
        /// <param name="items">The array containing the items.</param>
        /// <param name="selector">The selector.</param>
        /// <typeparam name="TArray">The type of the items in the array.</typeparam>
        /// <typeparam name="TResult">The type of the items in the list.</typeparam>
        /// <returns>The items of the array as list.</returns>
        public static List<TResult> ToGenericList<TArray, TResult>( this TArray[] items, Func<TArray, TResult> selector )
        {
            items.ThrowIfNull( nameof( items ) );
            selector.ThrowIfNull( nameof( selector ) );

            return items.Select( selector )
                        .ToList();
        }
    }
}