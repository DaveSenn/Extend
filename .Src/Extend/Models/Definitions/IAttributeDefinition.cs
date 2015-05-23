#region Usings

using System;
using System.Collections.Generic;
using System.Reflection;

#endregion

namespace Extend
{
    /// <summary>
    ///     Interface representing a attribute definition.
    /// </summary>
    /// <typeparam name="TAttribute">The type of the attribute.</typeparam>
    public interface IAttributeDefinition<TAttribute> where TAttribute : Attribute
    {
        #region Properties

        /// <summary>
        ///     Gets or sets the property which is decorated with the attributes.
        /// </summary>
        /// <value>The property which is decorated with the attributes.</value>
        PropertyInfo Property { get; set; }

        /// <summary>
        ///     Gets or sets a collection of attributes of the specified type.
        /// </summary>
        /// <value>A collection of attributes of the specified type.</value>
        IEnumerable<TAttribute> Attributes { get; set; }

        #endregion Properties
    }
}