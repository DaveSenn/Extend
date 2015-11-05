#region Usings

using System.Collections.Generic;

#endregion

namespace Extend
{
    /// <summary>
    ///     Interface representing a rule inspector.
    /// </summary>
    public interface IMemberSelectionRuleInspector
    {
        /// <summary>
        ///     Inspects the given rules for the given member.
        /// </summary>
        /// <param name="rules">A collection of rules.</param>
        /// <param name="memberInformation">The member information to check.</param>
        /// <returns>Returns the inspection result.</returns>
        MemberSelectionResult Inspect( IEnumerable<IMemberSelectionRule> rules, IMemberInformation memberInformation );
    }
}