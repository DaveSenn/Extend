#region Usings

using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
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
        ///     Gets the attributes of the proprieties of the given type.
        /// </summary>
        /// <exception cref="ArgumentNullException">t can not be null.</exception>
        /// <typeparam name="TAttribute">The type of attributes to return.</typeparam>
        /// <param name="t">The type to get the attribute definitions from.</param>
        /// <returns>Returns the attribute definitions of the given type.</returns>
        [NotNull]
        [Pure]
        [PublicAPI]
        public static IEnumerable<AttributeDefinitionProperty<TAttribute>> GetAttributeDefinitions<TAttribute>( [NotNull] this Type t )
            where TAttribute : Attribute
        {
            t.ThrowIfNull( nameof( t ) );

#if PORTABLE45
            return t.GetRuntimeProperties()
                    .Select( x => new AttributeDefinitionProperty<TAttribute>
                             {
                                 Property = x,
                                 Attributes = x.GetCustomAttributes( typeof(TAttribute), true )
                                               .Cast<TAttribute>()
                             } )
                    .Where( x => x.Attributes.Any() );

#elif NET40
            return t.GetProperties()
                    .Select( x => new AttributeDefinitionProperty<TAttribute>
                    {
                        Property = x,
                        Attributes = x.GetCustomAttributes( typeof (TAttribute), true )
                                      .Cast<TAttribute>()
                    } )
                    .Where( x => x.Attributes.Any() );
#endif
        }
    }
}