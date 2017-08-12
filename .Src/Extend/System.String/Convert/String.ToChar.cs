#region Usings

using System;
using JetBrains.Annotations;

#endregion

namespace Extend
{
    public static partial class StringEx
    {
        /// <summary>
        ///     Converts the first character of a specified string to a Unicode character.
        /// </summary>
        /// <remarks>
        ///     The framework does not know a culture specific convert method, so does this library.
        /// </remarks>
        /// <exception cref="ArgumentNullException">The value can not be null.</exception>
        /// <exception cref="FormatException">The length of value is not 1.</exception>
        /// <param name="value">A string of length 1.</param>
        /// <returns>Returns a Unicode character that is equivalent to the first and only character in value.</returns>
        [Pure]
        [PublicAPI]
        public static Char ToChar( [NotNull] this String value )
        {
            value.ThrowIfNull( nameof(value) );

            return Convert.ToChar( value );
        }
    }
}