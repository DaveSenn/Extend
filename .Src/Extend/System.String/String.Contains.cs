#region Usings

using System;
using JetBrains.Annotations;

#endregion

namespace Extend
{
    public static partial class StringEx
    {
        /// <summary>
        ///     Checks whether a specified substring occurs within the given string, or not.
        /// </summary>
        /// <exception cref="ArgumentException"> comparisonType is not a valid <see cref="System.StringComparison" /> value.</exception>
        /// <exception cref="ArgumentNullException">s can not be null.</exception>
        /// <exception cref="ArgumentNullException">value can not be null.</exception>
        /// <param name="s">The string to search in.</param>
        /// <param name="value">The string to seek.</param>
        /// <param name="stringComparison">One of the enumeration values that specifies the rules for the search.</param>
        /// <returns>Returns true if the value parameter occurs within the given string; otherwise, false.</returns>
        [Pure]
        [PublicAPI]
        public static Boolean Contains( [NotNull] this String s, [NotNull] String value, StringComparison stringComparison )
        {
            s.ThrowIfNull( nameof( s ) );
            value.ThrowIfNull( nameof( value ) );

            return s.IndexOf( value, stringComparison ) >= 0;
        }
    }
}