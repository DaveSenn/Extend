#region Usings

using System;
using System.Collections.Generic;

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
        ///     Concatenates all the elements of a IEnumerable, using the specified separator between each element.
        /// </summary>
        /// <exception cref="ArgumentNullException">The enumerable can not be null.</exception>
        /// <typeparam name="T">The type of the items in the IEnumerable.</typeparam>
        /// <param name="enumerable">An IEnumerable that contains the elements to concatenate.</param>
        /// <param name="separator">
        ///     The string to use as a separator.
        ///     The separator is included in the returned string only if the given IEnumerable has more than one item.
        /// </param>
        /// <returns>
        ///     A string that consists of the elements in the IEnumerable delimited by the separator string.
        ///     If the given IEnumerable is empty, the method returns String.Empty.
        /// </returns>
        public static String StringJoin<T> ( this IEnumerable<T> enumerable, String separator = "" )
        {
            enumerable.ThrowIfNull( () => enumerable );

            return String.Join( separator, enumerable );
        }
    }
}