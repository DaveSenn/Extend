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
        ///     Returns all items of the given enumerable which doesn't satisfy the given specification.
        /// </summary>
        /// <exception cref="ArgumentNullException">specification can not be null.</exception>
        /// <typeparam name="T">The type of the item in the enumerable.</typeparam>
        /// <param name="enumerable">The enumerable.</param>
        /// <param name="specification">The specification.</param>
        /// <returns>Returns the items which doesn't satisfy the given specification.</returns>
        public static IEnumerable<T> WhereNot<T>( this IEnumerable<T> enumerable, ISpecification<T> specification )
        {
            specification.ThrowIfNull( nameof( specification ) );

            return enumerable.Where( x => !specification.IsSatisfiedBy( x ) );
        }
    }
}