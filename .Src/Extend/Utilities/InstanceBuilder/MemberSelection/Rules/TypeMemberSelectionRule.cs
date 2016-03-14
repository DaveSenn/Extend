#region Usings

using System;

#endregion

namespace Extend
{
    /// <summary>
    ///     Type based member selection rule.
    /// </summary>
    public class TypeMemberSelectionRule : MemberSelectionRuleBase
    {
        #region Fields

        /// <summary>
        ///     Gets the compare mode of the selection rule.
        /// </summary>
        /// <value>The compare mode of the selection rule.</value>
        private readonly CompareMode _compareMode;

        /// <summary>
        ///     Gets the selection mode.
        /// </summary>
        /// <value>The selection mode.</value>
        private readonly MemberSelectionMode _selectionMode;

        /// <summary>
        ///     Gets the type to compare with the type of given members.
        /// </summary>
        /// <value>The type to compare with the type of given members.</value>
        private readonly Type _type;

        #endregion

        #region Ctor

        /// <summary>
        ///     Initializes a new instance of the <see cref="TypeMemberSelectionRule" /> class.
        /// </summary>
        /// <param name="type">The type to compare with the type of given members.</param>
        /// <param name="selectionMode">The selection mode to apply.</param>
        /// <param name="compareMode">The compare mode to apply.</param>
        /// <param name="name">The name of the rule.</param>
        /// <param name="description">The description of the rule.</param>
        public TypeMemberSelectionRule( Type type, MemberSelectionMode selectionMode, CompareMode compareMode, String name = null, String description = null )
            : base( name, description )
        {
            type.ThrowIfNull( nameof( type ) );

            _type = type;
            _selectionMode = selectionMode;
            _compareMode = compareMode;
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
            var matchesType = member.MemberType == _type;
            if ( _compareMode == CompareMode.IsNot )
                matchesType = !matchesType;
            if ( !matchesType )
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
        public override String ToString() => $"[{RuleName}] = ({_selectionMode} where type {_compareMode} {_type.Name}) ({RuleDescription}).";

        #endregion
    }
}