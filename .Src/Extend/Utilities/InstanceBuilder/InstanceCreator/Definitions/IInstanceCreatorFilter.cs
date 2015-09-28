#region Usings

using System;

#endregion

namespace Extend
{
    /// <summary>
    ///     Interface representing an instance creator filter.
    /// </summary>
    public interface IInstanceCreatorFilter : IInstanceBuilderCondition
    {
        #region Properties

        /// <summary>
        ///     Gets the name of the filter.
        /// </summary>
        /// <value>The name of the filter.</value>
        String Name { get; }

        /// <summary>
        ///     Gets the description of the filter.
        /// </summary>
        /// <value>The description of the filter.</value>
        String Description { get; }

        #endregion
    }
}