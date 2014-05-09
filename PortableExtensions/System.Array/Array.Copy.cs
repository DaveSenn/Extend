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
        ///     Copies a range of elements from an array starting at the first element and pastes them into another array starting
        ///     at
        ///     the first element. The length is specified as a 32-bit integer.
        /// </summary>
        /// <exception cref="ArgumentNullException">The source array can not be null.</exception>
        /// <exception cref="ArgumentNullException">The Destination array can not be null.</exception>
        /// <param name="sourceArray">The array that contains the data to copy.</param>
        /// <param name="destinationArray">The array that receives the data.</param>
        /// <param name="length">A 32-bit integer that represents the number of elements to copy.</param>
        public static void Copy( this Array sourceArray, Array destinationArray, Int32 length )
        {
            sourceArray.ThrowIfNull( () => sourceArray );
            destinationArray.ThrowIfNull( () => destinationArray );

            Array.Copy( sourceArray, destinationArray, length );
        }

        /// <summary>
        ///     Copies a range of elements from an array starting at the specified source index and pastes them to another array
        ///     starting at the specified destination index. The length and the indexes are specified as 32-bit integers.
        /// </summary>
        /// <exception cref="ArgumentNullException">The Source array can not be null.</exception>
        /// <exception cref="ArgumentNullException">The destination array can not be null.</exception>
        /// <param name="sourceArray">The array that contains the data to copy.</param>
        /// <param name="sourceIndex">A 32-bit integer that represents the index in the  at which copying begins.</param>
        /// <param name="destinationArray">The array that receives the data.</param>
        /// <param name="destinationIndex">A 32-bit integer that represents the index in the  at which storing begins.</param>
        /// <param name="length">A 32-bit integer that represents the number of elements to copy.</param>
        public static void Copy( this Array sourceArray, Int32 sourceIndex, Array destinationArray,
                                 Int32 destinationIndex, Int32 length )
        {
            sourceArray.ThrowIfNull( () => sourceArray );
            destinationArray.ThrowIfNull( () => destinationArray );

            Array.Copy( sourceArray, sourceIndex, destinationArray, destinationIndex, length );
        }

#if monox64 || DotNet
    /// <summary>
    ///     Copies a range of elements from an array starting at the first element and pastes them into another array starting at
    ///     the first element. The length is specified as a 64-bit integer.
    /// </summary>
    /// <exception cref="ArgumentNullException">The source array can not be null.</exception>
    /// <exception cref="ArgumentNullException">The destination array can not be null.</exception>
    /// <param name="sourceArray">The array that contains the data to copy.</param>
    /// <param name="destinationArray">The array that receives the data.</param>
    /// <param name="length">
    ///     A 64-bit integer that represents the number of elements to copy. The integer must be between
    ///     zero and , inclusive.
    /// </param>
        public static void Copy(this Array sourceArray, Array destinationArray, Int64 length)
        {
            sourceArray.ThrowIfNull (() => sourceArray);
            destinationArray.ThrowIfNull (() => destinationArray);

            Array.Copy(sourceArray, destinationArray, length);
        }

        /// <summary>
        ///     Copies a range of elements from an array starting at the specified source index and pastes them to another array
        ///     starting at the specified destination index. The length and the indexes are specified as 64-bit integers.
        /// </summary>
        /// <exception cref="ArgumentNullException">The source array can not be null.</exception>
        /// <exception cref="ArgumentNullException">The destination array can not be null.</exception>
        /// <param name="sourceArray">The array that contains the data to copy.</param>
        /// <param name="sourceIndex">A 64-bit integer that represents the index in the  at which copying begins.</param>
        /// <param name="destinationArray">The array that receives the data.</param>
        /// <param name="destinationIndex">A 64-bit integer that represents the index in the  at which storing begins.</param>
        /// <param name="length">
        ///     A 64-bit integer that represents the number of elements to copy. The integer must be between
        ///     zero and , inclusive.
        /// </param>
        public static void Copy(this Array sourceArray, Int64 sourceIndex, Array destinationArray, Int64 destinationIndex, Int64 length)
        {
            sourceArray.ThrowIfNull (() => sourceArray);
            destinationArray.ThrowIfNull (() => destinationArray);

            Array.Copy(sourceArray, sourceIndex, destinationArray, destinationIndex, length);
        }
#endif
    }
}