namespace Extend
{
    /// <summary>
    ///     Interface representing an instance builder with one or more condietions (for a single factory).
    /// </summary>
    public interface IInstanceBuilderWithCondition : IIntegralInstanceBuilder, IInstanceBuilderWithFactory
    {
        /// <summary>
        ///     Sets the condition combination to the given value.
        /// </summary>
        /// <param name="conditionCombinationOption">The condition combination option.</param>
        /// <returns>Returns an instance builder.</returns>
        IInstanceBuilderWithCondition WithConditionCombination( ConditionCombinationOption conditionCombinationOption );
    }
}