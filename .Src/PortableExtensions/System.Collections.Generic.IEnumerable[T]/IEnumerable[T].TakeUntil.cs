#region Usings

using System;
using System.Collections.Generic;
using System.Linq;

#endregion

namespace PortableExtensions
{
    /// <summary>
    ///     Class containing some extension methods for <see cref="IEnumerable{T}" />.
    /// </summary>
    // ReSharper disable once InconsistentNaming
    public static partial class IEnumerableTEx
    {
        /// <summary>
        ///     Takes items from the given IEnumerable until the first item matches the specified predicate.
        /// </summary>
        /// <exception cref="ArgumentNullException">The enumerable can not be null.</exception>
        /// <exception cref="ArgumentNullException">The predicate can not be null.</exception>
        /// <param name="enumerable">The IEnumerable.</param>
        /// <param name="predicate">The predicate.</param>
        /// <typeparam name="T">The type of the items in the IEnumerable.</typeparam>
        /// <returns>Returns the items from the start of the IEnumerable until the first item matching the predicate.</returns>
        public static IEnumerable<T> TakeUntil<T>( this IEnumerable<T> enumerable, Func<T, Boolean> predicate )
        {
            enumerable.ThrowIfNull( () => enumerable );
            predicate.ThrowIfNull( () => predicate );

            return enumerable.TakeWhile( x => !predicate( x ) );
        }
    }
}