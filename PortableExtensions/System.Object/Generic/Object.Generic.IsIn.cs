#region Usings

using System;
using System.Collections.Generic;
using System.Linq;

#endregion

namespace PortableExtensions
{
    /// <summary>
    ///     Class containing some extension methods for <see cref="object" />.
    /// </summary>
    public static partial class ObjectEx
    {
        /// <summary>
        ///     Checks if the value is present in the given array.
        /// </summary>
        /// <exception cref="ArgumentNullException">The values can not be null.</exception>
        /// <param name="value">The value to search for.</param>
        /// <param name="values">A IEnumerable containing the values.</param>
        /// <typeparam name="T">The type of the value.</typeparam>
        /// <returns>>Returns true if the value is present in the array.</returns>
        public static Boolean IsIn<T> ( this T value, params T[] values )
        {
            values.ThrowIfNull( () => values );

            return Array.IndexOf( values, value ) != -1;
        }

        /// <summary>
        ///     Checks if the value is present in the given IEnumerable.
        /// </summary>
        /// <exception cref="ArgumentNullException">The values can not be null.</exception>
        /// <param name="value">The value to search for.</param>
        /// <param name="values">A IEnumerable containing the values.</param>
        /// <typeparam name="T">The type of the value.</typeparam>
        /// <returns>>Returns true if the value is present in the IEnumerable.</returns>
        public static Boolean IsIn<T> ( this T value, IEnumerable<T> values )
        {
            values.ThrowIfNull( () => values );

            return values.Contains( value );
        }
    }
}