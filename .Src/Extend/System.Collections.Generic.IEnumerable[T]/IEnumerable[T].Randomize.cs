#region Usings

using System;
using System.Collections.Generic;
using System.Linq;

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
        ///     Orders the items in the IEnumerable randomly.
        /// </summary>
        /// <exception cref="ArgumentNullException">The enumerable can not be null.</exception>
        /// <param name="enumerable">The IEnumerable.</param>
        /// <typeparam name="T">The type of the items in the enumerable.</typeparam>
        public static IEnumerable<T> Randomize<T>( this IEnumerable<T> enumerable )
        {
            enumerable.ThrowIfNull(nameof(enumerable));

            var rnd = new Random();
            return enumerable.OrderBy( x => ( rnd.Next() ) );
        }
    }
}