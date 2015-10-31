#region Usings

using System;

#endregion

namespace Extend
{
    /// <summary>
    ///     Interface representing a expression based condition.
    /// </summary>
    public interface IExpressionInstanceBuilderCondition : IInstanceBuilderCondition
    {
        #region Properties

        /// <summary>
        ///     Gets the predicate.
        /// </summary>
        /// <value>The predicate.</value>
        Func<IInstanceValueArguments, Boolean> Predicate { get; }

        #endregion
    }
}