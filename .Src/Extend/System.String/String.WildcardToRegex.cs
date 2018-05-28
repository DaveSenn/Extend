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
        ///     Converts the given wild-card pattern to a RegEx.
        /// </summary>
        /// <param name="pattern">A wild-card pattern.</param>
        /// <returns>Returns the equivalent RegEx.</returns>
        [Pure]
        [NotNull]
        public static String WildcardToRegex( [NotNull] this String pattern )
        {
            pattern.ThrowIfNull( nameof(pattern) );

            return "^" + Regex.Escape( pattern )
                              .Replace( @"\*", ".*" )
                              .Replace( @"\?", "." )
                       + "$";
        }
    }
}