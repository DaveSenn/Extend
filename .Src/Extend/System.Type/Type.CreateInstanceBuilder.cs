#region Usings

using System;

#endregion

namespace Extend
{
    /// <summary>
    ///     Class containing some extension methods for <see cref="Type" />.
    /// </summary>
    public static partial class TypeEx
    {
        /// <summary>
        ///     Creates a new instance builder for the given type.
        /// </summary>
        /// <exception cref="ArgumentNullException">type can not be null.</exception>
        /// <param name="type">The type to create the instance builder for.</param>
        /// <returns>Returns the new created instance builder.</returns>
        public static IIntegralInstanceBuilder CreateInstanceBuilder( this Type type )
        {
            type.ThrowIfNull( nameof( type ) );

            return new InstanceBuilder( type );
        }
    }
}