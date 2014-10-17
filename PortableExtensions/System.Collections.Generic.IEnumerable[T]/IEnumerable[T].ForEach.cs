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
        ///     Performs the specified action on each object in the given enumerable.
        /// </summary>
        /// <exception cref="ArgumentNullException">The source collection can not be null.</exception>
        /// <exception cref="ArgumentNullException">The action can not be null.</exception>
        /// <typeparam name="T">The type of the items in the given enumerable.</typeparam>
        /// <param name="enumerable">The enumerable containing all the items.</param>
        /// <param name="action">The action to perform on each item of the given enumerable.</param>
        public static IEnumerable<T> ForEach<T> ( this IEnumerable<T> enumerable, Action<T> action )
        {
            enumerable.ThrowIfNull( () => enumerable );
            action.ThrowIfNull( () => action );

            foreach ( var x in enumerable )
                action( x );

            return enumerable;
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
        public static IEnumerable<T> ForEach<T> ( this IEnumerable<T> enumerable, Action<T, Int32> action )
        {
            enumerable.ThrowIfNull( () => enumerable );
            action.ThrowIfNull( () => action );

            var counter = 0;
            foreach ( var x in enumerable )
                action( x, counter++ );

            return enumerable;
        }
    }
}