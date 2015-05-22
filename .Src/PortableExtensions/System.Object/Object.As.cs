﻿#region Usings

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
        ///     Cast the given object to the specified type.
        /// </summary>
        /// <exception cref="ArgumentNullException">The object can not be null.</exception>
        /// <typeparam name="T">The type.</typeparam>
        /// <param name="obj">The object to cast.</param>
        /// <returns>The object as the specified type.</returns>
        public static T As<T>( this object obj )
        {
            obj.ThrowIfNull( () => obj );

            return (T) obj;
        }
    }
}