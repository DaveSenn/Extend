#region Usings

using System;
using JetBrains.Annotations;

#endregion

namespace Extend
{
    public static partial class StringEx
    {
        /// <summary>
        ///     Returns a string containing a specified number of characters from the right side of a string.
        /// </summary>
        /// <param name="count">The number of characters to return.</param>
        /// <exception cref="ArgumentNullException">value can not be null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">count is less than 0 or greater than the length of the string.</exception>
        /// <param name="value">The string from which the rightmost characters are returned.</param>
        /// <returns>Returns a string containing a specified number of characters from the right side of a string.</returns>
        [NotNull]
        [Pure]
        [PublicAPI]
        public static String Right( [NotNull] this String value, Int32 count )
        {
            value.ThrowIfNull( nameof(value) );

            if ( count < 0 || value.Length < count )
                throw new ArgumentOutOfRangeException( nameof(count), count, "The specified amount of characters is out of range." );

            return value.Substring( value.Length - count, count );
        }
    }
}