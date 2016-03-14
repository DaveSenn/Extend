#region Usings

using System.Collections.Generic;

#endregion

namespace Extend
{
    /// <summary>
    ///     Class containing some extension methods for <see cref="IEnumerable{T}" />.
    /// </summary>
    // ReSharper disable once InconsistentNaming
    public static partial class IEnumerableTEx
    {
        /// <summary>
        ///     Ensures that the given <see cref="IEnumerable{T}" /> is not null.
        /// </summary>
        /// <typeparam name="T">The type of the items in the IEnumerable.</typeparam>
        /// <param name="enumerable">The IEnumerable.</param>
        /// <returns>Returns the given IEnumerable if it's not null, otherwise an empty array of type T.</returns>
        public static IEnumerable<T> EnsureNotNull<T>( this IEnumerable<T> enumerable ) => enumerable ?? new T[0];
    }
}