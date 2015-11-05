namespace Extend
{
    /// <summary>
    ///     Enumeration of all possible member selection results.
    /// </summary>
    public enum MemberSelectionResult
    {
        /// <summary>
        ///     Include the member.
        /// </summary>
        IncludeMember = 0,

        /// <summary>
        ///     Exclude the member.
        /// </summary>
        ExcludeMember = 1,

        /// <summary>
        ///     Rule does not apply to member.
        /// </summary>
        Neutral = 2
    }
}