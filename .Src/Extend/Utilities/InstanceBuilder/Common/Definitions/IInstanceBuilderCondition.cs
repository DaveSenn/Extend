#region Usings

using System;

#endregion

namespace Extend
{
    /// <summary>
    ///     Interface representing a instance builder condition.
    /// </summary>
    public interface IInstanceBuilderCondition
    {
        /// <summary>
        ///     Determines whether the given arguments matches the condition or not.
        /// </summary>
        /// <param name="arguments">The arguments to check.</param>
        /// <returns>Returns a value of true if the arguments matches the condition; otherwise, false.</returns>
        Boolean Matches( IInstanceValueArguments arguments );
    }
}