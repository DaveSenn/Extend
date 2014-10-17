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
        ///     Clears the given array.
        /// </summary>
        /// <exception cref="ArgumentNullException">The array can not be null.</exception>
        /// <typeparam name="T">The type of the items in the array.</typeparam>
        /// <param name="array">The array to clear.</param>
        /// <returns>Returns the cleard array.</returns>
        public static T[] ClearAll<T> ( this T[] array )
        {
            array.ThrowIfNull( () => array );

            Array.Clear( array, 0, array.Length );
            return array;
        }
    }
}