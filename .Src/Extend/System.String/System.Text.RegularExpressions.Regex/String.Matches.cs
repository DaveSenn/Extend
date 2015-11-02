﻿#region Usings

using System;
using System.Text.RegularExpressions;

#endregion

namespace Extend
{
    public static partial class StringEx
    {
        /// <summary>
        ///     Searches the specified input string for all occurrences of a specified regular expression.
        /// </summary>
        /// <param name="input">The string to search for a match.</param>
        /// <param name="pattern">The regular expression pattern to match.</param>
        /// <returns>
        ///     A collection of the  objects found by the search. If no matches are found, the method returns an empty
        ///     collection object.
        /// </returns>
        public static MatchCollection Matches( this String input, String pattern )
        {
            input.ThrowIfNull( nameof( input ) );
            pattern.ThrowIfNull( nameof( pattern ) );

            return Regex.Matches( input, pattern );
        }

        /// <summary>
        ///     Searches the specified input string for all occurrences of a specified regular expression, using the
        ///     specified matching options.
        /// </summary>
        /// <param name="input">The string to search for a match.</param>
        /// <param name="pattern">The regular expression pattern to match.</param>
        /// <param name="options">A bitwise combination of the enumeration values that specify options for matching.</param>
        /// <returns>
        ///     A collection of the  objects found by the search. If no matches are found, the method returns an empty
        ///     collection object.
        /// </returns>
        public static MatchCollection Matches( this String input, String pattern, RegexOptions options )
        {
            input.ThrowIfNull( nameof( input ) );
            pattern.ThrowIfNull( nameof( pattern ) );

            return Regex.Matches( input, pattern, options );
        }

#if PORTABLE45
    /// <summary>
    ///     Searches the specified input string for all occurrences of a specified regular expression, using the
    ///     specified matching options.
    /// </summary>
    /// <param name="input">The string to search for a match.</param>
    /// <param name="pattern">The regular expression pattern to match.</param>
    /// <param name="options">A bitwise combination of the enumeration values that specify options for matching.</param>
    /// <param name="timeOut">The timeout for the regular expression operation.</param>
    /// <returns>
    ///     A collection of the  objects found by the search. If no matches are found, the method returns an empty
    ///     collection object.
    /// </returns>
        public static MatchCollection Matches( this String input, String pattern, RegexOptions options, TimeSpan timeOut )
        {
            input.ThrowIfNull( nameof( input ) );
            pattern.ThrowIfNull( nameof( pattern ) );
            timeOut.ThrowIfNull( nameof( timeOut ) );

            return Regex.Matches( input, pattern, options, timeOut );
        }
#endif
    }
}