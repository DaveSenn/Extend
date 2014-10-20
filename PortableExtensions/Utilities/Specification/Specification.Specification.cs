#region Usings

using System;
using System.Collections.Generic;

#endregion

namespace PortableExtensions
{
    /// <summary>
    ///     Abstract base class for a specification.
    /// </summary>
    /// <typeparam name="T">The target type of the specification.</typeparam>
    public abstract class Specification<T> : ISpecification<T>
    {
        #region Implementation of ISpecification<T>

        /// <summary>
        ///     Validates the given object against the specification.
        /// </summary>
        /// <param name="obj">The object to validate.</param>
        /// <returns>Returns true if the object satisfies the specification; otherwise, false.</returns>
        public abstract Boolean Validate ( T obj );

        /// <summary>
        ///     Validates the given object against the specification.
        /// </summary>
        /// <param name="obj">The object to validate.</param>
        /// <returns>Returns a collection of error messages.</returns>
        public abstract IEnumerable<String> ValidateWithMessages ( T obj );

        /// <summary>
        ///     Combines the current specification with the given specification using an AND link.
        /// </summary>
        /// <param name="specification">The specification to add.</param>
        /// <returns>Returns the combined specifications.</returns>
        public ISpecification<T> And ( ISpecification<T> specification )
        {
            return new AndSpecification<T>( this, specification );
        }

        /// <summary>
        ///     Combines the current specification with the given specification using a OR link.
        /// </summary>
        /// <param name="specification">The specification to add.</param>
        /// <returns>Returns the combined specifications.</returns>
        public ISpecification<T> Or ( ISpecification<T> specification )
        {
            return new OrSpecification<T>( this, specification );
        }

        /// <summary>
        ///     Combines the current specification with the given specification using a XOR link.
        /// </summary>
        /// <param name="specification">The specification to add.</param>
        /// <returns>Returns the combined specifications.</returns>
        public ISpecification<T> Xor ( ISpecification<T> specification )
        {
            return new XOrSpecification<T>( this, specification );
        }

        #endregion
    }
}