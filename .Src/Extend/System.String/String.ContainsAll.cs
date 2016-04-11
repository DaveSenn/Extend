#region Usings

using System;
using JetBrains.Annotations;

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
        /// <param name="s">The string to check.</param>
        /// <param name="values">A list of string values.</param>
        /// <returns>Returns true if the string contains all values, otherwise false.</returns>
        [Pure]
        [PublicAPI]
        public static Boolean ContainsAll( [NotNull] this String s, [NotNull] params String[] values )
        {
            s.ThrowIfNull( nameof( s ) );
            values.ThrowIfNull( nameof( values ) );

            return values.NotAny( x => !s.Contains( x ) );
        }

        /// <summary>
        ///     Checks if the string contains all values given.
        /// </summary>
        /// <exception cref="ArgumentNullException">The string can not be null.</exception>
        /// <exception cref="ArgumentNullException">The values can not be null.</exception>
        /// <param name="s">The string to check.</param>
        /// <param name="comparisonType">Type of the comparison.</param>
        /// <param name="values">A list of string values.</param>
        /// <returns>Returns true if the string contains all values, otherwise false.</returns>
        [Pure]
        [PublicAPI]
        public static Boolean ContainsAll( [NotNull] this String s, StringComparison comparisonType, [NotNull] params String[] values )
        {
            s.ThrowIfNull( nameof( s ) );
            values.ThrowIfNull( nameof( values ) );

            return values.NotAny( x => s.IndexOf( x, comparisonType ) == -1 );
        }
    }
}