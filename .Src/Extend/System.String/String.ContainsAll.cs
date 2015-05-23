#region Usings

using System;

#endregion

namespace Extend
{
    public static partial class StringEx
    {
        /// <summary>
        ///     Checks if the string contains all values given.
        /// </summary>
        /// <exception cref="ArgumentNullException">The string can not be null.</exception>
        /// <exception cref="ArgumentNullException">The values can not be null.</exception>
        /// <param name="str">The string to check.</param>
        /// <param name="values">A list of string values.</param>
        /// <returns>Returns true if the string contains all values, otherwise false.</returns>
        public static Boolean ContainsAll( this String str, params String[] values )
        {
            str.ThrowIfNull( () => str );
            values.ThrowIfNull( () => values );

            return values.NotAny( x => !str.Contains( x ) );
        }

        /// <summary>
        ///     Checks if the string contains all values given.
        /// </summary>
        /// <exception cref="ArgumentNullException">The string can not be null.</exception>
        /// <exception cref="ArgumentNullException">The values can not be null.</exception>
        /// <param name="str">The string to check.</param>
        /// <param name="comparisonType">Type of the comparison.</param>
        /// <param name="values">A list of string values.</param>
        /// <returns>Returns true if the string contains all values, otherwise false.</returns>
        public static Boolean ContainsAll( this String str, StringComparison comparisonType, params String[] values )
        {
            str.ThrowIfNull( () => str );
            values.ThrowIfNull( () => values );

            return values.NotAny( x => str.IndexOf( x, comparisonType ) == -1 );
        }
    }
}