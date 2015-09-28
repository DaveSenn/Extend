#region Usings

using System;

#endregion

namespace Extend
{
    /// <summary>
    ///     Interface representing an integral interface builder, which can be build any time.
    /// </summary>
    public interface IIntegralInstanceBuilder
    {
        /// <summary>
        ///     Builds the instance.
        /// </summary>
        /// <returns>Returns the created instance.</returns>
        Object Build();

        /// <summary>
        ///     Adds the given factor to the list of factories used to create the înstance values.
        /// </summary>
        /// <param name="factory">The factory to add.</param>
        /// <returns>Returns an instance builder.</returns>
        IInstanceBuilderWithFactory WithFactory( Func<IInstanceValueArguments, Object> factory );
    }
}