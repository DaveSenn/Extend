#region Usings

using System;
using System.Reflection;

#endregion

namespace Extend
{
    /// <summary>
    ///     Class representing instance value arguments.
    /// </summary>
    public class InstanceValueArguments : IInstanceValueArguments
    {
        #region Ctor

        /// <summary>
        ///     Create a new instnace of the <see cref="InstanceValueArguments" /> class.
        /// </summary>
        /// <param name="propertyType">The type of the property.</param>
        /// <param name="propertyName">The name of the property.</param>
        /// <param name="propertyInfo">The property infos of the property to set.</param>
        /// <param name="propertyOwner">The owner of the property.</param>
        public InstanceValueArguments( Type propertyType, String propertyName, PropertyInfo propertyInfo, Object propertyOwner )
        {
            PropertyType = propertyType;
            PropertyName = propertyName;
            PropertyInfo = propertyInfo;
            PropertyOwner = propertyOwner;
        }

        #endregion

        #region Implementation of IInstanceValueArguments

        /// <summary>
        ///     Gets the property infos of the property to set.
        /// </summary>
        /// <remarks>
        ///     Can be null.
        /// </remarks>
        /// <value>The property infos of the property to set.</value>
        public PropertyInfo PropertyInfo { get; }

        /// <summary>
        ///     Gets the owner of the property.
        /// </summary>
        /// <value>The owner of the property.</value>
        public Object PropertyOwner { get; }

        /// <summary>
        ///     Gets or sets the type of the property.
        /// </summary>
        /// <value>The type of the property.</value>
        public Type PropertyType { get; }

        /// <summary>
        ///     Gets the name of the property type.
        /// </summary>
        /// <value>The name of the property type.</value>
        public String PropertyName { get; }

        #endregion
    }
}