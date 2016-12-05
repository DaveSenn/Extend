#region Usings

using System;
using System.Text.RegularExpressions;
using JetBrains.Annotations;

#endregion

namespace Extend
{
    public static partial class StringEx
    {
        /// <summary>
        ///     Gets whether a <see cref="Regex" /> with the specified pattern finds a match in the specified input
        ///     <see cref="String" />.
        /// </summary>
        /// <exception cref="ArgumentNullException">The input can not be null.</exception>
        /// <exception cref="ArgumentNullException">The pattern can not be null.</exception>
        /// <param name="input">The <see cref="String" /> to search for a match.</param>
        /// <param name="pattern">The regular expression pattern used by the <see cref="Regex" />.</param>
        /// <returns>A value of true if the regular expression finds a match, otherwise false.</returns>
        [Pure]
        [PublicAPI]
        public static Boolean IsMatch( [NotNull] this String input, [NotNull] String pattern )
        {
            input.ThrowIfNull( nameof( input ) );
            pattern.ThrowIfNull( nameof( pattern ) );

            return Regex.IsMatch( input, pattern );
        }

        /// <summary>
        ///     Gets whether a <see cref="Regex" /> with the specified pattern finds a match in the specified input
        ///     <see cref="String" />.
        /// </summary>
        /// <exception cref="ArgumentNullException">The input can not be null.</exception>
        /// <exception cref="ArgumentNullException">The pattern can not be null.</exception>
        /// <param name="input">The <see cref="String" /> to search for a match.</param>
        /// <param name="pattern">The regular expression pattern used by the <see cref="Regex" />.</param>
        /// <param name="options">The regular expression options used by the <see cref="Regex" />.</param>
        /// <returns>A value of true if the regular expression finds a match, otherwise false.</returns>
        [Pure]
        [PublicAPI]
        public static Boolean IsMatch( [NotNull] this String input, [NotNull] String pattern, RegexOptions options )
        {
            input.ThrowIfNull( nameof( input ) );
            pattern.ThrowIfNull( nameof( pattern ) );

            return Regex.IsMatch( input, pattern, options );
        }

#if PORTABLE45
/// <summary>
///     Gets whether a <see cref="Regex" /> with the specified pattern finds a match in the specified input
///     <see cref="String" />.
/// </summary>
/// <exception cref="ArgumentNullException">The input can not be null.</exception>
/// <exception cref="ArgumentNullException">The pattern can not be null.</exception>
/// <param name="input">The <see cref="String" /> to search for a match.</param>
/// <param name="pattern">The regular expression pattern used by the <see cref="Regex" />.</param>
/// <param name="options">The regular expression options used by the <see cref="Regex" />.</param>
/// <param name="timeOut">The timeout for the match operation.</param>
/// <returns>A value of true if the regular expression finds a match, otherwise false.</returns>
        [Pure]
        [PublicAPI]
        public static Boolean IsMatch( [NotNull] this String input, [NotNull] String pattern, RegexOptions options, TimeSpan timeOut )
        {
            input.ThrowIfNull( nameof( input ) );
            pattern.ThrowIfNull( nameof( pattern ) );

            return Regex.IsMatch( input, pattern, options, timeOut );
        }
#endif
    }
}