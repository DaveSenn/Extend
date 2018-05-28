#region Usings

// ReSharper disable once RedundantUsingDirective
using System;
using System.Collections.Generic;
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
        ///     Gets the attributes of the proprieties of the given type.
        /// </summary>
        /// <exception cref="ArgumentNullException">type can not be null.</exception>
        /// <typeparam name="TAttribute">The type of attributes to return.</typeparam>
        /// <param name="type">The type to get the attribute definitions from.</param>
        /// <returns>Returns the attribute definitions of the given type.</returns>
        [NotNull]
        [Pure]
        [PublicAPI]
        public static IEnumerable<AttributeDefinitionProperty<TAttribute>> GetAttributeDefinitions<TAttribute>( [NotNull] this Type type )
            where TAttribute : Attribute
        {
            type.ThrowIfNull( nameof(type) );

            return type
                   .GetPublicProperties()
                   .Select( x => new AttributeDefinitionProperty<TAttribute>
                   {
                       Property = x,
                       Attributes = x.GetCustomAttributes( typeof(TAttribute), true )
                                     .Cast<TAttribute>()
                   } )
                   .Where( x => x.Attributes.Any() );
        }
    }
}