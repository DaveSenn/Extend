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
        //public static IEnumerable<T> Slice<T>(this IEnumerable<T> enumerable, Int32 start, Int32 end)
        //{
        //    enumerable.ThrowIfNull(() => enumerable);

        //    int index = 0;
        //    int count = 0;


        //    // Optimise item count for ICollection interfaces.
        //    if (enumerable is ICollection<T>)
        //        count = ((ICollection<T>)enumerable).Count;
        //    else if (enumerable is ICollection)
        //        count = ((ICollection)enumerable).Count;
        //    else
        //        count = enumerable.Count();

        //    // Get start/end indexes, negative numbers start at the end of the enumerable.
        //    if (start < 0)
        //        start += count;

        //    if (end < 0)
        //        end += count;

        //    foreach (var item in enumerable)
        //    {
        //        if (index >= end)
        //            yield break;

        //        if (index >= start)
        //            yield return item;

        //        ++index;
        //    }
        //}

        /// <summary>
        ///     Performs an performance optimised count.
        /// </summary>
        /// <typeparam name="T">The type fo the items in the sequence.</typeparam>
        /// <param name="enumerable">A sequence of items.</param>
        /// <returns>Returns the number of items in the sequence.</returns>
        public static Int32 CountOptimise<T>(this IEnumerable<T> enumerable)
        {
            enumerable.ThrowIfNull(() => enumerable);

            var array = enumerable as T[];

            var collectionT = enumerable as ICollection<T>;
            if (collectionT != null)
                return collectionT.Count;


            var collection = enumerable as ICollection;
            return collection != null ? collection.Count : enumerable.Count();
        }
    }
}