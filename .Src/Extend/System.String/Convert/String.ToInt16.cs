#region Usings

using System;
using JetBrains.Annotations;

#endregion

namespace Extend
{
    public static partial class StringEx
    {
        /// <summary>
        ///     Converts the given string to a Int16.
        /// </summary>
        /// <exception cref="ArgumentNullException">The value can not be null.</exception>
        /// <exception cref="FormatException">value  s not in the correct format.</exception>
        /// <exception cref="OverflowException">
        ///     value represents a number less than <see cref="Int16.MinValue" /> or greater than
        ///     <see cref="Int16.MaxValue" />.
        /// </exception>
        /// <param name="value">The string to convert.</param>
        /// <returns>Returns the converted Int16.</returns>
        [Pure]
        [PublicAPI]
        public static Int16 ToInt16( [NotNull] this String value )
        {
            value.ThrowIfNull( nameof( value ) );

            return Int16.Parse( value );
        }

        /// <summary>
        ///     Converts the given string to a Int16.
        /// </summary>
        /// <exception cref="ArgumentNullException">The value can not be null.</exception>
        /// <exception cref="ArgumentNullException">The format provider can not be null.</exception>
        /// <exception cref="FormatException">value  s not in the correct format.</exception>
        /// <exception cref="OverflowException">
        ///     value represents a number less than <see cref="Int16.MinValue" /> or greater than
        ///     <see cref="Int16.MaxValue" />.
        /// </exception>
        /// <param name="value">The string to convert.</param>
        /// <param name="formatProvider">The format provider.</param>
        /// <returns>Returns the converted Int16.</returns>
        [Pure]
        [PublicAPI]
        public static Int16 ToInt16( [NotNull] this String value, [NotNull] IFormatProvider formatProvider )
        {
            value.ThrowIfNull( nameof( value ) );
            formatProvider.ThrowIfNull( nameof( formatProvider ) );

            return Int16.Parse( value, formatProvider );
        }
    }
}