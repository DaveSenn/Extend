#region Usings

using System;
using System.Globalization;
using JetBrains.Annotations;

#endregion

namespace Extend
{
    public static partial class StringEx
    {
        /// <summary>
        ///     Converts the given string to a Int64.
        /// </summary>
        /// <exception cref="ArgumentNullException">The value can not be null.</exception>
        /// <param name="value">The string to convert.</param>
        /// <returns>Returns the converted Int64.</returns>
        [Pure]
        [PublicAPI]
        public static Int64 ToInt64( [NotNull] this String value )
        {
            value.ThrowIfNull( nameof( value ) );

            return Convert.ToInt64( value, CultureInfo.InvariantCulture );
        }

        /// <summary>
        ///     Converts the given string to a Int64.
        /// </summary>
        /// <exception cref="ArgumentNullException">The value can not be null.</exception>
        /// <exception cref="ArgumentNullException">The format provider can not be null.</exception>
        /// <param name="value">The string to convert.</param>
        /// <param name="formatProvider">The format provider.</param>
        /// <returns>Returns the converted Int64.</returns>
        [Pure]
        [PublicAPI]
        public static Int64 ToInt64( [NotNull] this String value, [NotNull] IFormatProvider formatProvider )
        {
            value.ThrowIfNull( nameof( value ) );
            formatProvider.ThrowIfNull( nameof( formatProvider ) );

            return Convert.ToInt64( value, formatProvider );
        }
    }
}