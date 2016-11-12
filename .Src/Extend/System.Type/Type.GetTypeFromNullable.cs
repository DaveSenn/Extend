#region Usings

using System;
using JetBrains.Annotations;

#if PORTABLE45

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
        ///     Gets the 'inner' type from a nullable type.
        /// </summary>
        /// <param name="possibleNullableType">The possible nullable type.</param>
        /// <returns>Returns the inner type, or null if the given type is not a nullable.</returns>
        [Pure]
        [PublicAPI]
        public static Type GetTypeFromNullable( [NotNull] this Type possibleNullableType )
        {
            if ( !possibleNullableType.IsGenericType() || possibleNullableType.GetGenericTypeDefinition() != typeof(Nullable<>) )
                return null;

            return possibleNullableType.GetGenericTypeArgument();
        }
    }
}