#region Usings

using System;
using System.Collections.Generic;
using System.Linq;

#endregion

namespace PortableExtensions
{
    /// <summary>
    ///     Class containing some extension methods for <see cref="ISpecification{T}"/>.
    /// </summary>
    public static partial class SpecificationEx
    {
        /// <summary>
        ///     Creates a specification with the given condition and message.
        /// </summary>
        /// <typeparam name="T">The target type of the expression.</typeparam>
        /// <param name="obj">The object used to create the expression. (Can be null)</param>
        /// <param name="expression">An expression determining whether an object matches the specification or not.</param>
        /// <param name="message">An error messaged, returned when an object doesn't match the specification.</param>
        /// <returns>Returns a specification with the given condition and message.</returns>
        public static ISpecification<T> Specification<T> ( this T obj, Func<T, Boolean> expression, String message = null )
        {
            return CreateSpecification( expression, message );
        }

        /// <summary>
        ///     Creates a specification with the given condition and message.
        /// </summary>
        /// <typeparam name="T">The target type of the expression.</typeparam>
        /// <param name="enumerable">The enumerable to create the expression on.</param>
        /// <param name="expression">An expression determining whether an object matches the specification or not.</param>
        /// <param name="message">An error messaged, returned when an object doesn't match the specification.</param>
        /// <returns>Returns a specification with the given condition and message.</returns>
        public static ISpecification<T> SpecificationForItems<T> ( this IEnumerable<T> enumerable,
                                                                   Func<T, Boolean> expression,
                                                                   String message = null )
        {
            return CreateSpecification( expression, message );
        }

        /// <summary>
        ///     Creates a specification with the given condition and message.
        /// </summary>
        /// <typeparam name="T">The target type of the expression.</typeparam>
        /// <param name="expression">An expression determining whether an object matches the specification or not.</param>
        /// <param name="message">An error messaged, returned when an object doesn't match the specification.</param>
        /// <returns>Returns a specification with the given condition and message.</returns>
        private static ISpecification<T> CreateSpecification<T> ( Func<T, Boolean> expression, String message = null )
        {
            return new ExpressionSpecification<T>( expression, message );
        }

        /// <summary>
        /// Checks if the objects satisfies the given specification.
        /// </summary>
        /// <typeparam name="T">The type of the object.</typeparam>
        /// <param name="obj">The object to check.</param>
        /// <param name="specification">The specification to use.</param>
        /// <returns>Returns true if the object satisfies the specification; otherwise, false.</returns>
        public static Boolean Satisfies<T> ( this T obj, ISpecification<T> specification )
        {
            return specification.IsSatisfiedBy( obj );
        }

        /// <summary>
        /// Checks if the objects satisfies the given specification.
        /// </summary>
        /// <typeparam name="T">The type of the object.</typeparam>
        /// <param name="obj">The object to check.</param>
        /// <param name="specification">The specification to use.</param>
        /// <returns></returns>
        public static IEnumerable<String> SatisfiesWithMessages<T> ( this T obj, ISpecification<T> specification )
        {
            return specification.IsSatisfiedByWithMessages( obj );
        }

        /// <summary>
        /// Returns all items of the given enumerable which satisfy the given specification.
        /// </summary>
        /// <typeparam name="T">The type of the item in the enumerable.</typeparam>
        /// <param name="enumerable">The enumerable.</param>
        /// <param name="specification">The specification.</param>
        /// <returns>Returns the items which satisfy the given specification.</returns>
        public static IEnumerable<T> WhereSatisfies<T> ( this IEnumerable<T> enumerable, ISpecification<T> specification )
        {
            return enumerable.Where( specification.IsSatisfiedBy );
        }

        /// <summary>
        /// Returns all items of the given enumerable which doesn't satisfy the given specification.
        /// </summary>
        /// <typeparam name="T">The type of the item in the enumerable.</typeparam>
        /// <param name="enumerable">The enumerable.</param>
        /// <param name="specification">The specification.</param>
        /// <returns>Returns the items which doesn't satisfy the given specification.</returns>
        public static IEnumerable<T> WhereNotSatisfies<T> ( this IEnumerable<T> enumerable, ISpecification<T> specification )
        {
            return enumerable.Where( x => !specification.IsSatisfiedBy( x ) );
        }
    }
}