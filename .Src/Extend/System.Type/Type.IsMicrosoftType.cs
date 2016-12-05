#region Usings

using System;
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
        ///     Checks if th given type is a Microsoft type, based on the company attribute of it's declaring assembly.
        /// </summary>
        /// <exception cref="ArgumentNullException">type can not be null.</exception>
        /// <param name="type">The type to check.</param>
        /// <returns>Returns a value of true if the given type is a Microsoft type; otherwise, false.</returns>
        [Pure]
        [PublicAPI]
        public static Boolean IsMicrosoftType( [NotNull] this Type type )
        {
            type.ThrowIfNull( nameof( type ) );

            var attributes = type.GetDeclaringAssembly()
                                 .GetAttributes<AssemblyCompanyAttribute>();
            return attributes.Any( x => x.Company == "Microsoft Corporation" );
        }
    }
}