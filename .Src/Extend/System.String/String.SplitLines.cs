#region Usings

using System;
using JetBrains.Annotations;

#endregion

namespace Extend
{
    public static partial class StringEx
    {
        /// <summary>
        ///     Splits the given string at each line break (<see cref="Environment.NewLine" />).
        /// </summary>
        /// <exception cref="ArgumentNullException">value can not be null.</exception>
        /// <param name="value">The string to split.</param>
        /// <param name="stringSplitOptions">
        ///     <see cref="System.StringSplitOptions.RemoveEmptyEntries" /> to omit empty array elements
        ///     from the array returned; or System.StringSplitOptions.None to include empty
        ///     array elements in the array returned.
        /// </param>
        /// <returns>
        ///     Returns an array whose elements contain the substrings in this string that are delimited by
        ///     <see cref="Environment.NewLine" />.
        /// </returns>
        [NotNull]
        [Pure]
        [PublicAPI]
        public static String[] SplitLines( [NotNull] this String value, StringSplitOptions stringSplitOptions )
        {
            value.ThrowIfNull( nameof(value) );

            return value.Split( new[]
                                {
                                    Environment.NewLine
                                },
                                stringSplitOptions );
        }

        /// <summary>
        ///     Splits the given string at each line break (<see cref="Environment.NewLine" />).
        /// </summary>
        /// <exception cref="ArgumentNullException">value can not be null.</exception>
        /// <param name="value">The string to split.</param>
        /// <returns>
        ///     Returns an array whose elements contain the substrings in this string that are delimited by
        ///     <see cref="Environment.NewLine" />.
        /// </returns>
        [NotNull]
        [Pure]
        [PublicAPI]
        public static String[] SplitLines( [NotNull] this String value )
            => value.SplitLines( StringSplitOptions.RemoveEmptyEntries );
    }
}