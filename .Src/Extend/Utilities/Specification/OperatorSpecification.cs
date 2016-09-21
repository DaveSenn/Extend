#region Usings

using System;
using JetBrains.Annotations;

#endregion

namespace Extend
{
    /// <summary>
    ///     Abstract base class for operator specifications.
    /// </summary>
    /// <typeparam name="T">The target type of the specification.</typeparam>
    public abstract class OperatorSpecification<T> : Specification<T>
    {
        #region Fields

        /// <summary>
        ///     The left specification.
        /// </summary>
        protected readonly ISpecification<T> Left;

        /// <summary>
        ///     The right specification.
        /// </summary>
        protected readonly ISpecification<T> Right;

        #endregion

        #region Ctor

        /// <summary>
        ///     Initialize a new instance of the <see cref="OperatorSpecification{T}" /> class.
        /// </summary>
        /// <exception cref="ArgumentNullException">left can not be null.</exception>
        /// <exception cref="ArgumentNullException">right can not be null.</exception>
        /// <param name="left">The left specification.</param>
        /// <param name="right">The right specification.</param>
        protected OperatorSpecification( [NotNull] ISpecification<T> left, [NotNull] ISpecification<T> right )
        {
            left.ThrowIfNull( nameof( left ) );
            right.ThrowIfNull( nameof( right ) );

            Left = left;
            Right = right;
        }

        #endregion
    }
}