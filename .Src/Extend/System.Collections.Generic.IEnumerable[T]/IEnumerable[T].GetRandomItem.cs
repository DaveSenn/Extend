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
        ///     Gets a random item form the given IEnumerable.
        /// </summary>
        /// <exception cref="ArgumentNullException">The enumerable can not be null.</exception>
        /// <typeparam name="T">The type of the items in the enumerable.</typeparam>
        /// <param name="enumerable">The IEnumerable.</param>
        /// <returns>Returns an random item of the given IEnumerable.</returns>
        public static T GetRandomItem<T>( this IEnumerable<T> enumerable )
        {
            enumerable.ThrowIfNull( nameof( enumerable ) );

            var array = enumerable as T[] ?? enumerable.ToArray();

            var index = RandomValueEx.GetRandomInt32( 0, array.Count() );
            return array.ElementAt( index );
        }
    }
}