#region Usings

using System;
using System.Linq;
using JetBrains.Annotations;

#endregion

namespace Extend
{
    /// <summary>
    ///     Class containing some extension methods for <see cref="Type" />.
    /// </summary>
    public static partial class TypeEx
    {
        /// <summary>
        ///     Gets the first generic argument of the given type.
        /// </summary>
        /// <exception cref="ArgumentNullException">type can not be null.</exception>
        /// <param name="type">The type to get the generic argument from.</param>
        /// <returns>Returns the first generic argument of the given type, or null if the type does not have any generic arguments.</returns>
        [CanBeNull]
        [Pure]
        [PublicAPI]
        public static Type GetGenericTypeArgument( [NotNull] this Type type )
        {
            type.ThrowIfNull( nameof( type ) );

            return type.GetGenericTypeArguments()
                       .FirstOrDefault();
        }
    }
}