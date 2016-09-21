#region Usings

using System;
using JetBrains.Annotations;

#endregion

namespace Extend
{
    /// <summary>
    ///     Path based member selection rule.
    /// </summary>
    public class PathMemberSelectionRule : MemberSelectionRuleBase
    {
        #region Fields

        /// <summary>
        ///     Gets the member path used to find matching members.
        /// </summary>
        private readonly String _memberPath;

        /// <summary>
        ///     Gets the selection mode.
        /// </summary>
        private readonly MemberSelectionMode _selectionMode;

        #endregion

        #region Ctor

        /// <summary>
        ///     Initializes a new instance of the <see cref="PathMemberSelectionRule" /> class.
        /// </summary>
        /// <param name="memberPath">The member path used to find matching members.</param>
        /// <param name="selectionMode">The selection mode to apply.</param>
        /// <param name="name">The name of the rule.</param>
        /// <param name="description">The description of the rule.</param>
        public PathMemberSelectionRule( [NotNull] String memberPath, MemberSelectionMode selectionMode, String name = null, String description = null )
            : base( name, description )
        {
            memberPath.ThrowIfNull( nameof( memberPath ) );

            _memberPath = memberPath;
            _selectionMode = selectionMode;
        }

        #endregion

        #region Overrides of MemberSelectionRuleBase

        /// <summary>
        ///     Gets the selection result for the given member.
        /// </summary>
        /// <param name="member">The member to get the selection result for.</param>
        /// <returns>Returns the selection result for the given member.</returns>
        public override MemberSelectionResult GetSelectionResult( IMemberInformation member )
        {
            var matchesPath = member.MemberPath == _memberPath;
            if ( !matchesPath )
                return MemberSelectionResult.Neutral;

            return _selectionMode == MemberSelectionMode.Include
                ? MemberSelectionResult.IncludeMember
                : MemberSelectionResult.ExcludeMember;
        }

        #endregion

        #region Overrides of Object

        /// <summary>
        ///     Returns a string that represents the current object.
        /// </summary>
        /// <returns>
        ///     A string that represents the current object.
        /// </returns>
        public override String ToString()
            => $"[{RuleName}] = ({_selectionMode} members at {_memberPath}) ({RuleDescription}).";

        #endregion
    }
}