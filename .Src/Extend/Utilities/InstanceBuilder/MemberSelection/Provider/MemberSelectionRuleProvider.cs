#region Usings

using System.Collections.Generic;

#endregion

namespace Extend
{
    /// <summary>
    ///     Member selection provider.
    /// </summary>
    internal static class MemberSelectionRuleProvider
    {
        /// <summary>
        ///     Gets the default member children selection rules.
        /// </summary>
        /// <returns>Returns the member children selection rules.</returns>
        internal static IEnumerable<IMemberSelectionRule> GetDefaultMemberChildreSelectionRules()
        {
            //Include all children
            yield return new AllMemberSelectionRule( MemberSelectionMode.Include, "Include all child members", "Includes all child members." );

            //Exclude Microsoft (FX) types
            yield return new ExpressionMemberSelectionRule( x => x.MemberType.IsMicrosoftType(),
                                                            MemberSelectionMode.Exclude,
                                                            "Microsoft Type Filter",
                                                            "Excludes all types from Microsoft (Framework types)." );
        }

        /// <summary>
        ///     Gets the default member selection rules.
        /// </summary>
        /// <returns>Returns the member selection rules.</returns>
        internal static IEnumerable<IMemberSelectionRule> GetDefaultMemberSelectionRules()
        {
            yield return new AllMemberSelectionRule( MemberSelectionMode.Include, "Include all members", "Includes all members." );
        }
    }
}