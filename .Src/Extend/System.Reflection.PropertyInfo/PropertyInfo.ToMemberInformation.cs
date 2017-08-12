#region Usings

using System;
using System.Reflection;
using JetBrains.Annotations;

#endregion

namespace Extend
{
    /// <summary>
    ///     Class containing some extension methods for <see cref="PropertyInfo" />.
    /// </summary>
    public static partial class PropertyInfoEx
    {
        /// <summary>
        ///     Creates a <see cref="IMemberInformation" /> based on the given <see cref="PropertyInfo" /> and parent information.
        /// </summary>
        /// <exception cref="ArgumentNullException">propertyInfo can not be null.</exception>
        /// <param name="propertyInfo">The property information.</param>
        /// <param name="parentMemberInformation">The parent of the given property.</param>
        /// <returns>Returns the new created member information.</returns>
        [NotNull]
        [Pure]
        [PublicAPI]
        public static IMemberInformation ToMemberInformation( [NotNull] this PropertyInfo propertyInfo, [CanBeNull] IMemberInformation parentMemberInformation )
        {
            propertyInfo.ThrowIfNull( nameof(propertyInfo) );

            var path = parentMemberInformation?.MemberPath ?? parentMemberInformation?.MemberName;

            return new MemberInformation
            {
                MemberType = propertyInfo.PropertyType,
                MemberPath = path.IsNotEmpty() ? $"{path}.{propertyInfo.Name}" : propertyInfo.Name,
                MemberName = propertyInfo.Name,
                PropertyInfo = propertyInfo
            };
        }
    }
}