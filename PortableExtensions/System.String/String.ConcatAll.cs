#region Using

using System;

#endregion

namespace PortableExtensions
{
    public static partial class StringEx
    {
        /// <summary>
        ///     Concatenates all given strings.
        /// </summary>
        /// <param name="str">The first string to concatenate.</param>
        /// <param name="strings">All strings to concatenate.</param>
        /// <returns>The concatenation of all strings.</returns>
        public static String ConcatAll( this String str, params String[] strings )
        {
            strings.ThrowIfNull( () => strings );

            return String.Concat( str, String.Concat( strings ) );
        }

        /// <summary>
        ///     Concatenates all given strings.
        /// </summary>
        /// <param name="strings">All strings to concatenate.</param>
        /// <returns>The concatenation of all strings.</returns>
        public static String ConcatAll( this String[] strings )
        {
            strings.ThrowIfNull( () => strings );

            return String.Concat( strings );
        }

        /// <summary>
        ///     Concatenates all given values.
        /// </summary>
        /// <param name="str">The first string to concatenate.</param>
        /// <param name="values">All values to concatenate.</param>
        /// <returns>The concatenation of all values.</returns>
        public static String ConcatAll( this String str, params Object[] values )
        {
            values.ThrowIfNull( () => values );

            return String.Concat( str, String.Concat( values ) );
        }

        /// <summary>
        ///     Concatenates all given values.
        /// </summary>
        /// <param name="values">All values to concatenate.</param>
        /// <returns>The concatenation of all values.</returns>
        public static String ConcatAll( this Object[] values )
        {
            values.ThrowIfNull( () => values );

            return String.Concat( values );
        }
    }
}