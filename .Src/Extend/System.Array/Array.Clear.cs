#region Usings

using System;

#endregion

namespace Extend
{
    /// <summary>
    ///     Class containing some extension methods for <see cref="Array" />.
    /// </summary>
    public static partial class ArrayEx
    {
        /// <summary>
        ///     Sets a range of elements in the array to zero, to false, or to null, depending on the element type.
        /// </summary>
        /// <exception cref="ArgumentNullException">The array can not be null.</exception>
        /// <param name="array">The array whose elements need to be cleared.</param>
        /// <param name="index">The starting index of the range of elements to clear.</param>
        /// <param name="length">The number of elements to clear.</param>
        public static void Clear( this Array array, Int32 index, Int32 length )
        {
            array.ThrowIfNull( nameof( array ) );

            Array.Clear( array, index, length );
        }
    }
}