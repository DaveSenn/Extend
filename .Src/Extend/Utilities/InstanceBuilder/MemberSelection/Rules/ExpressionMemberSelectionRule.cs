#region Usings

using System;
using JetBrains.Annotations;

#endregion

namespace Extend
{
    /// <summary>
    ///     Expression based member selection rule.
    /// </summary>
    public class ExpressionMemberSelectionRule : MemberSelectionRuleBase
    {
        #region Fields

        /// <summary>
        ///     Gets the member selection predicate.
        /// </summary>
        /// <value>The member selection predicate.</value>
        private readonly Func<IMemberInformation, Boolean> _predicate;

        /// <summary>
        ///     Gets the selection mode.
        /// </summary>
        /// <value>The selection mode.</value>
        private readonly MemberSelectionMode _selectionMode;

        #endregion

        #region Ctor

        /// <summary>
        ///     Initializes a new instance of the <see cref="ExpressionMemberSelectionRule" /> class.
        /// </summary>
        /// <exception cref="ArgumentNullException">predicate can not be null.</exception>
        /// <param name="predicate">The predicate used to determine if a member matches the rule.</param>
        /// <param name="selectionMode">The selection mode to apply.</param>
        /// <param name="name">The name of the rule.</param>
        /// <param name="description">The description of the rule.</param>
        public ExpressionMemberSelectionRule( [NotNull] Func<IMemberInformation, Boolean> predicate,
                                              MemberSelectionMode selectionMode,
                                              String name = null,
                                              String description = null )
            : base( name, description )
        {
            predicate.ThrowIfNull( nameof(predicate) );

            _predicate = predicate;
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
            var predicateReult = _predicate( member );
            if ( !predicateReult )
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
            => $"[{RuleName}] = ({_selectionMode} members matching predicate) ({RuleDescription}).";

        #endregion
    }
}