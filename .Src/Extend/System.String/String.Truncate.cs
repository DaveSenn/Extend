#region Usings

using System;
using JetBrains.Annotations;

#endregion

namespace Extend
{
    public static partial class StringEx
    {
        /// <summary>
        ///     Truncates the given string to the specified maximum length and adds the specified
        ///     suffix to the end of the truncated string.
        /// </summary>
        /// <param name="str">The string to truncate.</param>
        /// <param name="maxLength">The maximum length of the truncated string.</param>
        /// <param name="suffix">The suffix of the truncated string.</param>
        /// <returns>The truncated string.</returns>
        [NotNull]
        [Pure]
        [PublicAPI]
        public static String Truncate( [CanBeNull] this String str, Int32 maxLength, String suffix = "..." )
        {
            // ReSharper disable once PossibleNullReferenceException
            if ( str.IsEmpty() || str.Length <= maxLength )
                // ReSharper disable once AssignNullToNotNullAttribute
                return str;

            return str.Substring( 0, Math.Max( 0, maxLength - suffix.Length ) )
                      .ConcatAll( suffix );
        }
    }
}