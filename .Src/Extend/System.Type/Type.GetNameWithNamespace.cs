#region Usings

using System;
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
        ///     Gets the name including namespace and assembly of the given type.
        /// </summary>
        /// <exception cref="ArgumentNullException">type can not be null.</exception>
        /// <param name="type">The type to get the name of.</param>
        /// <returns>Returns the name of the given type.</returns>
        [NotNull]
        [Pure]
        [PublicAPI]
        public static String GetNameWithNamespace( [NotNull] this Type type )
        {
            type.ThrowIfNull( nameof(type) );

            if ( !type.IsGenericType() )
                return type.GetNameWithNamespaceSimpleType();

            // Get the type of the generic class.
            var genericType = type.GetGenericTypeDefinition();

            // Get the name of the generic class, add generic types and assembly name
            var genercArguments = type.GetGenericTypeArguments();
            var genericArgumentNames = genercArguments.Select( x => $"[{x.GetNameWithNamespace()}]" )
                                                      .StringJoin( "," );
            var genericTypeFullName = $"{genericType.FullName}[{genericArgumentNames}]";

            return $"{genericTypeFullName}, {genericType.GetAssemblyName()}";
        }

        /// <summary>
        ///     Gets the name of the assembly of the given type.
        /// </summary>
        /// <exception cref="ArgumentNullException">type can not be null.</exception>
        /// <param name="type">The type to get the assembly name of.</param>
        /// <returns>Returns the assembly name without version and key.</returns>
        [NotNull]
        [Pure]
        private static String GetAssemblyName( [NotNull] this Type type )
        {
            type.ThrowIfNull( nameof(type) );

            return type
                   .GetDeclaringAssembly()
                   .FullName.Split( ',' )[0];
        }

        /// <summary>
        ///     Gets the name of a type without any generic arguments.
        /// </summary>
        /// <exception cref="ArgumentNullException">type can not be null.</exception>
        /// <param name="type">The type to get the name of.</param>
        /// <returns>Returns the name and namespace of a simple type.</returns>
        [NotNull]
        [Pure]
        private static String GetNameWithNamespaceSimpleType( [NotNull] this Type type )
            => $"{type.FullName}, {type.GetAssemblyName()}";
    }
}