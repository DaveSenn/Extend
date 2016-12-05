#region Usings

using System;
using System.Collections.Generic;
using System.Reflection;
using JetBrains.Annotations;

#if PORTABLE45
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
        ///     Gets the types defined in the given assembly.
        /// </summary>
        /// <exception cref="ArgumentNullException">assembly can not be null.</exception>
        /// <param name="assembly">The assembly to get the types of.</param>
        /// <returns>Returns the types defined in the given assembly.</returns>
        [Pure]
        [PublicAPI]
        public static IEnumerable<Type> GetDefinedTypes( [NotNull] this Assembly assembly )
        {
            assembly.ThrowIfNull( nameof( assembly ) );

#if PORTABLE45
            return assembly
                .DefinedTypes
                .Select( x => x.AsType() )
                .ToArray();
#elif NET40
            return assembly.GetTypes();
#endif
        }
    }
}