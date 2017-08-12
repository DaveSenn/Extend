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
    ///     Class containing some extension methods for <see cref="Assembly" />.
    /// </summary>
    public static partial class AssemblyEx
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
            assembly.ThrowIfNull( nameof(assembly) );

            return assembly
                .DefinedTypes
                .Select( x => x.AsType() )
                .ToArray();
        }
    }
}