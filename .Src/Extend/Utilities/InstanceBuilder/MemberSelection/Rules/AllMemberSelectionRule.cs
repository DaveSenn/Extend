#region Usings

using System;

#endregion

namespace Extend
{
    /// <summary>
    ///     Member selection rule matching all members.
    /// </summary>
    public class AllMemberSelectionRule : MemberSelectionRuleBase
    {
        #region Fields

        /// <summary>
        ///     Gets the selection mode.
        /// </summary>
        /// <value>The selection mode.</value>
        private readonly MemberSelectionMode _selectionMode;

        #endregion

        #region Ctor

        /// <summary>
        ///     Initializes a new instance of the <see cref="AllMemberSelectionRule" /> class.
        /// </summary>
        /// <param name="selectionMode">The selection mode to apply.</param>
        /// <param name="name">The name of the rule.</param>
        /// <param name="description">The description of the rule.</param>
        public AllMemberSelectionRule( MemberSelectionMode selectionMode, String name = null, String description = null )
            : base( name, description ) => _selectionMode = selectionMode;

        #endregion

        #region Overrides of MemberSelectionRuleBase

        /// <summary>
        ///     Gets the selection result for the given member.
        /// </summary>
        /// <param name="member">The member to get the selection result for.</param>
        /// <returns>Returns the selection result for the given member.</returns>
        public override MemberSelectionResult GetSelectionResult( IMemberInformation member )
            => _selectionMode == MemberSelectionMode.Include
                ? MemberSelectionResult.IncludeMember
                : MemberSelectionResult.ExcludeMember;

        #endregion

        #region Overrides of Object

        /// <summary>
        ///     Returns a string that represents the current object.
        /// </summary>
        /// <returns>
        ///     A string that represents the current object.
        /// </returns>
        public override String ToString()
            => $"[{RuleName}] = ({_selectionMode} all members) ({RuleDescription}).";

        #endregion
    }
}