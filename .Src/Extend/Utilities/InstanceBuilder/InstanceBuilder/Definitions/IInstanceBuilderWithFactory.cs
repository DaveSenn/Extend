namespace Extend
{
    /// <summary>
    ///     Interface representing an instance builder with one or more factories.
    /// </summary>
    public interface IInstanceBuilderWithFactory
    {
        /// <summary>
        ///     Adds the given condition to the factory.
        /// </summary>
        /// <param name="condition">The condition to add.</param>
        /// <returns>Returns an instance builder.</returns>
        IInstanceBuilderWithCondition WithCondition( IInstanceBuilderCondition condition );
    }
}