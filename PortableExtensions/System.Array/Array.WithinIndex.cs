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
        ///     Checks if the given index is within the array or not.
        /// </summary>
        /// <exception cref="ArgumentNullException">Array can not be null.</exception>
        /// <param name="array">The array to check.</param>
        /// <param name="index">a Zero-based index.</param>
        /// <returns>Ture if the index is within the array, otherwise false.</returns>
        public static Boolean WithinIndex ( this Array array, Int32 index )
        {
            array.ThrowIfNull( () => array );

            return index >= 0 && index < array.Length;
        }
    }
}