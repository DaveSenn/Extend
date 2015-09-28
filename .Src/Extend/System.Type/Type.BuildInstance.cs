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
        ///     Builds an instance of the given type.
        /// </summary>
        /// <typeparam name="T">The type of the instance to create.</typeparam>
        /// <returns>Returns the new created type.</returns>
        public static T BuildInstance<T>() where T : class
        {
            return typeof (T).CreateInstanceBuilder()
                             .Build<T>();
        }

        /// <summary>
        ///     Builds an instance of the given type.
        /// </summary>
        /// <exception cref="ArgumentNullException">type can not be null.</exception>
        /// <param name="type">The type of the instance to create.</param>
        /// <returns>Returns the new created type.</returns>
        public static Object BuildInstance( this Type type )
        {
            type.ThrowIfNull( nameof( type ) );

            return type.CreateInstanceBuilder()
                       .Build();
        }
    }
}