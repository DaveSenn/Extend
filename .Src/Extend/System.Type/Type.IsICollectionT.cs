#region Usings

using System;
using System.Collections.Generic;
using System.Linq;
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
        /// <param name="type">The type to check.</param>
        /// <returns>Returns a value of true if the given type implements <see cref="ICollection{T}" />; otherweise, false.</returns>
        public static Boolean IsICollectionT( this Type type )
        {
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