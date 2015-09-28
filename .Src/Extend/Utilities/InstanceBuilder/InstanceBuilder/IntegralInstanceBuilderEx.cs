#region Usings

using System;

#endregion

namespace Extend.Utilities.InstanceBuilder.InstanceBuilder
{
    /// <summary>
    ///     Class containing some extension methods for <see cref="IIntegralInstanceBuilder" />.
    /// </summary>
    public static class IntegralInstanceBuilderEx
    {
        /// <summary>
        ///     Builds an instance based on the given instance builder.
        /// </summary>
        /// <param name="instanceBuilder">The instance builder.</param>
        /// <returns>Returns the new created instance.</returns>
        public static Object Build( this IIntegralInstanceBuilder instanceBuilder )
        {
            return InstanceBuildExecutor.BuildInstance( instanceBuilder.InstanceType, instanceBuilder.Factories );
        }

        /// <summary>
        ///     Builds an instance based on the given instance builder.
        /// </summary>
        /// <typeparam name="T">The type of the instance to create.</typeparam>
        /// <param name="instanceBuilder">The instance builder.</param>
        /// <returns>Returns the new created instance.</returns>
        public static T Build<T>( this IIntegralInstanceBuilder instanceBuilder ) where T : class
        {
            return InstanceBuildExecutor.BuildInstance( instanceBuilder.InstanceType, instanceBuilder.Factories ) as T;
        }
    }
}