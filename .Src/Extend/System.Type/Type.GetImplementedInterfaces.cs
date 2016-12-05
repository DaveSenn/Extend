#region Usings

using System;
using System.Collections.Generic;
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
        ///     Gets a collection of the interfaces implemented by the given type.
        /// </summary>
        /// <exception cref="ArgumentNullException">type can not be null.</exception>
        /// <param name="type">The type to get the interface of.</param>
        /// <returns>Returns the interfaces implemented by the given type.</returns>
        [NotNull]
        [Pure]
        [PublicAPI]
        public static IEnumerable<Type> GetImplementedInterfaces( [NotNull] this Type type )
        {
            type.ThrowIfNull( nameof( type ) );

#if PORTABLE45
            return type
                .GetTypeInfo()
                .ImplementedInterfaces;
#elif NET40
            return type.GetInterfaces();
#endif
        }
    }
}