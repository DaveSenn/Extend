#region Usings

using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        ///     Performs the specified action on each object in the given enumerable.
        /// </summary>
        /// <exception cref="ArgumentNullException">The source collection can not be null.</exception>
        /// <exception cref="ArgumentNullException">The action can not be null.</exception>
        /// <typeparam name="T">The type of the items in the given enumerable.</typeparam>
        /// <param name="enumerable">The enumerable containing all the items.</param>
        /// <param name="action">The action to perform on each item of the given enumerable.</param>
        [PublicAPI]
        [NotNull]
        [DebuggerStepThrough]
        public static IEnumerable<T> ForEach<T>( [NotNull] [ItemCanBeNull] this IEnumerable<T> enumerable, [NotNull] Action<T> action )
        {
            enumerable.ThrowIfNull( nameof(enumerable) );
            action.ThrowIfNull( nameof(action) );

            var forEach = enumerable as IList<T> ?? enumerable.ToList();
            foreach ( var x in forEach )
                action( x );

            return forEach;
        }

        /// <summary>
        ///     Performs the specified action on each object in the given enumerable.
        /// </summary>
        /// <exception cref="ArgumentNullException">The source collection can not be null.</exception>
        /// <exception cref="ArgumentNullException">The action can not be null.</exception>
        /// <typeparam name="T">The type of the items in the given enumerable.</typeparam>
        /// <param name="enumerable">The enumerable containing all the items.</param>
        /// <param name="action">
        ///     The action to perform on each item of the given enumerable.
        ///     The action takes a item of the given enumerable and it's index as parameter.
        /// </param>
        [PublicAPI]
        [NotNull]
        [DebuggerStepThrough]
        public static IEnumerable<T> ForEach<T>( [NotNull] [ItemCanBeNull] this IEnumerable<T> enumerable, [NotNull] Action<T, Int32> action )
        {
            enumerable.ThrowIfNull( nameof(enumerable) );
            action.ThrowIfNull( nameof(action) );

            var counter = 0;
            var forEach = enumerable as IList<T> ?? enumerable.ToList();
            foreach ( var x in forEach )
                action( x, counter++ );

            return forEach;
        }
    }
}