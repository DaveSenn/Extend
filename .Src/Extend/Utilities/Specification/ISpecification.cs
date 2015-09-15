#region Usings

using System;
using System.Collections.Generic;

#endregion

namespace Extend
{
    /// <summary>
    ///     Interface representing a specification.
    /// </summary>
    /// <typeparam name="T">The target type of the specification.</typeparam>
    public interface ISpecification<T>
    {
        /// <summary>
        ///     Combines the current specification with the given specification using an AND link.
        /// </summary>
        /// <param name="specification">The specification to add.</param>
        /// <returns>Returns the combined specifications.</returns>
        ISpecification<T> And( ISpecification<T> specification );

        /// <summary>
        ///     Checks if the given objects satisfies the specification.
        /// </summary>
        /// <param name="obj">The object to validate.</param>
        /// <returns>Returns true if the object satisfies the specification; otherwise, false.</returns>
        Boolean IsSatisfiedBy( T obj );

        /// <summary>
        ///     Checks if the given objects satisfies the specification.
        /// </summary>
        /// <param name="obj">The object to validate.</param>
        /// <returns>Returns a collection of error messages.</returns>
        IEnumerable<String> IsSatisfiedByWithMessages( T obj );

        /// <summary>
        ///     Combines the current specification with the given specification using a OR link.
        /// </summary>
        /// <param name="specification">The specification to add.</param>
        /// <returns>Returns the combined specifications.</returns>
        ISpecification<T> Or( ISpecification<T> specification );

        /// <summary>
        ///     Combines the current specification with the given specification using a XOR link.
        /// </summary>
        /// <param name="specification">The specification to add.</param>
        /// <returns>Returns the combined specifications.</returns>
        ISpecification<T> XOr( ISpecification<T> specification );
    }
}