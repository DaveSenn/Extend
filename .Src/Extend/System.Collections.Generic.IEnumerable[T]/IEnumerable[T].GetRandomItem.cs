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
        ///     Gets a random item form the given IEnumerable.
        /// </summary>
        /// <exception cref="ArgumentNullException">The enumerable can not be null.</exception>
        /// <typeparam name="T">The type of the items in the enumerable.</typeparam>
        /// <param name="enumerable">The IEnumerable.</param>
        /// <returns>Returns an random item of the given IEnumerable.</returns>
        [Pure]
        [PublicAPI]
        [CanBeNull]
        public static T GetRandomItem<T>( [NotNull] [ItemCanBeNull] this IEnumerable<T> enumerable )
        {
            enumerable.ThrowIfNull( nameof(enumerable) );

            var list = enumerable as IList<T> ?? enumerable.ToList();
            var index = RandomValueEx.GetRandomInt32( 0, list.Count );
            return list.ElementAt( index );
        }
    }
}