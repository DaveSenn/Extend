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
        ///     Converts the value of the specified object to a System.DateTime object.
        /// </summary>
        /// <exception cref="FormatException">value is not a valid date and time value.</exception>
        /// <exception cref="InvalidCastException">
        ///     value does not implement the System.IConvertible interface.
        ///     Or the conversion is not supported.
        /// </exception>
        /// <param name="obj">An object that implements the System.IConvertible interface, or null.</param>
        /// <returns>
        ///     The date and time equivalent of the value of value, or a date and time equivalent of
        ///     <see cref="DateTime.MinValue" />
        ///     if value is null.
        /// </returns>
        [Pure]
        [PublicAPI]
        public static DateTime ToDateTime( [CanBeNull] this Object obj )
            => Convert.ToDateTime( obj );

        /// <summary>
        ///     Converts the value of the specified object to a System.DateTime object, using the specified culture-specific
        ///     formatting information.
        /// </summary>
        /// <exception cref="FormatException">value is not a valid date and time value.</exception>
        /// <exception cref="InvalidCastException">
        ///     value does not implement the System.IConvertible interface.
        ///     Or the conversion is not supported.
        /// </exception>
        /// <param name="obj">An object that implements the System.IConvertible interface, or null.</param>
        /// <param name="formatProvider">The format provider.</param>
        /// <returns>
        ///     The date and time equivalent of the value of value, or a date and time equivalent of
        ///     <see cref="DateTime.MinValue" />
        ///     if value is null.
        /// </returns>
        [Pure]
        [PublicAPI]
        public static DateTime ToDateTime( [CanBeNull] this Object obj, [CanBeNull] IFormatProvider formatProvider )
            => Convert.ToDateTime( obj, formatProvider );
    }
}