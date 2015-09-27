#region Usings

using System;
using System.Reflection;

#endregion

namespace Extend
{
    /// <summary>
    ///     Interface representing instance value arguments.
    /// </summary>
    public interface IInstanceValueArguments
    {
        #region Properties

        /// <summary>
        ///     Gets the property infos of the property to set.
        /// </summary>
        /// <remarks>
        ///     Can be null.
        /// </remarks>
        /// <value>The property infos of the property to set.</value>
        PropertyInfo PropertyInfo { get; }

        /// <summary>
        ///     Gets the owner of the property.
        /// </summary>
        /// <value>The owner of the property.</value>
        Object PropertyOwner { get; }

        /// <summary>
        ///     Gets or sets the type of the property.
        /// </summary>
        /// <value>The type of the property.</value>
        Type PropertyType { get; }

        /// <summary>
        ///     Gets the name of the property type.
        /// </summary>
        /// <value>The name of the property type.</value>
        String PropertyName { get; }

        #endregion
    }
}