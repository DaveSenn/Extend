#region Usings

using System;

#endregion

namespace PortableExtensions
{
    /// <summary>
    ///     Class containing some extension methods for <see cref="object" />.
    /// </summary>
    public static partial class ObjectEx
    {
        /// <summary>
        ///     Executes the action specified, which the given object as parameter.
        /// </summary>
        /// <remarks>
        ///     >
        ///     Use this method to chain method calls on the same object.
        /// </remarks>
        /// <exception cref="ArgumentNullException">The object can not be null.</exception>
        /// <exception cref="ArgumentNullException">The action can not be null.</exception>
        /// <typeparam name="T">The type of the object.</typeparam>
        /// <param name="obj">The object to act on.</param>
        /// <param name="action">The action.</param>
        /// <returns>Returns the given object.</returns>
        public static T Chain<T>( this T obj, Action<T> action )
        {
            obj.ThrowIfNull( () => obj );
            action.ThrowIfNull( () => action );

            action( obj );
            return obj;
        }
    }
}