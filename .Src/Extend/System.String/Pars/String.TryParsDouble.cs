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
        ///     Converts the string representation of a number to its double-precision floating-point
        ///     number equivalent. A return value indicates whether the conversion succeeded
        ///     or failed.
        /// </summary>
        /// <param name="value">A string containing a number to convert.</param>
        /// <param name="outValue">
        ///     When this method returns, contains the double-precision floating-point number
        ///     equivalent of the <paramref name="value" /> parameter, if the conversion succeeded, or zero if the
        ///     conversion failed. The conversion fails if the <paramref name="value" /> parameter is null or
        ///     <see cref="String.Empty" />,
        ///     is not a number in a valid format, or represents a number less than <see cref="Double.MinValue" />
        ///     or greater than <see cref="Double.MaxValue" />. This parameter is passed uninitialized.
        /// </param>
        /// <returns>Returns true if the parsing was successful, otherwise false.</returns>
        [Pure]
        [PublicAPI]
        public static Boolean TryParsDouble( [CanBeNull] this String value, out Double outValue )
            => Double.TryParse( value, out outValue );

        /// <summary>
        ///     Converts the string representation of a number in a specified numberStyle and culture-specific
        ///     format to its double-precision floating-point number equivalent. A return
        ///     value indicates whether the conversion succeeded or failed.
        /// </summary>
        /// <exception cref="ArgumentException">
        ///     numberStyle is not a <see cref="NumberStyles" /> value. -or-numberStyle includes
        ///     the <see cref="NumberStyles.AllowHexSpecifier" /> value.
        /// </exception>
        /// <exception cref="ArgumentNullException">formatProvider can not be null.</exception>
        /// <param name="value">A string containing a number to convert.</param>
        /// <param name="numberStyle">
        ///     A bitwise combination of <see cref="NumberStyles" /> values that indicates
        ///     the permitted format of <paramref name="value" />. A typical value to specify is <see cref="NumberStyles.Float" />
        ///     combined with <see cref="NumberStyles.AllowThousands" />.
        /// </param>
        /// <param name="formatProvider">
        ///     An <see cref="System.IFormatProvider" /> that supplies culture-specific formatting information about
        ///     <paramref name="value" />.
        /// </param>
        /// <param name="outValue">
        ///     When this method returns, contains a double-precision floating-point number
        ///     equivalent of the numeric value or symbol contained in <paramref name="value" />, if the conversion
        ///     succeeded, or zero if the conversion failed. The conversion fails if the
        ///     <paramref name="value" /> parameter is null or <see cref="String.Empty" />, is not in a format compliant
        ///     with numberStyle, represents a number less than <see cref="SByte.MinValue" /> or greater
        ///     than <see cref="SByte.MaxValue" />, or if numberStyle is not a valid combination of <see cref="NumberStyles" />
        ///     enumerated constants. This parameter is passed uninitialized.
        /// </param>
        /// <returns>Returns true if the parsing was successful, otherwise false.</returns>
        [Pure]
        [PublicAPI]
        public static Boolean TryParsDouble( [CanBeNull] this String value,
                                             NumberStyles numberStyle,
                                             [NotNull] IFormatProvider formatProvider,
                                             out Double outValue )
        {
            formatProvider.ThrowIfNull( nameof( formatProvider ) );

            return Double.TryParse( value, numberStyle, formatProvider, out outValue );
        }
    }
}