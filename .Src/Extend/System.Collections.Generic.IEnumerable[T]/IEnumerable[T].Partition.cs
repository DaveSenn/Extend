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
        ///     Partitions the given sequence into blocks with the specified size.
        /// </summary>
        /// <exception cref="ArgumentNullException">source can not be null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">size is smaller than 1.</exception>
        /// <typeparam name="T">The type of the items in the IEnumerable.</typeparam>
        /// <param name="source">The sequence to partition.</param>
        /// <param name="size">The number of items per block.</param>
        /// <returns>Returns the created blocks.</returns>
        [Pure]
        [PublicAPI]
        [NotNull]
        public static IEnumerable<IEnumerable<T>> Partition<T>( [NotNull] [ItemCanBeNull] this IEnumerable<T> source, Int32 size )
        {
            source.ThrowIfNull( nameof(source) );
            if ( size < 1 )
                throw new ArgumentOutOfRangeException( nameof(size), size, $"{nameof(size)} is out of range. Size must be > 1." );

            return source
                .WithIndex()
                .GroupBy( x => x.Index / size )
                .Select( x => x.WithoutIndex() );
        }
    }
}