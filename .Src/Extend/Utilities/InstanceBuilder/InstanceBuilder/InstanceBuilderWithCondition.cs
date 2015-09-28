using System;
using System.Collections.Generic;

namespace Extend
{
    /// <summary>
    ///     Instance builder with one or more conditions (for a single factory).
    /// </summary>
    public class InstanceBuilderWithCondition : IInstanceBuilderWithCondition
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
        ///     Initializes a new instance of the <see cref="InstanceBuilderWithCondition" /> class.
        /// </summary>
        /// <param name="instanceBuilder">The instance builder.</param>
        /// <param name="factory">The factory to crete conditions for.</param>
        public InstanceBuilderWithCondition(IIntegralInstanceBuilder instanceBuilder, IInstanceValueFactory factory)
        {
            InstanceBuilder = instanceBuilder;
            Factory = factory;
        }

        #endregion

        #region Implementation of IInstanceBuilderWithCondition

        /// <summary>
        ///     Sets the condition combination to the given value.
        /// </summary>
        /// <param name="conditionCombinationOption">The condition combination option.</param>
        /// <returns>Returns an instance builder.</returns>
        public IInstanceBuilderWithCondition WithConditionCombination(ConditionCombinationOption conditionCombinationOption)
        {
            Factory.Conditions.CombinationOption = conditionCombinationOption;
            return this;
        }

        /// <summary>
        ///     Gets the instance value factories.
        /// </summary>
        /// <value>The instance value factories.</value>
        public List<IInstanceValueFactory> Factories => InstanceBuilder.Factories;

        /// <summary>
        ///     Gets the type to create.
        /// </summary>
        /// <value>The type to create.</value>
        public Type InstanceType => InstanceBuilder.InstanceType;

        /// <summary>
        ///     Adds the given factor to the list of factories used to create the înstance values.
        /// </summary>
        /// <exception cref="ArgumentNullException">factory can not be null.</exception>
        /// <param name="factory">The factory to add.</param>
        /// <returns>Returns an instance builder.</returns>
        public IInstanceBuilderWithFactory WithFactory(Func<IInstanceValueArguments, Object> factory)
        {
            factory.ThrowIfNull(nameof(factory));

            return new InstanceBuilderWithFactory(InstanceBuilder, factory);
        }

        /// <summary>
        ///     Adds the given condition to the factory.
        /// </summary>
        /// <exception cref="ArgumentNullException">condition can not be null.</exception>
        /// <param name="condition">The condition to add.</param>
        /// <returns>Returns an instance builder.</returns>
        public IInstanceBuilderWithCondition WithCondition(IInstanceBuilderCondition condition)
        {
            condition.ThrowIfNull(nameof(condition));

            Factory.Conditions.Add(condition);
            return this;
        }

        #endregion
    }
}