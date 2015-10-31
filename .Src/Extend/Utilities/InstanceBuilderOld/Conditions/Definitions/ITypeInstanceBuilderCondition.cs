#region Usings

using System;

#endregion

namespace Extend
{
    /// <summary>
    ///     Interface representing a type based condition.
    /// </summary>
    public interface ITypeInstanceBuilderCondition : IInstanceBuilderCondition
    {
        #region Properties

        /// <summary>
        ///     Gets the type to match.
        /// </summary>
        /// <value>The type to match.</value>
        Type Type { get; }

        #endregion
    }
}