#region Usings

using System;
using System.Collections.Generic;

#endregion

namespace PortableExtensions
{
    /// <summary>
    ///     Class containing some extension methods for <see cref="object" />.
    /// </summary>
    public static partial class ObjectEx
    {
        /// <summary>
        ///     Checks if the value is not present in the given array.
        /// </summary>
        /// <param name="value">The value to search for.</param>
        /// <param name="values">A IEnumerable containing the values.</param>
        /// <typeparam name="T">The type of the value.</typeparam>
        /// <returns>>Returns true if the value is not present in the array.</returns>
        public static Boolean IsNotIn<T> ( this T value, params T[] values )
        {
            return !IsIn( value, values );
        }

        /// <summary>
        ///     Checks if the value is not present in the given IEnumerable.
        /// </summary>
        /// <param name="value">The value to search for.</param>
        /// <param name="values">A IEnumerable containing the values.</param>
        /// <typeparam name="T">The type of the value.</typeparam>
        /// <returns>>Returns true if the value is not present in the IEnumerable.</returns>
        public static Boolean IsNotIn<T> ( this T value, IEnumerable<T> values )
        {
            return !IsIn( value, values );
        }
    }
}