#region Usings

using System;
using JetBrains.Annotations;

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
        [Pure]
        [PublicAPI]
        public static Boolean IsDefault<T>( [CanBeNull] this T value )
            => Equals( value, default(T) );
    }
}