#region Usings

using System;
using System.Collections.Generic;

#endregion

namespace Extend
{
    /// <summary>
    ///     Interface representing an instance builder.
    /// </summary>
    public interface IInstanceBuilder : IIntegralInstanceBuilder
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
    }
}