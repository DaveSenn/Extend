using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extend
{
    /// <summary>
    ///     Instance builder.
    /// </summary>
    public class InstanceBuilder : IInstanceBuilder
    {
        #region Ctor

        /// <summary>
        ///     Initializes a  new instance of the <see cref="InstanceBuilder" /> class.
        /// </summary>
        /// <param name="type">The type of the instance to create.</param>
        public InstanceBuilder(Type type)
        {
            InstanceType = type;
        }

        #endregion

        #region Implementation of IInstanceBuilder

        /// <summary>
        ///     Gets the instance value factories.
        /// </summary>
        /// <value>The instance value factories.</value>
        public List<IInstanceValueFactory> Factories { get; } = new List<IInstanceValueFactory>();

        /// <summary>
        ///     Gets the type to create.
        /// </summary>
        /// <value>The type to create.</value>
        public Type InstanceType { get; }

        /*
        /// <summary>
        ///     Builds the instance.
        /// </summary>
        /// <returns>Returns the created instance.</returns>
        public Object Build()
        {
            return InstanceBuildExecutor.BuildInstance(InstanceType, Factories);
        }
        */

        /// <summary>
        ///     Adds the given factor to the list of factories used to create the înstance values.
        /// </summary>
        /// <exception cref="ArgumentNullException">factory can not be null.</exception>
        /// <param name="factory">The factory to add.</param>
        /// <returns>Returns an instance builder.</returns>
        public IInstanceBuilderWithFactory WithFactory(Func<IInstanceValueArguments, Object> factory)
        {
            factory.ThrowIfNull(nameof(factory));

            return new InstanceBuilderWithFactory(this, factory);
        }

        #endregion
    }
}
