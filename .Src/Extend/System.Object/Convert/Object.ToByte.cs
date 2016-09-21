#region Usings

using System;
using System.Globalization;
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
        ///     Converts the value of the specified object to an 8-bit unsigned integer.
        /// </summary>
        /// <exception cref="FormatException">value is not in the property format for a <see cref="Byte" /> value.</exception>
        /// <exception cref="InvalidCastException">
        ///     value does not implement System.IConvertible. -or-Conversion from value to the
        ///     <see cref="Byte" /> type is not supported.
        /// </exception>
        /// <exception cref="OverflowException">
        ///     value represents a number that is less than <see cref="Byte.MinValue" /> or
        ///     greater than <see cref="Byte.MaxValue" />.
        /// </exception>
        /// <param name="obj">An object that implements the System.IConvertible interface.</param>
        /// <returns>An 8-bit unsigned integer that is equivalent to value, or zero if value is null.</returns>
        [Pure]
        [PublicAPI]
        public static Byte ToByte( [CanBeNull] this Object obj )
            => Convert.ToByte( obj, CultureInfo.CurrentCulture );

        /// <summary>
        ///     Converts the value of the specified object to an 8-bit unsigned integer, using the specified culture-specific
        ///     formatting information.
        /// </summary>
        /// <exception cref="FormatException">value is not in the property format for a <see cref="Byte" /> value.</exception>
        /// <exception cref="InvalidCastException">
        ///     value does not implement System.IConvertible. -or-Conversion from value to the
        ///     <see cref="Byte" /> type is not supported.
        /// </exception>
        /// <exception cref="OverflowException">
        ///     value represents a number that is less than <see cref="Byte.MinValue" /> or
        ///     greater than <see cref="Byte.MaxValue" />.
        /// </exception>
        /// <param name="obj">An object that implements the System.IConvertible interface.</param>
        /// <param name="formatProvider">The format provider.</param>
        /// <returns>An 8-bit unsigned integer that is equivalent to value, or zero if value is null.</returns>
        [Pure]
        [PublicAPI]
        public static Byte ToByte( [CanBeNull] this Object obj, [CanBeNull] IFormatProvider formatProvider )
            => Convert.ToByte( obj, formatProvider );
    }
}