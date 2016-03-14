#region Usings

using System;
using System.Linq;
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
        ///     Gets the name of the assembly of the given type.
        /// </summary>
        /// <param name="type">The type to get the assembly name of.</param>
        /// <returns>Returns the assembly name without version and key.</returns>
        private static String GetAssemblyName( this Type type )
        {
#if PORTABLE45
            var assembly = type.GetTypeInfo()
                               .Assembly;
#elif NET40
            var assembly = type.Assembly;
#endif

            return assembly.FullName.Split( ',' )[0];
        }

        /// <summary>
        ///     Gets the name including namespace and assembly of the given type.
        /// </summary>
        /// <exception cref="ArgumentNullException">type can not be null.</exception>
        /// <param name="type">The type to get the name of.</param>
        /// <returns>Returns the name of the given type.</returns>
        public static String GetNameWithNamespace( this Type type )
        {
            type.ThrowIfNull( nameof( type ) );

#if PORTABLE45
            var isGeneric = type.GetTypeInfo()
                                .IsGenericType;
#elif NET40
            var isGeneric = type.IsGenericType;
#endif
            if ( !isGeneric )
                return type.GetNameWithNamespaceSimpleType();

            //Get the type of the generic class.
            var genericType = type.GetGenericTypeDefinition();

            //Get the name of the generic class, add generic types and assembly name

#if PORTABLE45
            var genercArguments = type.GenericTypeArguments;
#elif NET40
            var genercArguments = type.GetGenericArguments();
#endif
            var genericArgumentNames = genercArguments.Select( x => $"[{x.GetNameWithNamespace()}]" )
                                                      .StringJoin( "," );
            var genericTypeFullName = $"{genericType.FullName}[{genericArgumentNames}]";

            return $"{genericTypeFullName}, {genericType.GetAssemblyName()}";
        }

        /// <summary>
        ///     Gets the name of a type without any generic arguments.
        /// </summary>
        /// <param name="type">The type to get the name of.</param>
        /// <returns></returns>
        private static String GetNameWithNamespaceSimpleType( this Type type ) => $"{type.FullName}, {type.GetAssemblyName()}";
    }
}