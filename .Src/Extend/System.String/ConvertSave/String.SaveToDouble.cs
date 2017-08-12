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
        ///     number equivalent.
        /// </summary>
        /// <param name="value">A string containing a number to convert.</param>
        /// <param name="defaultValue">The default value, returned if the parsing fails.</param>
        /// <returns>Returns the converted value, or the given default value if the conversion failed.</returns>
        [Pure]
        [PublicAPI]
        public static Double SaveToDouble( [CanBeNull] this String value, Double defaultValue = default(Double) )
            => value.TryParsDouble( out Double outValue ) ? outValue : defaultValue;

        /// <summary>
        ///     Converts the string representation of a number in a specified numberStyle and culture-specific
        ///     format to its double-precision floating-point number equivalent.
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
        ///     An <see cref="System.IFormatProvider" /> that supplies culture-specific formatting information about value.
        /// </param>
        /// <param name="defaultValue">The default value, returned if the parsing fails.</param>
        /// <returns>Returns the converted value, or the given default value if the conversion failed.</returns>
        [Pure]
        [PublicAPI]
        public static Double SaveToDouble( [CanBeNull] this String value,
                                           NumberStyles numberStyle,
                                           [NotNull] IFormatProvider formatProvider,
                                           Double defaultValue = default(Double) )
        {
            formatProvider.ThrowIfNull( nameof(formatProvider) );

            return value.TryParsDouble( numberStyle, formatProvider, out Double outValue ) ? outValue : defaultValue;
        }
    }
}