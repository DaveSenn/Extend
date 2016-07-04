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
        ///     Cast the given object to the specified type.
        /// </summary>
        /// <typeparam name="T">The type.</typeparam>
        /// <param name="obj">The object to cast.</param>
        /// <returns>The object as the specified type.</returns>
        [CanBeNull]
        [Pure]
        [PublicAPI]
        public static T As<T>( [CanBeNull] this Object obj )
            => (T) obj;
    }
}