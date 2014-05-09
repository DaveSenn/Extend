using System;
using System.Collections;
using System.Collections.Generic;

namespace PortableExtensions
{
    /// <summary>
    /// Class containing some extension methods for <see cref="IEnumerable"/> and <see cref="IEnumerable{T}" />.
    /// </summary>
    public static class EnumerableEx
    {
        /// <summary>
        /// Performs the specified action on each object in the given enumerable.
        /// </summary>
        /// <exception cref="ArgumentNullException">Source colelction can not be null.</exception>
        /// <exception cref="ArgumentNullException">Action can not be null.</exception> <typeparam name="T">The type of the items in the given enumerable.</typeparam>
        /// <param name="enumerable">The enumerable containing all the items.</param>
        /// <param name="action">The action to perform on each item of the given enumerable.</param>
        public static void ForEach<T>( this IEnumerable<T> enumerable, Action<T> action )
        {
            if( enumerable == null )
                throw new ArgumentNullException ( "enumerable", "Source colelction can not be null." );
            if( action == null )
                throw new ArgumentNullException ( "action", "Action can not be null." );

            foreach( var x in enumerable )
                action ( x );
        }
    }
}