#region Usings

using System;

#endregion

namespace Extend
{
    /// <summary>
    ///     Interface representing a name based condition.
    /// </summary>
    public interface INameInstanceBuilderCondition : IInstanceBuilderCondition
    {
        #region Properties

        /// <summary>
        ///     Gets the value to search for.
        /// </summary>
        /// <value>The value to search for.</value>
        String Value { get; }

        /// <summary>
        ///     Gets the compare option.
        /// </summary>
        /// <value>The compare option.</value>
        StringCompareOption CompareOption { get; }

        /// <summary>
        ///     Gets a value indicating whether casing should be ignored or not.
        /// </summary>
        /// <value>A value indicating whether casing should be ignored or not.</value>
        Boolean IgnoreCase { get; }

        #endregion
    }
}