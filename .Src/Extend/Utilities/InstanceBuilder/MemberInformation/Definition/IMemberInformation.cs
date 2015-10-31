#region Usings

using System;
using System.Reflection;

#endregion

namespace Extend
{
    /// <summary>
    ///     Interface exposing information about a member.
    /// </summary>
    public interface IMemberInformation
    {
        #region Properties

        /// <summary>
        ///     Gets the name of the member.
        /// </summary>
        /// <value>The name of the member.</value>
        String MemberName { get; }

        /// <summary>
        ///     Gets the member path of the member.
        /// </summary>
        /// <value>The member path of the member.</value>
        String MemberPath { get; }

        /// <summary>
        ///     Gets the type of the member.
        /// </summary>
        /// <value>The type of the member.</value>
        Type MemberType { get; }

        /// <summary>
        ///     Gets or sets a reference to the member.
        /// </summary>
        /// <remarks>
        ///     Not always set.
        /// </remarks>
        /// <value>A reference to the member.</value>
        Object MemberObject { get; }

        /// <summary>
        ///     Gets the property info representing the member.
        /// </summary>
        /// <remarks>
        ///     Not always set.
        /// </remarks>
        /// <value>The property info representing the member.</value>
        PropertyInfo PropertyInfo { get; }

        #endregion
    }
}