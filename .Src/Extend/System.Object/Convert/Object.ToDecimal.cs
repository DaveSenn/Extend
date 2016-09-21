#region Usings

using System;
using JetBrains.Annotations;

#endregion

namespace Extend
{
    /// <summary>
    ///     Class containing some extension methods for <see cref="object" />.
    /// </summary>
    public static partial class ObjectEx
    {
        /// <summary>
        ///     Converts the value of the specified object to an equivalent decimal number.
        /// </summary>
        /// <exception cref="FormatException">value is not in an appropriate format for a <see cref="Decimal" /> type.</exception>
        /// <exception cref="InvalidCastException">
        ///     value does not implement the System.IConvertible interface. -or-The conversion
        ///     is not supported.
        /// </exception>
        /// <exception cref="OverflowException">
        ///     value represents a number that is less than <see cref="Decimal.MinValue" /> or greater than
        ///     <see cref="Decimal.MaxValue" />.
        /// </exception>
        /// <param name="obj">An object that implements the System.IConvertible interface, or null.</param>
        /// <returns>A decimal number that is equivalent to value, or 0 (zero) if value is null.</returns>
        [Pure]
        [PublicAPI]
        public static Decimal ToDecimal( [CanBeNull] this Object obj )
            => Convert.ToDecimal( obj );

        /// <summary>
        ///     Converts the value of the specified object to an equivalent decimal number, using the specified culture-specific
        ///     formatting information.
        /// </summary>
        /// <exception cref="FormatException">value is not in an appropriate format for a <see cref="Decimal" /> type.</exception>
        /// <exception cref="InvalidCastException">
        ///     value does not implement the System.IConvertible interface. -or-The conversion
        ///     is not supported.
        /// </exception>
        /// <exception cref="OverflowException">
        ///     value represents a number that is less than <see cref="Decimal.MinValue" /> or greater than
        ///     <see cref="Decimal.MaxValue" />.
        /// </exception>
        /// <param name="obj">An object that implements the System.IConvertible interface, or null.</param>
        /// <param name="formatProvider">The format provider.</param>
        /// <returns>A decimal number that is equivalent to value, or 0 (zero) if value is null.</returns>
        [Pure]
        [PublicAPI]
        public static Decimal ToDecimal( [CanBeNull] this Object obj, [CanBeNull] IFormatProvider formatProvider )
            => Convert.ToDecimal( obj, formatProvider );
    }
}