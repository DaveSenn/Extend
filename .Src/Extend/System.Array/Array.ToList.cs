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
        /// <typeparam name="T">The type of the items in the list.</typeparam>
        /// <returns>The items of the array as list.</returns>
        public static List<T> ToList<T>( this Array items, Func<Object, T> selector )
        {
            items.ThrowIfNull( () => items );
            selector.ThrowIfNull( () => selector );

            return ( from Object item in items
                     select selector( item ) ).ToList();
        }
    }
}