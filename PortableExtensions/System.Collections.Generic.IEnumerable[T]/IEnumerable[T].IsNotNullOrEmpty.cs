#region Using

using System;
using System.Collections.Generic;
using System.Linq;

#endregion

namespace PortableExtensions
{
    /// <summary>
    ///     Class containing some extension methods for <see cref="ICollection{T}" />.
    /// </summary>
// ReSharper disable once InconsistentNaming
    public static partial class IEnumerableTEx
    {
        /// <summary>
        ///     Checks if the collection is not empty or null.
        /// </summary>
        /// <typeparam name="T">The type of the items in the collection.</typeparam>
        /// <param name="collection">The collection to check.</param>
        /// <returns>Returns true if the collection is not empty or null, otherwise false.</returns>
        public static Boolean IsNotNullOrEmpty<T>( this IEnumerable<T> collection )
        {
            return collection.IsNotNull() && collection.Any();
        }
    }
}