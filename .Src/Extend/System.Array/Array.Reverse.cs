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
        ///     Reverses the sequence of the elements in the entire one-dimensional array.
        /// </summary>
        /// <exception cref="ArgumentNullException">array can not be null.</exception>
        /// <param name="array">The one-dimensional array to reverse.</param>
        [PublicAPI]
        public static void Reverse( [NotNull] this Array array )
        {
            array.ThrowIfNull( nameof(array) );

            Array.Reverse( array );
        }

        /// <summary>
        ///     Reverses the sequence of the elements in a range of elements in the one-dimensional array.
        /// </summary>
        /// <exception cref="ArgumentNullException">array can not be null.</exception>
        /// <param name="array">The one-dimensional array to reverse.</param>
        /// <param name="index">The starting index of the section to reverse.</param>
        /// <param name="length">The number of elements in the section to reverse.</param>
        [PublicAPI]
        public static void Reverse( [NotNull] this Array array, Int32 index, Int32 length )
        {
            array.ThrowIfNull( nameof(array) );

            Array.Reverse( array, index, length );
        }
    }
}