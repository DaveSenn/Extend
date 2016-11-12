#region Usings

using System;
using System.Collections.Generic;
using System.Linq;
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
        ///     Checks if the given type implements <see cref="ICollection{T}" />
        /// </summary>
        /// <exception cref="ArgumentNullException">type can not be null.</exception>
        /// <param name="type">The type to check.</param>
        /// <returns>Returns a value of true if the given type implements <see cref="ICollection{T}" />; otherwise, false.</returns>
        [Pure]
        [PublicAPI]
        public static Boolean ImplementsICollectionT( [NotNull] this Type type )
        {
            type.ThrowIfNull( nameof( type ) );

#if PORTABLE45
            var typeInfo = type.GetTypeInfo();
            var interfaces = type.GetTypeInfo()
                                 .ImplementedInterfaces.ToList();
            var isGenericType = typeInfo.IsGenericType;
#elif NET40
            var interfaces = type.GetInterfaces()
                                 .ToList();
            var isGenericType = type.IsGenericType;
#endif
            return isGenericType && interfaces.Any( x => x.Name == "ICollection`1" );
        }
    }
}