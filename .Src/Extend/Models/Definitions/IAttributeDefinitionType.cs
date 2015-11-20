#region Usings

using System;
using System.Collections.Generic;

#endregion

namespace Extend
{
    /// <summary>
    ///     Interface representing the attribute definitions of a type.
    /// </summary>
    /// <typeparam name="T">The type of the attributes.</typeparam>
    public interface IAttributeDefinitionType<T> where T : Attribute
    {
        #region Properties

        /// <summary>
        ///     Gets or sets the type.
        /// </summary>
        /// <value>The type.</value>
        Type Type { get; set; }

        /// <summary>
        ///     Gets or sets the attributes.
        /// </summary>
        /// <value>The attributes.</value>
        IEnumerable<T> Attributes { get; set; }

        #endregion
    }
}