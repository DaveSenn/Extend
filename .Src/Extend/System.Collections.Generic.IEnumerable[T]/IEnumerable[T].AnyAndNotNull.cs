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
        ///     Checks if the given IEnumerable is not null and contains some items.
        /// </summary>
        /// <example>
        ///     <code> 
        ///         List&lt;String&gt; strings = null;
        ///         Console.WriteLine( strings.AnyAndNotNull() ); // False
        ///         strings = new List&lt;String&gt;();
        ///         Console.WriteLine( strings.AnyAndNotNull() ); // False
        ///         strings.AddRange( "1", "2", "3" );
        ///         Console.WriteLine( strings.AnyAndNotNull() ); // True
        ///     </code>
        /// </example>
        /// <typeparam name="T">The type of the items in the IEnumerable.</typeparam>
        /// <param name="enumerable">The IEnumerable to act on.</param>
        /// <returns>Returns true if the IEnumerable is not null or empty, otherwise false.</returns>
        [Pure]
        [PublicAPI]
        public static Boolean AnyAndNotNull<T>( [CanBeNull] [ItemCanBeNull] this IEnumerable<T> enumerable )
            => enumerable != null
               && enumerable.Any();

        /// <summary>
        ///     Checks if the given IEnumerable is not null and contains some items
        ///     which mates the given predicate.
        /// </summary>
        /// <exception cref="ArgumentNullException">The predicate can not be null.</exception>
        /// <typeparam name="T">The type of the items in the IEnumerable.</typeparam>
        /// <param name="enumerable">The IEnumerable to act on.</param>
        /// <param name="predicate">The predicate.</param>
        /// <returns>Returns true if the IEnumerable is not null or empty, otherwise false.</returns>
        [Pure]
        [PublicAPI]
        public static Boolean AnyAndNotNull<T>( [CanBeNull] [ItemCanBeNull] this IEnumerable<T> enumerable, [NotNull] Func<T, Boolean> predicate )
        {
            predicate.ThrowIfNull( nameof( predicate ) );

            return enumerable != null && enumerable.Any( predicate );
        }
    }
}