#region Usings

using System;

#endregion

namespace Extend
{
    /// <summary>
    ///     Class containing some extension methods for <see cref="ISpecification{T}" />.
    /// </summary>
    public static partial class SpecificationEx
    {
        /// <summary>
        ///     Combines the current specification with the given expression using a XOr link.
        /// </summary>
        /// <exception cref="ArgumentNullException">specification can not be null.</exception>
        /// <exception cref="ArgumentNullException">expression can not be null.</exception>
        /// <typeparam name="T">The target type of the specification.</typeparam>
        /// <param name="specification">The current specification.</param>
        /// <param name="expression">The expression to add.</param>
        /// <param name="message">The validation error message.</param>
        /// <returns>Returns the combined specifications.</returns>
        public static ISpecification<T> XOr<T>( this ISpecification<T> specification,
                                                Func<T, Boolean> expression,
                                                String message = null )
        {
            specification.ThrowIfNull( nameof( specification ) );
            expression.ThrowIfNull( nameof( expression ) );

            var newSpecification = new ExpressionSpecification<T>( expression, message );
            return specification.XOr( newSpecification );
        }
    }
}