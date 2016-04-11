#region Usings

using System;
using System.Linq;
using JetBrains.Annotations;

#endregion

namespace Extend
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
        [Pure]
        [PublicAPI]
        public static Boolean ContainsAny( [NotNull] this String str, [NotNull] params String[] values )
        {
            str.ThrowIfNull( nameof( str ) );
            values.ThrowIfNull( nameof( values ) );

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
        [Pure]
        [PublicAPI]
        public static Boolean ContainsAny( [NotNull] this String str, StringComparison comparisonType, [NotNull] params String[] values )
        {
            str.ThrowIfNull( nameof( str ) );
            values.ThrowIfNull( nameof( values ) );

            return values.Any( x => str.IndexOf( x, comparisonType ) != -1 );
        }
    }
}