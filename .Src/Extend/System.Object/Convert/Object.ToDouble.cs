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
        ///     Converts the value of the specified object to a double-precision floating-point number.
        /// </summary>
        /// <exception cref="FormatException">value is not in an appropriate format for a <see cref="Double" /> type.</exception>
        /// <exception cref="InvalidCastException">
        ///     value does not implement the System.IConvertible interface.
        ///     Or the conversion is not supported.
        /// </exception>
        /// <exception cref="OverflowException">
        ///     value represents a number that is less than <see cref="Double.MinValue" /> or greater than
        ///     <see cref="Double.MaxValue" />.
        /// </exception>
        /// <param name="obj">An object that implements the System.IConvertible interface, or null.</param>
        /// <returns>A double-precision floating-point number that is equivalent to value, or zero if value is null.</returns>
        [Pure]
        [PublicAPI]
        public static Double ToDouble( [CanBeNull] this Object obj )
            => Convert.ToDouble( obj );

        /// <summary>
        ///     Converts the value of the specified object to an double-precision floating-point number, using the specified
        ///     culture-specific formatting information.
        /// </summary>
        /// <exception cref="FormatException">value is not in an appropriate format for a <see cref="Double" /> type.</exception>
        /// <exception cref="InvalidCastException">
        ///     value does not implement the System.IConvertible interface.
        ///     Or the conversion is not supported.
        /// </exception>
        /// <exception cref="OverflowException">
        ///     value represents a number that is less than <see cref="Double.MinValue" /> or greater than
        ///     <see cref="Double.MaxValue" />.
        /// </exception>
        /// <param name="obj">An object that implements the System.IConvertible interface, or null.</param>
        /// <param name="formatProvider">The format provider.</param>
        /// <returns>A double-precision floating-point number that is equivalent to value, or zero if value is null.</returns>
        [Pure]
        [PublicAPI]
        public static Double ToDouble( [CanBeNull] this Object obj, [CanBeNull] IFormatProvider formatProvider )
            => Convert.ToDouble( obj, formatProvider );
    }
}