#region Usings

using System;

#endregion

namespace Extend
{
    /// <summary>
    ///     Class representing the result of a safe method execution.
    /// </summary>
    public class ExecutionResult<T> : IExecutionResult<T>
    {
        /// <summary>
        ///     Gets or sets the exception.
        /// </summary>
        /// <value>The exception.</value>
        public Exception Exception { get; set; }

        /// <summary>
        ///     Gets or sets the result.
        /// </summary>
        /// <value>The result.</value>
        public T Result { get; set; }
    }
}