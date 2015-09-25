#region Usings

using System;

#endregion

namespace Extend
{
    public static partial class StringEx
    {
        /// <summary>
        ///     Tries to convert the specified string representation of a logical value to
        ///     its System.Boolean equivalent. A return value indicates whether the conversion
        ///     succeeded or failed.
        /// </summary>
        /// <exception cref="ArgumentNullException">The value can not be null.</exception>
        /// <param name="value">A string containing the value to convert.</param>
        /// <param name="outValue">
        ///     When this method returns, if the conversion succeeded, contains true if value
        ///     is equal to System.Boolean.TrueString or false if value is equal to System.Boolean.FalseString.
        ///     If the conversion failed, contains false. The conversion fails if value is
        ///     null or is not equal to the value of either the System.Boolean.TrueString
        ///     or System.Boolean.FalseString field.
        ///     The parsed value.
        /// </param>
        /// <returns>Returns true if the parsing was successful, otherwise false.</returns>
        public static Boolean TryParsBoolean( this String value, out Boolean outValue )
        {
            value.ThrowIfNull(nameof(value));

            return Boolean.TryParse( value, out outValue );
        }
    }
}