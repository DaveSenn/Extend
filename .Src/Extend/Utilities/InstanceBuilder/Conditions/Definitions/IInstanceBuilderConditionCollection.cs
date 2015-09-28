#region Usings

using System;
using System.Collections.Generic;

#endregion

namespace Extend
{
    /// <summary>
    ///     Interface representing a collection of conditions.
    /// </summary>
    public interface IInstanceBuilderConditionCollection : ICollection<IInstanceBuilderCondition>
    {
        #region Properties

        /// <summary>
        ///     Gets or sets the combination option.
        /// </summary>
        /// <value>The combination option.</value>
        ConditionCombinationOption CombinationOption { get; set; }

        #endregion

        /// <summary>
        ///     Determines wheter the given arguments matches the conditions or not.
        /// </summary>
        /// <param name="arguments">The arguments to check.</param>
        /// <returns>Returns a value of true if the arguments matches the conditions; oterwise, false.</returns>
        Boolean Matches( IInstanceValueArguments arguments );
    }
}