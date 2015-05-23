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
        ///     Copies the spcified range of items from the source array to the given arget array.
        /// </summary>
        /// <exception cref="ArgumentNullException">array can not be null.</exception>
        /// <exception cref="ArgumentNullException">targetArray can not be null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">The start index must be greater or equals to zero.</exception>
        /// <exception cref="ArgumentOutOfRangeException">The number of items to cpoy must be greater or equals to zero.</exception>
        /// <exception cref="ArgumentOutOfRangeException">The start index cannot be greater than the length of the given array.</exception>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     The number of items to copy cannot be greater than the length of the
        ///     target array.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     The number of items to copy cannot be greater than the length of the
        ///     source array (minus the start index).
        /// </exception>
        /// <typeparam name="T">The type of the items in the array.</typeparam>
        /// <param name="array">The source array.</param>
        /// <param name="startIndex">The start index of the items range.</param>
        /// <param name="itemsToCpoy">The number of items to cpoy, starting at the given start index.</param>
        /// <param name="targetArray">The tartget array.</param>
        /// <returns>Returns the target array.</returns>
        public static T[] Slice<T>( this T[] array, Int32 startIndex, Int32 itemsToCpoy, T[] targetArray )
        {
            array.ThrowIfNull( () => array );
            targetArray.ThrowIfNull( () => targetArray );

            if ( startIndex < 0 )
                throw new ArgumentOutOfRangeException( array.GetName( x => startIndex ),
                                                       "The start index must be greater or equals to zero." );

            if ( itemsToCpoy < 0 )
                throw new ArgumentOutOfRangeException( array.GetName( x => itemsToCpoy ),
                                                       "The number of items to cpoy must be greater or equals to zero." );

            if ( startIndex > array.Length )
                throw new ArgumentOutOfRangeException( array.GetName( x => startIndex ),
                                                       "The start index cannot be greater than the length of the given array." );

            if ( itemsToCpoy > targetArray.Length )
                throw new ArgumentOutOfRangeException( array.GetName( x => itemsToCpoy ),
                                                       "The number of items to copy cannot be greater than the length of the target array." );

            if ( itemsToCpoy > array.Length - startIndex )
                throw new ArgumentOutOfRangeException( array.GetName( x => itemsToCpoy ),
                                                       "The number of items to copy cannot be greater than the length of the source array (minus the start index)." );

            for ( var i = 0; i < itemsToCpoy; ++i )
                targetArray[i] = array[startIndex + i];

            return targetArray;
        }

        /// <summary>
        ///     Copies the spcified range of items from the source array to the given arget array.
        /// </summary>
        /// <exception cref="ArgumentNullException">array can not be null.</exception>
        /// <exception cref="ArgumentNullException">targetArray can not be null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">The start index must be greater or equals to zero.</exception>
        /// <exception cref="ArgumentOutOfRangeException">The number of items to cpoy must be greater or equals to zero.</exception>
        /// <exception cref="ArgumentOutOfRangeException">The start index cannot be greater than the length of the given array.</exception>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     The number of items to copy cannot be greater than the length of the
        ///     source array (minus the start index).
        /// </exception>
        /// <typeparam name="T">The type of the items in the array.</typeparam>
        /// <param name="array">The source array.</param>
        /// <param name="startIndex">The start index of the items range.</param>
        /// <param name="itemsToCpoy">The number of items to cpoy, starting at the given start index.</param>
        /// <returns>Returns the target array.</returns>
        public static T[] Slice<T>( this T[] array, Int32 startIndex, Int32 itemsToCpoy )
        {
            var targetArray = new T[itemsToCpoy];
            return array.Slice( startIndex, itemsToCpoy, targetArray );
        }

        /// <summary>
        ///     Cpoies the spcified range of items from the source array to the given arget array.
        /// </summary>
        /// <exception cref="ArgumentNullException">array can not be null.</exception>
        /// <exception cref="ArgumentNullException">targetArray can not be null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">The number of items to cpoy must be greater or equals to zero.</exception>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     The number of items to copy cannot be greater than the length of the
        ///     target array.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     The number of items to copy cannot be greater than the length of the
        ///     source array.
        /// </exception>
        /// <typeparam name="T">The type of the items in the array.</typeparam>
        /// <param name="array">The source array.</param>
        /// <param name="itemsToCpoy">The number of items to cpoy, starting at the given start index.</param>
        /// <param name="targetArray">The tartget array.</param>
        /// <returns>Returns the target array.</returns>
        public static T[] Slice<T>( this T[] array, Int32 itemsToCpoy, T[] targetArray )
        {
            return array.Slice( 0, itemsToCpoy, targetArray );
        }

        /// <summary>
        ///     Cpoies the spcified range of items from the source array to the given arget array.
        /// </summary>
        /// <exception cref="ArgumentNullException">array can not be null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">The number of items to cpoy must be greater or equals to zero.</exception>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     The number of items to copy cannot be greater than the length of the
        ///     source array.
        /// </exception>
        /// <typeparam name="T">The type of the items in the array.</typeparam>
        /// <param name="array">The source array.</param>
        /// <param name="itemsToCpoy">The number of items to cpoy, starting at the given start index.</param>
        /// <returns>Returns the target array.</returns>
        public static T[] Slice<T>( this T[] array, Int32 itemsToCpoy )
        {
            var targetArray = new T[itemsToCpoy];
            return array.Slice( 0, itemsToCpoy, targetArray );
        }
    }
}