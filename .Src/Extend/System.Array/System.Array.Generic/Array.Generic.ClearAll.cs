#region Usings

using System;
using JetBrains.Annotations;

#endregion

namespace Extend
{
    /// <summary>
    ///     Class containing some extension methods for <see cref="Array" />.
    /// </summary>
    public static partial class ArrayEx
    {
        /// <summary>
        ///     Clears the given array.
        /// </summary>
        /// <exception cref="ArgumentNullException">The array can not be null.</exception>
        /// <typeparam name="T">The type of the items in the array.</typeparam>
        /// <param name="array">The array to clear.</param>
        /// <returns>Returns the cleared array.</returns>
        [NotNull]
        [PublicAPI]
        public static T[] ClearAll<T>( [NotNull] this T[] array )
        {
            array.ThrowIfNull( nameof( array ) );

            Array.Clear( array, 0, array.Length );
            return array;
        }
    }
}