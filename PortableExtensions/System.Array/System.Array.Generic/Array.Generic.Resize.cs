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
        ///     Resizes the given array to the specified size.
        /// </summary>
        /// <exception cref="ArgumentNullException">The array can not be null.</exception>
        /// <typeparam name="T">The type of the items in the array.</typeparam>
        /// <param name="array">The array to resize.</param>
        /// <param name="newSize">The new size of the array.</param>
        /// <returns>Returns the given array with the new size.</returns>
        public static T[] Resize<T>( this T[] array, Int32 newSize )
        {
            // ReSharper disable once AccessToModifiedClosure
            array.ThrowIfNull( () => array );

            Array.Resize( ref array, newSize );
            return array;
        }
    }
}