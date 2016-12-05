#region Usings

using System;
using System.Collections.Generic;
using System.Linq;
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

            var isGenericType = type.IsGenericType();
            var interfaces = type.GetImplementedInterfaces();

            return isGenericType && interfaces.Any( x => x.Name == "ICollection`1" );
        }
    }
}