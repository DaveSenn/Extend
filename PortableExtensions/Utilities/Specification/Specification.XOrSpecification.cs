#region Usings

using System;
using System.Collections.Generic;
using System.Linq;

#endregion

namespace PortableExtensions
{
    /// <summary>
    ///     XOr specification.
    /// </summary>
    /// <typeparam name="T">The target type of the specification.</typeparam>
    public class XOrSpecification<T> : OperatorSpecification<T>
    {
        #region Ctor

        /// <summary>
        ///     Initialize a new instance of the <see cref="XOrSpecification{T}" /> class.
        /// </summary>
        /// <param name="left">The left specification.</param>
        /// <param name="right">The right specification.</param>
        public XOrSpecification ( ISpecification<T> left, ISpecification<T> right )
            : base( left, right )
        {
        }

        #endregion

        #region Overrides of Specification<T>

        /// <summary>
        ///     Validates the given object against the specification.
        /// </summary>
        /// <param name="obj">The object to validate.</param>
        /// <returns>Returns true if the object satisfies the specification; otherwise, false.</returns>
        public override Boolean Validate ( T obj )
        {
            return Left.Validate( obj ) ^ Right.Validate( obj );
        }

        /// <summary>
        ///     Validates the given object against the specification.
        /// </summary>
        /// <param name="obj">The object to validate.</param>
        /// <returns>Returns a collection of error messages.</returns>
        public override IEnumerable<String> ValidateWithMessages ( T obj )
        {
            var leftResult = Left.ValidateWithMessages( obj ).ToList();
            var rightResult = Right.ValidateWithMessages( obj ).ToList();

            if ( leftResult.NotAny() ^ rightResult.NotAny() )
                return new String[0];

            return leftResult.Concat( rightResult );
        }

        #endregion
    }
}