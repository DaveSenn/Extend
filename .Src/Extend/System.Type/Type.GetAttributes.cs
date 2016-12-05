#region Usings

using System;
using System.Collections.Generic;
using System.Reflection;
using JetBrains.Annotations;
#if NET40
using System.Linq;

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
        ///     Gets a collection of custom attributes of a specified type that are applied to the given assembly.
        /// </summary>
        /// ///
        /// <exception cref="ArgumentNullException">assembly can not be null.</exception>
        /// <typeparam name="T">The type of attribute to search for.</typeparam>
        /// <param name="assembly">The assembly to inspect.</param>
        /// <returns>
        ///     Returns a collection of the custom attributes that are applied to element and that match T, or an empty
        ///     collection if no such attributes exist.
        /// </returns>
        [PublicAPI]
        [Pure]
        [NotNull]
        public static IEnumerable<T> GetAttributes<T>( [NotNull] this Assembly assembly ) where T : Attribute
        {
            assembly.ThrowIfNull( nameof( assembly ) );

#if PORTABLE45
            return assembly.GetCustomAttributes<T>();
#elif NET40
            return assembly
                .GetCustomAttributes( typeof(T), false )
                .OfType<T>();
#endif
        }
    }
}