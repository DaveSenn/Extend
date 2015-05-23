#region Usings

using System;
using System.Collections.Generic;

#endregion

namespace Extend
{
    public static partial class StringEx
    {
        /// <summary>
        ///     Concatenates all the elements of a string array, using the specified separator between each element.
        /// </summary>
        /// <exception cref="ArgumentNullException">The values can not be null.</exception>
        /// <param name="separator">
        ///     The string to use as a separator.
        ///     Is included in the returned string only if it has more than one element.
        /// </param>
        /// <param name="values">An array that contains the elements to concatenate.</param>
        /// <returns>
        ///     A string that consists of the elements in  delimited by the  string.
        ///     If is an empty array, the method returns String.Empty.
        /// </returns>
        public static String Join( this String separator, String[] values )
        {
            separator.ThrowIfNull( () => separator );
            values.ThrowIfNull( () => values );

            return String.Join( separator, values );
        }

        /// <summary>
        ///     Concatenates all the elements of a object array, using the specified separator between each element.
        /// </summary>
        /// <exception cref="ArgumentNullException">The values can not be null.</exception>
        /// <param name="separator">
        ///     The string to use as a separator.
        ///     Is included in the returned string only if it has more than one element.
        /// </param>
        /// <param name="values">An array that contains the elements to concatenate.</param>
        /// <returns>
        ///     A string that consists of the elements in  delimited by the  string.
        ///     If is an empty array, the method returns String.Empty.
        /// </returns>
        public static String Join( this String separator, Object[] values )
        {
            separator.ThrowIfNull( () => separator );
            values.ThrowIfNull( () => values );

            return String.Join( separator, values );
        }

        /// <summary>
        ///     Concatenates all the elements of a IEnumerable, using the specified separator between each element.
        /// </summary>
        /// <exception cref="ArgumentNullException">The values can not be null.</exception>
        /// <typeparam name="T">The type of the items in the IEnumerable.</typeparam>
        /// <param name="separator">
        ///     The string to use as a separator.
        ///     Is included in the returned string only if it has more than one element.
        /// </param>
        /// <param name="values">An IEnumerable that contains the elements to concatenate.</param>
        /// <returns>
        ///     A string that consists of the elements in  delimited by the string.
        ///     If is an empty IEnumerable, the method returns String.Empty.
        /// </returns>
        public static String Join<T>( this String separator, IEnumerable<T> values )
        {
            separator.ThrowIfNull( () => separator );
            values.ThrowIfNull( () => values );

            return String.Join( separator, values );
        }

        /// <summary>
        ///     Concatenates all the elements of a string array, using the specified separator between each element.
        /// </summary>
        /// <exception cref="ArgumentNullException">The values can not be null.</exception>
        /// <param name="separator">
        ///     The string to use as a separator.
        ///     Is included in the returned string only if it has more than one element.
        /// </param>
        /// <param name="values">An array that contains the elements to concatenate.</param>
        /// <param name="startIndex">The first element in to use.</param>
        /// <param name="count">The number of elements of to use.</param>
        /// <returns>
        ///     A string that consists of the elements in  delimited by the  string.
        ///     If is an empty array, the method returns String.Empty.
        /// </returns>
        public static String Join( this String separator, String[] values, Int32 startIndex, Int32 count )
        {
            separator.ThrowIfNull( () => separator );
            values.ThrowIfNull( () => values );

            return String.Join( separator, values, startIndex, count );
        }
    }
}