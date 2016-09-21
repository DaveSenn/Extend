#region Usings

using System;
using System.Collections.Generic;

#endregion

namespace Extend
{
    /// <summary>
    ///     Class representing a type and it's attributes of a specific type.
    /// </summary>
    /// <typeparam name="T">The type of the attributes.</typeparam>
    public class AttributeDefinitionType<T> : IAttributeDefinitionType<T> where T : Attribute
    {
        #region Implementation of IAttributeDefinitionType<T>

        /// <summary>
        ///     Gets or sets the attributes.
        /// </summary>
        /// <value>The attributes.</value>
        public IEnumerable<T> Attributes { get; set; }

        /// <summary>
        ///     Gets or sets the type.
        /// </summary>
        /// <value>The type.</value>
        public Type Type { get; set; }

        #endregion
    }
}