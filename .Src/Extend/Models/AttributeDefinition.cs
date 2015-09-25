#region Usings

using System;
using System.Collections.Generic;
using System.Reflection;

#endregion

namespace Extend
{
    /// <summary>
    ///     Class representing a attribute definition.
    /// </summary>
    /// <typeparam name="TAttribute">The type of the attribute.</typeparam>
    public class AttributeDefinition<TAttribute> : IAttributeDefinition<TAttribute> where TAttribute : Attribute
    {
        #region Implementation of IAttributeDefinition{T}

        /// <summary>
        ///     Gets or sets the property which is decorated with the attributes.
        /// </summary>
        /// <value>The property which is decorated with the attributes.</value>
        public PropertyInfo Property { get; set; }

        /// <summary>
        ///     Gets or sets a collection of attributes of the specified type.
        /// </summary>
        /// <value>A collection of attributes of the specified type.</value>
        public IEnumerable<TAttribute> Attributes { get; set; } = new List<TAttribute>();

        #endregion Implementation of IAttributeDefinition{T}
    }
}