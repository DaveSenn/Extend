#region Usings

using System;
using System.Collections.Generic;

#endregion

namespace PortableExtensions
{
    /// <summary>
    ///     Class representing an expression specification.
    /// </summary>
    /// <typeparam name="T">The target type of the specification.</typeparam>
    public class ExpressionSpecification<T> : Specification<T>
    {
        #region Fields

        /// <summary>
        ///     The predicate used to validate the given objects.
        /// </summary>
        private readonly Func<T, bool> _expression;

        /// <summary>
        ///     The error message.
        /// </summary>
        private readonly String _message;

        #endregion

        #region Ctor

        /// <summary>
        ///     Initialize a new instance of the <see cref="ExpressionSpecification{T}" /> class.
        /// </summary>
        /// <param name="expression">The validation expression.</param>
        /// <param name="message">The validation error message.</param>
        public ExpressionSpecification ( Func<T, Boolean> expression, String message = null )
        {
            expression.ThrowIfNull( () => expression );

            _expression = expression;
            _message = message;
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
            return _expression( obj );
        }

        /// <summary>
        ///     Validates the given object against the specification.
        /// </summary>
        /// <param name="obj">The object to validate.</param>
        /// <returns>Returns a collection of error messages.</returns>
        public override IEnumerable<String> ValidateWithMessages ( T obj )
        {
            var result = _expression( obj );
            if ( result )
                return new String[0];
            return new List<String> {_message};
        }

        #endregion
    }
}