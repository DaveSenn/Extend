﻿#region Usings

using System;

#endregion

namespace Extend
{
    /// <summary>
    ///     Class containing some extension methods for <see cref="object" />.
    /// </summary>
    public static partial class ObjectEx
    {
        /// <summary>
        ///     Checks if the given value is the default value of it's type.
        /// </summary>
        /// <typeparam name="T">The type of the value.</typeparam>
        /// <param name="value">The value to check.</param>
        /// <returns>Returns true if the value is the default value of it's type.</returns>
        public static Boolean IsDefault<T>( this T value )
        {
            return Equals( value, default(T) );
        }
    }
}