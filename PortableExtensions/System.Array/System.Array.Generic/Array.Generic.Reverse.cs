#region Using

using System;

#endregion

namespace PortableExtensions
{
    /// <summary>
    ///     Class containing some extension methods for <see cref="Array" />.
    /// </summary>
    public static partial class ArrayEx
    {
        /// <summary>
        ///     Reverses the sequence of the elements in the entire one-dimensional array.
        /// </summary>
        /// <exception cref="ArgumentNullException">The array can not be null.</exception>
        /// <typeparam name="T">The type of the items in the array.</typeparam>
        /// <param name="array">The one-dimensional array to reverse.</param>
        /// <returns>Returns the reversed array.</returns>
        public static T[] Reverse<T>( this T[] array )
        {
            array.ThrowIfNull( () => array );

            Array.Reverse( array );
            return array;
        }

        /// <summary>
        ///     Reverses the sequence of the elements in a range of elements in the one-dimensional .
        /// </summary>
        /// <exception cref="ArgumentNullException">The array can not be null.</exception>
        /// <typeparam name="T">The type of the items in the array.</typeparam>
        /// <param name="array">The one-dimensional array to reverse.</param>
        /// <param name="index">The starting index of the section to reverse.</param>
        /// <param name="length">The number of elements in the section to reverse.</param>
        /// <returns>Returns the reversed array.</returns>
        public static T[] Reverse<T>( this T[] array, Int32 index, Int32 length )
        {
            array.ThrowIfNull( () => array );

            Array.Reverse( array, index, length );
            return array;
        }
    }
}