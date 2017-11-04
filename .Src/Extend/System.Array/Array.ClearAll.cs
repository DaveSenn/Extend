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
        /// <param name="array">The array to clear.</param>
        [PublicAPI]
        public static void ClearAll( [NotNull] this Array array )
        {
            array.ThrowIfNull( nameof(array) );

            Array.Clear( array, 0, array.Length );
        }
    }
}