#region Usings

using System;
using System.Collections.Generic;
using JetBrains.Annotations;

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
        ///     Creates a specification with the given condition and message.
        /// </summary>
        /// <exception cref="ArgumentNullException">expression can not be null.</exception>
        /// <typeparam name="T">The target type of the expression.</typeparam>
        /// <param name="enumerable">The enumerable to create the expression on.</param>
        /// <param name="expression">An expression determining whether an object matches the specification or not.</param>
        /// <param name="message">An error messaged, returned when an object doesn't match the specification.</param>
        /// <returns>Returns a specification with the given condition and message.</returns>
        [Pure]
        [PublicAPI]
        [NotNull]
        public static ISpecification<T> SpecificationForItems<T>( [CanBeNull] [ItemCanBeNull] this IEnumerable<T> enumerable,
                                                                  [NotNull] Func<T, Boolean> expression,
                                                                  [CanBeNull] String message = null )
        {
            expression.ThrowIfNull( nameof( expression ) );

            return new ExpressionSpecification<T>( expression, message );
        }
    }
}