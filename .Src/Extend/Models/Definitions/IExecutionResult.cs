#region Usings

using System;

#endregion

namespace Extend
{
    /// <summary>
    ///     Interface representing the result of a safe method execution.
    /// </summary>
    public interface IExecutionResult<T>
    {
        /// <summary>
        ///     Gets or sets the exception.
        /// </summary>
        /// <value>The exception.</value>
        Exception Exception { get; set; }

        /// <summary>
        ///     Gets or sets the result.
        /// </summary>
        /// <value>The result.</value>
        T Result { get; set; }
    }
}