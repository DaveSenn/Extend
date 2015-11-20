#region Usings

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

#endregion

namespace Extend
{
    /// <summary>
    ///     Class containing some extension methods for <see cref="Assembly" />.
    /// </summary>
    public static class AssemblyEx
    {
        /// <summary>
        ///     Gets all types of the given assemblies which is decorated with an attribute of the specified type.
        /// </summary>
        /// <typeparam name="T">The type of the attribute.</typeparam>
        /// <param name="assemblies">The assemblies to search in.</param>
        /// <returns>Returns the found types and their attributes.</returns>
        public static IEnumerable<IAttributeDefinitionType<T>> GetTypesWithAttribute<T>( params Assembly[] assemblies ) where T : Attribute
        {
            return GetTypesWithAttribute<T>( false, null, assemblies );
        }

        /// <summary>
        ///     Gets all types of the given assemblies which is decorated with an attribute of the specified type.
        /// </summary>
        /// <typeparam name="T">The type of the attribute.</typeparam>
        /// <param name="inherit">
        ///     true to search this member's inheritance chain to find the attributes; otherwise, false. This
        ///     parameter is ignored for properties and events; see Remarks.
        /// </param>
        /// <param name="assemblies">The assemblies to search in.</param>
        /// <returns>Returns the found types and their attributes.</returns>
        public static IEnumerable<IAttributeDefinitionType<T>> GetTypesWithAttribute<T>( Boolean inherit, params Assembly[] assemblies ) where T : Attribute
        {
            return GetTypesWithAttribute<T>( inherit, null, assemblies );
        }

        /// <summary>
        ///     Gets all types of the given assemblies which is decorated with an attribute of the specified type and are sub
        ///     classes of the specified base type.
        /// </summary>
        /// <typeparam name="T">The type of the attribute.</typeparam>
        /// <param name="inherit">
        ///     true to search this member's inheritance chain to find the attributes; otherwise, false. This
        ///     parameter is ignored for properties and events; see Remarks.
        /// </param>
        /// <param name="baseType">The base type to search for, or null.</param>
        /// <param name="assemblies">The assemblies to search in.</param>
        /// <returns>Returns the found types and their attributes.</returns>
        public static IEnumerable<IAttributeDefinitionType<T>> GetTypesWithAttribute<T>( Boolean inherit, Type baseType, params Assembly[] assemblies ) where T : Attribute
        {
            assemblies.ThrowIfNull( nameof( assemblies ) );

            var attributeType = typeof (T);
            var result = new List<AttributeDefinitionType<T>>();

            assemblies.ForEach( x =>
            {
#if PORTABLE45
                x.DefinedTypes
#elif NET40
                x.GetTypes()
#endif
                 .Where( y => baseType == null || y.IsSubclassOf( baseType ) )
                 .ForEach( y =>
                 {
                     var attributes = y.GetCustomAttributes( attributeType, inherit )
                                       .ToArray();
                     if ( attributes.NotAny() )
                         return;

                     result.Add( new AttributeDefinitionType<T>
                     {
#if PORTABLE45
                         Type = y.AsType(),
#elif NET40
                         Type = y,
#endif
                         Attributes = attributes.Cast<T>()
                                                .ToList()
                     } );
                 } );
            } );

            return result;
        }
    }
}