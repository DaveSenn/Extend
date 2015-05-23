#region Usings

using System;
using System.Collections.Generic;

#endregion

namespace Extend
{
    /// <summary>
    ///     Class containing some extension methods for <see cref="object" />.
    /// </summary>
    public static partial class ObjectEx
    {
        /// <summary>
        ///     Checks if the objects satisfies the given specification.
        /// </summary>
        /// <exception cref="ArgumentNullException">specification can not be null.</exception>
        /// <typeparam name="T">The type of the object.</typeparam>
        /// <param name="obj">The object to check.</param>
        /// <param name="specification">The specification to use.</param>
        /// <returns></returns>
        public static IEnumerable<String> SatisfiesWithMessages<T>( this T obj, ISpecification<T> specification )
        {
            specification.ThrowIfNull( () => specification );

            return specification.IsSatisfiedByWithMessages( obj );
        }
    }
}