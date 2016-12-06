#region Usings

using System;
using JetBrains.Annotations;

#if PORTABLE45
using System.Reflection;

#endif

#endregion

namespace Extend
{
    /// <summary>
    ///     Class containing some extension methods for <see cref="Type" />.
    /// </summary>
    public static partial class TypeEx
    {
        /// <summary>
        ///     Gets a value indicating whether the current type is a generic type.
        /// </summary>
        /// <param name="type">The type to check.</param>
        /// <returns>Returns a value of true if the given type is a generic type; otherwise, false.</returns>
        [Pure]
        [PublicAPI]
        public static Boolean IsGenericType( [NotNull] this Type type )
        {
            type.ThrowIfNull( nameof( type ) );

#if PORTABLE45
            return type
                .GetTypeInfo()
                .IsGenericType;
#elif NET40
            return type.IsGenericType;
#endif
        }
    }
}