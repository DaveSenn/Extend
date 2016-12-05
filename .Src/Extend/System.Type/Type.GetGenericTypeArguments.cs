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
        ///     Returns an array of <see cref="Type" /> objects that represent the type arguments of a generic type or the type
        ///     parameters of a generic type definition.
        /// </summary>
        /// <exception cref="ArgumentNullException">type can not be null.</exception>
        /// <param name="type">Thy type to get the generic arguments of.</param>
        /// <returns>
        ///     Returns an array of <see cref="Type" /> objects that represent the type arguments of a generic type. Returns
        ///     an empty array if the current type is not a generic type.
        /// </returns>
        [Pure]
        [PublicAPI]
        public static Type[] GetGenericTypeArguments( [NotNull] this Type type )
        {
            type.ThrowIfNull( nameof( type ) );

#if PORTABLE45
            return type.GetTypeInfo()
                       .GenericTypeArguments;
#elif NET40
            return type.GetGenericArguments();
#endif
        }
    }
}