#region Usings

using System;
using System.Collections;
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
        ///     Performs an performance optimized count.
        /// </summary>
        /// <typeparam name="T">The type of the items in the sequence.</typeparam>
        /// <param name="enumerable">A sequence of items.</param>
        /// <returns>Returns the number of items in the sequence.</returns>
        public static Int32 CountOptimized<T>( this IEnumerable<T> enumerable )
        {
            enumerable.ThrowIfNull( () => enumerable );

            var collectionT = enumerable as ICollection<T>;
            if ( collectionT != null )
                return collectionT.Count;

            var collection = enumerable as ICollection;
            return collection != null ? collection.Count : enumerable.Count();
        }
    }
}