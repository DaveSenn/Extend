#region Usings

using System;
using System.Collections.Generic;
using JetBrains.Annotations;

#endregion

namespace Extend
{
    /// <summary>
    ///     Abstract base class for a specification.
    /// </summary>
    /// <typeparam name="T">The target type of the specification.</typeparam>
    public abstract class Specification<T> : ISpecification<T>
    {
        #region Implementation of ISpecification<T>

        /// <summary>
        ///     Checks if the given objects satisfies the specification.
        /// </summary>
        /// <param name="obj">The object to validate.</param>
        /// <returns>Returns true if the object satisfies the specification; otherwise, false.</returns>
        public abstract Boolean IsSatisfiedBy( T obj );

        /// <summary>
        ///     Checks if the given objects satisfies the specification.
        /// </summary>
        /// <param name="obj">The object to validate.</param>
        /// <returns>Returns a collection of error messages.</returns>
        public abstract IEnumerable<String> IsSatisfiedByWithMessages( T obj );

        /// <summary>
        ///     Combines the current specification with the given specification using an AND link.
        /// </summary>
        /// <param name="specification">The specification to add.</param>
        /// <returns>Returns the combined specifications.</returns>
        public ISpecification<T> And( ISpecification<T> specification ) 
            => new AndSpecification<T>( this, specification );

        /// <summary>
        ///     Combines the current specification with the given specification using a OR link.
        /// </summary>
        /// <param name="specification">The specification to add.</param>
        /// <returns>Returns the combined specifications.</returns>
        public ISpecification<T> Or( ISpecification<T> specification ) 
            => new OrSpecification<T>( this, specification );

        /// <summary>
        ///     Combines the current specification with the given specification using a XOR link.
        /// </summary>
        /// <param name="specification">The specification to add.</param>
        /// <returns>Returns the combined specifications.</returns>
        public ISpecification<T> XOr( ISpecification<T> specification ) 
            => new XOrSpecification<T>( this, specification );

        #endregion
    }
}