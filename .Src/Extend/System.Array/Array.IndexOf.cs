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
        ///     Searches for the specified object and returns the index of its first occurrence in a one-dimensional array.
        /// </summary>
        /// <exception cref="ArgumentNullException">Array can not be null.</exception>
        /// <param name="array">The one-dimensional  to search.</param>
        /// <param name="value">The object to locate in <paramref name="array" />.</param>
        /// <returns>
        ///     The index of the first occurrence of value in array, if found; otherwise, the lower bound of the array minus 1.
        /// </returns>
        public static Int32 IndexOf( this Array array, Object value )
        {
            array.ThrowIfNull( nameof( array ) );

            return Array.IndexOf( array, value );
        }

        /// <summary>
        ///     Searches for the specified object in a range of elements of a one-dimensional array, and returns the index of its
        ///     first occurrence. The range extends from a specified index to the end of the array.
        /// </summary>
        /// <exception cref="ArgumentNullException">Array can not be null.</exception>
        /// <param name="array">The one-dimensional  to search.</param>
        /// <param name="value">The object to locate in <paramref name="array" />.</param>
        /// <param name="startIndex">The starting index of the search. 0 (zero) is valid in an empty array.</param>
        /// <returns>
        ///     The index of the first occurrence of value, if it’s found, within the range of elements in array that extends from
        ///     startIndex to the last element; otherwise, the lower bound of the array minus 1.
        /// </returns>
        public static Int32 IndexOf( this Array array, Object value, Int32 startIndex )
        {
            array.ThrowIfNull( nameof( array ) );

            return Array.IndexOf( array, value, startIndex );
        }

        /// <summary>
        ///     Searches for the specified object in a range of elements of a one-dimensional array, and returns the index of ifs
        ///     first occurrence. The range extends from a specified index for a specified number of elements.
        /// </summary>
        /// <exception cref="ArgumentNullException">Array can not be null.</exception>
        /// <param name="array">The one-dimensional  to search.</param>
        /// <param name="value">The object to locate in <paramref name="array" />.</param>
        /// <param name="startIndex">The starting index of the search. 0 (zero) is valid in an empty array.</param>
        /// <param name="count">The number of elements to search.</param>
        /// <returns>
        ///     The index of the first occurrence of value, if it’s found, in the array from index startIndex to startIndex + count
        ///     - 1; otherwise, the lower bound of the array minus 1.
        /// </returns>
        public static Int32 IndexOf( this Array array, Object value, Int32 startIndex, Int32 count )
        {
            array.ThrowIfNull( nameof( array ) );

            return Array.IndexOf( array, value, startIndex, count );
        }
    }
}