using System;

namespace Extend
{
    /// <summary>
    ///     Instance builder with one or more factories.
    /// </summary>
    public class InstanceBuilderWithFactory : IInstanceBuilderWithFactory
    {
        #region Properties

        /// <summary>
        ///     Gets the internal instance builder.
        /// </summary>
        /// <value>The internal instance builder.</value>
        private IIntegralInstanceBuilder InstanceBuilder { get; }

        /// <summary>
        ///     Gets the current factory.
        /// </summary>
        /// <value>The current factory.</value>
        private IInstanceValueFactory Factory { get; }

        #endregion

        #region Ctor

        /// <summary>
        ///     Initializes a new instance of the <see cref="InstanceBuilderWithFactory" /> class.
        /// </summary>
        /// <param name="instanceBuilder">The instance builder.</param>
        /// <param name="factory">The factory to add to the instance builder.</param>
        public InstanceBuilderWithFactory(IIntegralInstanceBuilder instanceBuilder, Func<IInstanceValueArguments, Object> factory)
        {
            InstanceBuilder = instanceBuilder;
            Factory = new InstanceValueFactory(factory);
            InstanceBuilder.Factories.Add(Factory);
        }

        #endregion

        #region Implementation of IInstanceBuilderWithFactory

        /// <summary>
        ///     Adds the given condition to the factory.
        /// </summary>
        /// <param name="condition">The condition to add.</param>
        /// <returns>Returns an instance builder.</returns>
        public IInstanceBuilderWithCondition WithCondition(IInstanceBuilderCondition condition)
        {
            Factory.Conditions.Add(condition);
            return new InstanceBuilderWithCondition(InstanceBuilder, Factory);
        }

        #endregion
    }
}