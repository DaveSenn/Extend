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
        [Pure]
        [PublicAPI]
        [NotNull]
        public static String StringJoin<T>( [NotNull] [ItemCanBeNull] this IEnumerable<T> enumerable, String separator = "" )
        {
            enumerable.ThrowIfNull( nameof( enumerable ) );

            return String.Join( separator, enumerable );
        }

        /// <summary>
        ///     Concatenates all the elements of a IEnumerable, using the specified separator between each element.
        /// </summary>
        /// <exception cref="ArgumentNullException">The enumerable can not be null.</exception>
        /// <typeparam name="T">The type of the items in the IEnumerable.</typeparam>
        /// <param name="enumerable">An IEnumerable that contains the elements to concatenate.</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <param name="separator">
        ///     The string to use as a separator.
        ///     The separator is included in the returned string only if the given IEnumerable has more than one item.
        /// </param>
        /// <returns>
        ///     A string that consists of the elements in the IEnumerable delimited by the separator string.
        ///     If the given IEnumerable is empty, the method returns String.Empty.
        /// </returns>
        [Pure]
        [PublicAPI]
        [NotNull]
        public static String StringJoin<T>( [NotNull] [ItemCanBeNull] this IEnumerable<T> enumerable, [NotNull] Func<T, String> selector, String separator = "" )
        {
            enumerable.ThrowIfNull( nameof( enumerable ) );
            selector.ThrowIfNull( nameof( selector ) );

            return String.Join( separator, enumerable.Select( selector ) );
        }
    }
}