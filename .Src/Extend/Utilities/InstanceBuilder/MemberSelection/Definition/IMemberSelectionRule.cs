#region Usings

using System;
using JetBrains.Annotations;

#endregion

namespace Extend
{
    /// <summary>
    ///     Interface representing a member selection rule.
    /// </summary>
    public interface IMemberSelectionRule
    {
        #region Properties

        /// <summary>
        ///     Gets the name of the rule.
        /// </summary>
        /// <value>The name of the rule.</value>
        String RuleName { get; }

        /// <summary>
        ///     Gets the description of the rule.
        /// </summary>
        /// <value>The description of the rule.</value>
        String RuleDescription { get; }

        #endregion

        /// <summary>
        ///     Gets the selection result for the given member.
        /// </summary>
        /// <param name="member">The member to get the selection result for.</param>
        /// <returns>Returns the selection result for the given member.</returns>
        [PublicAPI]
        [NotNull]
        MemberSelectionResult GetSelectionResult( IMemberInformation member );
    }
}