#region Usings

using System;
using System.Linq;
using System.Reflection;

#endregion

namespace Extend
{
    /// <summary>
    ///     Class containing some extension methods for <see cref="Type" />.
    /// </summary>
    public static partial class TypeEx
    {
        /// <summary>
        ///     Gets the first generic argument of the given type.
        /// </summary>
        /// <param name="type">The type to get the generic argument from.</param>
        /// <returns>Returns the first generic argument of the given type, or null if the type does not have any generic arguments.</returns>
        public static Type GetGenericTypeArgument( this Type type )
        {
#if PORTABLE45
            return type.GetTypeInfo()
                       .GenericTypeArguments.FirstOrDefault();
#elif NET40
            return type.GetGenericArguments().FirstOrDefault();
#endif
        }
    }
}