#region Usings

using System;

#endregion

namespace Extend
{
    /// <summary>
    ///     Expression based condition.
    /// </summary>
    public class ExpressionInstanceBuilderCondition : IExpressionInstanceBuilderCondition
    {
        #region Ctor

        /// <summary>
        ///     Initializes a new instance of the <see cref="ExpressionInstanceBuilderCondition" /> class.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        public ExpressionInstanceBuilderCondition( Func<IInstanceValueArguments, Boolean> predicate )
        {
            Predicate = predicate;
        }

        #endregion

        #region IExpressionInstanceBuilderCondition of IInstanceBuilderCondition

        /// <summary>
        ///     Gets the predicate.
        /// </summary>
        /// <value>The predicate.</value>
        public Func<IInstanceValueArguments, Boolean> Predicate { get; }

        /// <summary>
        ///     Determines wheter the given arguments matches the condition or not.
        /// </summary>
        /// <exception cref="ArgumentNullException">arguments can not be null.</exception>
        /// <param name="arguments">The arguments to check.</param>
        /// <returns>Returns a value of true if the arguments matches the condition; oterwise, false.</returns>
        public Boolean Matches( IInstanceValueArguments arguments )
        {
            arguments.ThrowIfNull( nameof( arguments ) );

            return Predicate( arguments );
        }

        #endregion
    }
}