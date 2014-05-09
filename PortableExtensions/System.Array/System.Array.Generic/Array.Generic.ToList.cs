#region Using

using System;
using System.Collections.Generic;

#endregion

namespace PortableExtensions
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
        public static List<TResult> ToList<TArray, TResult>( this TArray[] items, Func<TArray, TResult> selector )
        {
            items.ThrowIfNull( () => items );
            selector.ThrowIfNull( () => selector );

            var list = new List<TResult>();
            foreach ( var item in items )
                list.Add( selector( item ) );

            return list;
        }
    }
}