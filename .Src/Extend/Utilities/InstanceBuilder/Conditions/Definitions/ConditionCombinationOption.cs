namespace Extend
{
    /// <summary>
    ///     Enumeration of all condition combinations.
    /// </summary>
    public enum ConditionCombinationOption
    {
        /// <summary>
        ///     Match all conditions.
        /// </summary>
        MatchAll = 0,

        /// <summary>
        ///     Match any condition.
        /// </summary>
        MatchAny = 1,

        /// <summary>
        ///     Don't match any condition.
        /// </summary>
        NotMatchAny = 3
    }
}