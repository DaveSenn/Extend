#region Usings

using System;

#endregion

namespace Extend
{
    /// <summary>
    ///     Base class for member selection rules.
    /// </summary>
    public abstract class MemberSelectionRuleBase : IMemberSelectionRule
    {
        #region Ctor

        /// <summary>
        ///     Initializes a new instance of the <see cref="MemberSelectionRuleBase" /> class.
        /// </summary>
        /// <param name="name">The name of the rule.</param>
        /// <param name="description">The description of the rule.</param>
        protected MemberSelectionRuleBase( String name, String description )
        {
            RuleName = name;
            RuleDescription = description;
        }

        #endregion

        #region Implementation of IMemberSelectionRule

        /// <summary>
        ///     Gets the selection result for the given member.
        /// </summary>
        /// <param name="member">The member to get the selection result for.</param>
        /// <returns>Returns the selection result for the given member.</returns>
        public abstract MemberSelectionResult GetSelectionResult( IMemberInformation member );

        /// <summary>
        ///     Gets the name of the rule.
        /// </summary>
        /// <value>The name of the rule.</value>
        public String RuleName { get; }

        /// <summary>
        ///     Gets the description of the rule.
        /// </summary>
        /// <value>The description of the rule.</value>
        public String RuleDescription { get; }

        #endregion
    }
}