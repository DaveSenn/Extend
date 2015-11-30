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
        ///     Appends the given item to the given sequence.
        /// </summary>
        /// <exception cref="ArgumentNullException">source can not be null.</exception>
        /// <typeparam name="T">The type of the items in the IEnumerable.</typeparam>
        /// <param name="source">The sequence to append an item to.</param>
        /// <param name="item">The item to append.</param>
        /// <returns>The source sequence followed by the appended item.</returns>
        public static IEnumerable<T> Append<T>( this IEnumerable<T> source, T item )
        {
            // ReSharper disable PossibleMultipleEnumeration
            source.ThrowIfNull( nameof( source ) );

            source = source.Concat( new[] { item } );
            return source;
            // ReSharper restore PossibleMultipleEnumeration
        }
    }
}