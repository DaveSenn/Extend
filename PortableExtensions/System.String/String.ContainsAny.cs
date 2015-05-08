#region Usings

using System;
using System.Linq;

#endregion

namespace PortableExtensions
{
    public static partial class StringEx
    {
        /// <summary>
        ///     Checks if the string contains any of the values given.
        /// </summary>
        /// <exception cref="ArgumentNullException">The string can not be null.</exception>
        /// <exception cref="ArgumentNullException">The values can not be null.</exception>
        /// <param name="str">The string to check.</param>
        /// <param name="values">The values to search for.</param>
        /// <returns>Returns true if the string contains any of the values given, otherwise false.</returns>
        public static Boolean ContainsAny( this String str, params String[] values )
        {
            str.ThrowIfNull( () => str );
            values.ThrowIfNull( () => values );

            return values.Any( str.Contains );
        }

        /// <summary>
        ///     Checks if the string contains any of the values given.
        /// </summary>
        /// <exception cref="ArgumentNullException">The string can not be null.</exception>
        /// <exception cref="ArgumentNullException">The values can not be null.</exception>
        /// <param name="str">The string to check.</param>
        /// <param name="values">The values to search for.</param>
        /// <param name="comparisonType">The string comparison type.</param>
        /// <returns>Returns true if the string contains any of the values given, otherwise false.</returns>
        public static Boolean ContainsAny( this String str, StringComparison comparisonType, params String[] values )
        {
            str.ThrowIfNull( () => str );
            values.ThrowIfNull( () => values );

            return values.Any( x => str.IndexOf( x, comparisonType ) != -1 );
        }
    }
}