#region Usings

using System;

#endregion

namespace PortableExtensions
{
    /// <summary>
    ///     Class containing some extension methods for <see cref="object" />.
    /// </summary>
    public static partial class ObjectEx
    {
        /// <summary>
        ///     Determines whether the specified objects instances are the same instance.
        /// </summary>
        /// <exception cref="ArgumentNullException">The first object can not be null.</exception>
        /// <exception cref="ArgumentNullException">The second object can not be null.</exception>
        /// <param name="obj0">The first object to compare.</param>
        /// <param name="obj1">The second object  to compare.</param>
        /// <returns>Returns true if if the objects are the same instance.</returns>
        public static Boolean RefEquals ( this Object obj0, Object obj1 )
        {
            obj0.ThrowIfNull( () => obj0 );
            obj1.ThrowIfNull( () => obj1 );

            return ReferenceEquals( obj0, obj1 );
        }
    }
}