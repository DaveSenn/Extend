#region Usings

using System;
using JetBrains.Annotations;

#endregion

namespace Extend
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
        ///     Use this method to chain method calls on the same object.
        /// </remarks>
        /// <exception cref="ArgumentNullException">The action can not be null.</exception>
        /// <typeparam name="T">The type of the object.</typeparam>
        /// <param name="obj">The object to act on.</param>
        /// <param name="action">The action.</param>
        /// <returns>Returns the given object.</returns>
        [PublicAPI]
        [Pure]
        public static T Chain<T>( [CanBeNull] this T obj, [NotNull] Action<T> action )
        {
            action.ThrowIfNull( nameof(action) );

            action( obj );
            return obj;
        }
    }
}