#region Usings

using System;
using System.Collections.Generic;
using System.Linq;

#endregion

namespace Extend
{
    /// <summary>
    ///     Collection of conditions.
    /// </summary>
    public class InstanceBuilderConditionCollection : List<IInstanceBuilderCondition>, IInstanceBuilderConditionCollection
    {
        #region Implementation of IInstanceBuilderConditionCollection

        /// <summary>
        ///     Gets or sets the combination option.
        /// </summary>
        /// <value>The combination option.</value>
        public ConditionCombinationOption CombinationOption { get; set; }

        /// <summary>
        ///     Determines wheter the given arguments matches the conditions or not.
        /// </summary>
        /// <param name="arguments">The arguments to check.</param>
        /// <returns>Returns a value of true if the arguments matches the conditions; oterwise, false.</returns>
        public Boolean Matches( IInstanceValueArguments arguments )
        {
            switch ( CombinationOption )
            {
                case ConditionCombinationOption.MatchAll:
                    return this.Any() && this.All( x => x.Matches( arguments ) );
                case ConditionCombinationOption.MatchAny:
                    return this.Any( x => x.Matches( arguments ) );
                case ConditionCombinationOption.NotMatchAny:
                    return this.Any() && this.All( x => !x.Matches( arguments ) );
                default:
                    throw new ArgumentOutOfRangeException( nameof( arguments ), arguments, $"Value '{arguments}' is not supported." );
            }
        }

        #endregion
    }
}