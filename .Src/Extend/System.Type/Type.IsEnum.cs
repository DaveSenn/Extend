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
        ///     Checks if the given type is an enumeration.
        /// </summary>
        /// <exception cref="ArgumentNullException">type can not be null.</exception>
        /// <param name="type">The type to check.</param>
        /// <returns>Returns a value of true if the given type is an enumeration; otherwise, false.</returns>
        [Pure]
        [PublicAPI]
        public static Boolean IsEnum( [NotNull] this Type type )
        {
            type.ThrowIfNull( nameof(type) );

            return type.GetTypeInfo()
                       .IsEnum;
        }
    }
}