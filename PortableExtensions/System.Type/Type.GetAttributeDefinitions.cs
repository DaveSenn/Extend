#region Usings

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

#endregion

namespace PortableExtensions
{
    /// <summary>
    ///     Class containing some extension methods for <see cref="Type" />.
    /// </summary>
    public static class TypeEx
    {
        /// <summary>
        ///     Gets the attributes of the proprieties of the given type.
        /// </summary>
        /// <typeparam name="TAttribute">The type of attributes to return.</typeparam>
        /// <param name="t">The type to get the attribute definitions from.</param>
        /// <returns>Returns the attribute definitions of the given type.</returns>
        public static IEnumerable<AttributeDefinition<TAttribute>> GetAttributeDefinitions<TAttribute> ( this Type t )
            where TAttribute : Attribute
        {
            return t.GetRuntimeProperties()
                    .Select( x => new AttributeDefinition<TAttribute>
                    {
                        Property = x,
                        Attributes = x.GetCustomAttributes( typeof (TAttribute), true ).Cast<TAttribute>()
                    } )
                    .Where( x => x.Attributes.Any() );
        }
    }
}