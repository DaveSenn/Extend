#region Usings

using System;
using JetBrains.Annotations;

#endregion

namespace Extend
{
    /// <summary>
    ///     Class containing some extension methods for <see cref="object" />.
    /// </summary>
    public static partial class ObjectEx
    {
        /// <summary>
        ///     Creates a specification with the given condition and message.
        /// </summary>
        /// <exception cref="ArgumentNullException">expression can not be null.</exception>
        /// <typeparam name="T">The target type of the expression.</typeparam>
        /// <param name="obj">The object used to create the expression. (Can be null)</param>
        /// <param name="expression">An expression determining whether an object matches the specification or not.</param>
        /// <param name="message">An error messaged, returned when an object doesn't match the specification.</param>
        /// <returns>Returns a specification with the given condition and message.</returns>
        [NotNull]
        [Pure]
        [PublicAPI]
        public static ISpecification<T> Specification<T>( [CanBeNull] this T obj, [NotNull] Func<T, Boolean> expression, [CanBeNull] String message = null )
        {
            expression.ThrowIfNull( nameof(expression) );

            return new ExpressionSpecification<T>( expression, message );
        }
    }
}