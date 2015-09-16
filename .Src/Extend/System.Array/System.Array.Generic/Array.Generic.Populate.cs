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
        ///     Populates the given array with the specified value.
        /// </summary>
        /// <exception cref="ArgumentNullException">array can not be null.</exception>
        /// <typeparam name="T">The type of the items in the array.</typeparam>
        /// <param name="array">The array.</param>
        /// <param name="value">The value.</param>
        /// <returns>Returns the given array.</returns>
        public static T[] Populate<T>( this T[] array, T value )
        {
            array.ThrowIfNull(nameof(array));

            for ( var i = 0; i < array.Length; i++ )
                array[i] = value;

            return array;
        }
    }
}