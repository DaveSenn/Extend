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
        ///     Converts the IEnumerable containing the groupings into a Dictionary of those groupings.
        /// </summary>
        /// <exception cref="ArgumentNullException">The groupings can not be null.</exception>
        /// <typeparam name="TKey">The type of the key.</typeparam>
        /// <typeparam name="TValue">The type of the items.</typeparam>
        /// <param name="groupings">The enumeration of groupings from a GroupBy() clause.</param>
        /// <returns>
        ///     Returns a dictionary of groupings such that the key of the dictionary is TKey type and the value is List of
        ///     TValue type.
        /// </returns>
        public static Dictionary<TKey, List<TValue>> ToDictionary<TKey, TValue>(
            this IEnumerable<IGrouping<TKey, TValue>> groupings )
        {
            groupings.ThrowIfNull( () => groupings );

            return groupings.ToDictionary( x => x.Key, x => x.ToList() );
        }
    }
}