#region Usings

using System;
using System.Globalization;

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
        /// <exception cref="ArgumentNullException">The value can not be null.</exception>
        /// <param name="value">A string containing a number to convert.</param>
        /// <param name="outValue">
        ///     When this method returns, contains the double-precision floating-point number
        ///     equivalent of the s parameter, if the conversion succeeded, or zero if the
        ///     conversion failed. The conversion fails if the s parameter is null or System.String.Empty,
        ///     is not a number in a valid format, or represents a number less than System.Double.MinValue
        ///     or greater than System.Double.MaxValue. This parameter is passed uninitialized.
        /// </param>
        /// <returns>Returns true if the parsing was successful, otherwise false.</returns>
        public static Boolean TryParsDouble( this String value, out Double outValue )
        {
            value.ThrowIfNull( () => value );

            return Double.TryParse( value, NumberStyles.Any, CultureInfo.InvariantCulture, out outValue );
        }

        /// <summary>
        ///     Converts the string representation of a number in a specified numberStyle and culture-specific
        ///     format to its double-precision floating-point number equivalent. A return
        ///     value indicates whether the conversion succeeded or failed.
        /// </summary>
        /// <exception cref="ArgumentNullException">The value can not be null.</exception>
        /// <exception cref="ArgumentException">
        ///     The value can not be null.
        ///     numberStyle is not a System.Globalization.NumberStyles value. -or-numberStyle includes
        ///     the System.Globalization.NumberStyles.AllowHexSpecifier value.
        /// </exception>
        /// <param name="value">A string containing a number to convert.</param>
        /// <param name="numberStyle">
        ///     A bitwise combination of System.Globalization.NumberStyles values that indicates
        ///     the permitted format of s. A typical value to specify is System.Globalization.NumberStyles.Float
        ///     combined with System.Globalization.NumberStyles.AllowThousands.
        /// </param>
        /// <param name="formatProvider">
        ///     An System.IFormatProvider that supplies culture-specific formatting information
        ///     about s.
        /// </param>
        /// <param name="outValue">
        ///     When this method returns, contains a double-precision floating-point number
        ///     equivalent of the numeric value or symbol contained in s, if the conversion
        ///     succeeded, or zero if the conversion failed. The conversion fails if the
        ///     s parameter is null or System.String.Empty, is not in a format compliant
        ///     with numberStyle, represents a number less than System.SByte.MinValue or greater
        ///     than System.SByte.MaxValue, or if numberStyle is not a valid combination of System.Globalization.NumberStyles
        ///     enumerated constants. This parameter is passed uninitialized.
        /// </param>
        /// <returns></returns>
        public static Boolean TryParsDouble( this String value,
                                             NumberStyles numberStyle,
                                             IFormatProvider formatProvider,
                                             out Double outValue )
        {
            value.ThrowIfNull( () => value );
            formatProvider.ThrowIfNull( () => formatProvider );

            return Double.TryParse( value, numberStyle, formatProvider, out outValue );
        }
    }
}