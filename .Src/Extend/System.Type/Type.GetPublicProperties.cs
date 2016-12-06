#region Usings

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
        ///     Gets the public properties of the given type.
        /// </summary>
        /// <exception cref="ArgumentNullException">type can not be null.</exception>
        /// <param name="type">The type to get the properties of.</param>
        /// <returns>Returns the public properties of the given type.</returns>
        [NotNull]
        [Pure]
        [PublicAPI]
        public static IEnumerable<PropertyInfo> GetPublicProperties( [NotNull] this Type type )
        {
            type.ThrowIfNull( nameof( type ) );

#if PORTABLE45
            return type.GetRuntimeProperties()
                       .Where( x => x.GetMethod.IsPublic );
#elif NET40
            return type.GetProperties( BindingFlags.Public | BindingFlags.Instance );
#endif
        }
    }
}