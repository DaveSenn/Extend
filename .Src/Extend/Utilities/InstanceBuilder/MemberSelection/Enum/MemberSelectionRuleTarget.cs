namespace Extend
{
    /// <summary>
    ///     Enumeration of all member selection rule targets.
    /// </summary>
    /// <remarks>
    ///     Used to build create instance options.
    /// </remarks>
    internal enum MemberSelectionRuleTarget
    {
        /// <summary>
        ///     The rule targets the member itself.
        /// </summary>
        Member = 0,

        /// <summary>
        ///     The rule targets the children of the member.
        /// </summary>
        MemberChildren = 1,

        /// <summary>
        ///     The rule targets a factory.
        /// </summary>
        Factory = 2
    }
}