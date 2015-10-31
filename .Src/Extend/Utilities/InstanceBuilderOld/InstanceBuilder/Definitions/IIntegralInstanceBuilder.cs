#region Usings

using System;
using System.Collections.Generic;

#endregion

namespace Extend
{
    /// <summary>
    ///     Interface representing an integral interface builder, which can be build any time.
    /// </summary>
    public interface IIntegralInstanceBuilder
    {
        #region Properties

        /// <summary>
        ///     Gets the instance value factories.
        /// </summary>
        /// <value>The instance value factories.</value>
        List<IInstanceValueFactory> Factories { get; }

        /// <summary>
        ///     Gets the type to create.
        /// </summary>
        /// <value>The type to create.</value>
        Type InstanceType { get; }

        #endregion

        /// <summary>
        ///     Adds the given factor to the list of factories used to create the instance values.
        /// </summary>
        /// <param name="factory">The factory to add.</param>
        /// <returns>Returns an instance builder.</returns>
        IInstanceBuilderWithFactory WithFactory( Func<IInstanceValueArguments, Object> factory );
    }
}