#region Usings

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
        /// <param name="array">The one-dimensional array to reverse.</param>
        public static void Reverse( this Array array )
        {
            array.ThrowIfNull( () => array );

            Array.Reverse( array );
        }

        /// <summary>
        ///     Reverses the sequence of the elements in a range of elements in the one-dimensional array.
        /// </summary>
        /// <exception cref="ArgumentNullException">The array can not be null.</exception>
        /// <param name="array">The one-dimensional array to reverse.</param>
        /// <param name="index">The starting index of the section to reverse.</param>
        /// <param name="length">The number of elements in the section to reverse.</param>
        public static void Reverse( this Array array, Int32 index, Int32 length )
        {
            array.ThrowIfNull( () => array );

            Array.Reverse( array, index, length );
        }
    }
}