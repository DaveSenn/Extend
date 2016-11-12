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
        ///     Returns the property value of a specified object.
        /// </summary>
        /// <exception cref="ArgumentNullException">propertyInfo can not be null.</exception>
        /// <exception cref="TargetInvocationException">The object does not match the target type, or a property is an instance property but obj is null.</exception>
        /// <param name="propertyInfo">The property information.</param>
        /// <param name="source">The object whose property value will be returned.</param>
        /// <returns>The property value of the specified object.</returns>
        [NotNull]
        [Pure]
        [PublicAPI]
        public static Object GetValueWithoutIndex( [NotNull] this PropertyInfo propertyInfo, [NotNull] Object source )
        {
            propertyInfo.ThrowIfNull( nameof( propertyInfo ) );
            
#if PORTABLE45
            return propertyInfo.GetValue( source );
#elif NET40
            return propertyInfo.GetValue( source, null );
#endif
        }
    }
}