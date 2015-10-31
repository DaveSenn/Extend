#region Usings

using System.Reflection;

#endregion

namespace Extend
{
    /// <summary>
    ///     Class containing some extension methods for <see cref="PropertyInfo" />.
    /// </summary>
    public static class PropertyInfoEx
    {
        /// <summary>
        ///     Creates a <see cref="IMemberInformation" /> based on the given <see cref="PropertyInfo" /> and parent information.
        /// </summary>
        /// <param name="propertyInfo">The property information.</param>
        /// <param name="parentMemberInformation">The parent of the given property.</param>
        /// <returns>Returns the new created member information.</returns>
        public static IMemberInformation ToMemberInformation( this PropertyInfo propertyInfo, IMemberInformation parentMemberInformation )
        {
            return new MemberInformation
            {
                MemberType = propertyInfo.PropertyType,
                MemberPath = parentMemberInformation.MemberPath.IsNotEmpty()
                    ? $"{parentMemberInformation.MemberPath}.{propertyInfo.Name}"
                    : propertyInfo.Name,
                MemberName = propertyInfo.Name,
                PropertyInfo = propertyInfo
            };
        }
    }
}