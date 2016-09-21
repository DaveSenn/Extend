#region Usings

using System;
using JetBrains.Annotations;

#endregion

namespace Extend
{
    public static partial class StringEx
    {
        /// <summary>
        ///     Returns a string array that contains the substrings in this string that are
        ///     delimited by the given separator. A parameter specifies
        ///     whether to return empty array elements.
        /// </summary>
        /// <exception cref="ArgumentNullException">The string can not be null.</exception>
        /// <exception cref="ArgumentNullException">The separator can not be null.</exception>
        /// <param name="value">The string to split.</param>
        /// <param name="separator">A string that delimit the substrings in this string.</param>
        /// <param name="stringSplitOption">
        ///     <see cref="System.StringSplitOptions.RemoveEmptyEntries" /> to omit empty array elements
        ///     from the array returned; or System.StringSplitOptions.None to include empty
        ///     array elements in the array returned.
        /// </param>
        /// <returns>
        ///     Returns an array whose elements contain the substrings in this string that are delimited by the separator.
        /// </returns>
        [NotNull]
        [Pure]
        [PublicAPI]
        public static String[] Split( [NotNull] this String value,
                                      [NotNull] String separator,
                                      StringSplitOptions stringSplitOption = StringSplitOptions.None )
        {
            value.ThrowIfNull( nameof( value ) );
            separator.ThrowIfNull( nameof( separator ) );

            return value.Split( new[]
                                {
                                    separator
                                },
                                stringSplitOption );
        }

        /// <summary>
        ///     Returns a string array that contains the substrings in this string that are
        ///     delimited by elements of a specified string array. A parameter specifies
        ///     whether to return empty array elements.
        /// </summary>
        /// <exception cref="ArgumentNullException">The string can not be null.</exception>
        /// <exception cref="ArgumentNullException">The separator can not be null.</exception>
        /// <param name="value">The string to split.</param>
        /// <param name="separators">
        ///     An array of strings that delimit the substrings in this string, an empty
        ///     array that contains no delimiters, or null.
        /// </param>
        /// <param name="stringSplitOption">
        ///     <see cref="System.StringSplitOptions.RemoveEmptyEntries" /> to omit empty array elements
        ///     from the array returned; or System.StringSplitOptions.None to include empty
        ///     array elements in the array returned.
        /// </param>
        /// <returns>
        ///     Returns an array whose elements contain the substrings in this string that are delimited
        ///     by one or more strings in separator.
        /// </returns>
        [NotNull]
        [Pure]
        [PublicAPI]
        public static String[] Split( [NotNull] this String value,
                                      StringSplitOptions stringSplitOption,
                                      [NotNull] params String[] separators )
        {
            value.ThrowIfNull( nameof( value ) );
            separators.ThrowIfNull( nameof( separators ) );

            return value.Split( separators, stringSplitOption );
        }
    }
}