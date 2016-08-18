#region Usings

using System;
using System.Collections.Generic;
using JetBrains.Annotations;

#endregion

namespace Extend
{
    /// <summary>
    ///     Class containing some extension methods for <see cref="ICollection{T}" />.
    /// </summary>
    // ReSharper disable once InconsistentNaming
    public static partial class IEnumerableTEx
    {
        /// <summary>
        ///     Checks if the enumerable is empty or null.
        /// </summary>
        /// <typeparam name="T">The type of the items in the enumerable.</typeparam>
        /// <param name="enumerable">The enumerable to check.</param>
        /// <returns>Returns true if the enumerable is empty or null, otherwise false.</returns>
        [Pure]
        [PublicAPI]
        public static Boolean IsNullOrEmpty<T>( this IEnumerable<T> enumerable )
            => enumerable.IsNull() || enumerable.NotAny();
    }
}