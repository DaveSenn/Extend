#region Usings

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

#endregion

namespace Extend
{
    /// <summary>
    ///     Class containing some extension methods for <see cref="Type" />.
    /// </summary>
    public static partial class TypeEx
    {
        /// <summary>
        ///     Gets the property info of each public settable property of the given type.
        /// </summary>
        /// <param name="memberType">The type to get the properties of.</param>
        /// <returns>Returns the property infos.</returns>
        public static IEnumerable<PropertyInfo> GetPublicSettableProperties( this Type memberType )
        {
#if PORTABLE45
            var propertyInfos = memberType.GetRuntimeProperties()
                                          .Where( x => x.SetMethod?.IsPublic ?? false );
#elif NET40
            var propertyInfos = memberType.GetProperties( BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly );
#endif

            return propertyInfos.Where( x => x.CanWrite );
        }
    }
}