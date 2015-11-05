#region Usings

using System;

#endregion

namespace Extend
{
    public static partial class StringEx
    {
        /// <summary>
        ///     Checks whether a specified substring occurs within the given string, or not.
        /// </summary>
        /// <exception cref="ArgumentException"> comparisonType is not a valid <see cref="System.StringComparison" /> value.</exception>
        /// <exception cref="ArgumentNullException">str can not be null.</exception>
        /// <exception cref="ArgumentNullException">value can not be null.</exception>
        /// <param name="str">The string to search in.</param>
        /// <param name="value">The string to seek.</param>
        /// <param name="stringComparison">One of the enumeration values that specifies the rules for the search.</param>
        /// <returns>Returns true if the value parameter occurs within the given string; otherwise, false.</returns>
        public static Boolean Contains( this String str, String value, StringComparison stringComparison )
        {
            str.ThrowIfNull( nameof( str ) );
            value.ThrowIfNull( nameof( value ) );

            return str.IndexOf( value, stringComparison ) >= 0;
        }
    }
}