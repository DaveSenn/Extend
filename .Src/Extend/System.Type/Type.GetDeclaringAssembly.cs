#region Usings

using System;
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
        ///     Gets the <see cref="Assembly" /> in which the type is declared. For generic types, gets the
        ///     <see cref="Assembly" /> in which the generic type is defined.
        /// </summary>
        /// <exception cref="ArgumentNullException">type can not be null.</exception>
        /// <param name="type">The type to get the declaring of.</param>
        /// <returns>Returns the assembly in which the type is declared.</returns>
        [NotNull]
        [Pure]
        [PublicAPI]
        public static Assembly GetDeclaringAssembly( [NotNull] this Type type )
        {
            type.ThrowIfNull( nameof( type ) );

#if PORTABLE45
            return type.GetTypeInfo()
                       .Assembly;
#elif NET40
            return type.Assembly;
#endif
        }
    }
}