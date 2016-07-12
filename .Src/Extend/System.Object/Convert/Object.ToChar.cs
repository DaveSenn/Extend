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
        ///     Converts the value of the specified object to a Unicode character.
        /// </summary>
        /// <exception cref="ArgumentNullException">value is a null <see cref="String" />.</exception>
        /// <exception cref="InvalidCastException">
        ///     value does not implement the System.IConvertible interface.
        ///     Or the conversion of value to a <see cref="Char" /> is not supported.
        /// </exception>
        /// <exception cref="OverflowException">
        ///     value is less than <see cref="Char.MinValue" /> or greater than <see cref="Char.MaxValue" />.
        /// </exception>
        /// <param name="obj">An object that implements the System.IConvertible interface.</param>
        /// <returns>
        ///     A Unicode character that is equivalent to value, or <see cref="Char.MinValue" /> if value is null.
        /// </returns>
        [Pure]
        [PublicAPI]
        public static Char ToChar( [CanBeNull] this Object obj )
            => Convert.ToChar( obj );

        /// <summary>
        ///     Converts the value of the specified object to its equivalent Unicode character, using the specified
        ///     culture-specific formatting information.
        /// </summary>
        /// <exception cref="ArgumentNullException">value is a null <see cref="String" />.</exception>
        /// <exception cref="InvalidCastException">
        ///     value does not implement the System.IConvertible interface.
        ///     Or the conversion of value to a <see cref="Char" /> is not supported.
        /// </exception>
        /// <exception cref="OverflowException">
        ///     value is less than <see cref="Char.MinValue" /> or greater than <see cref="Char.MaxValue" />.
        /// </exception>
        /// <param name="obj">An object that implements the System.IConvertible interface.</param>
        /// <param name="provider">A format provider.</param>
        /// <returns>
        ///     A Unicode character that is equivalent to value, or <see cref="Char.MinValue" /> if value is null.
        /// </returns>
        [Pure]
        [PublicAPI]
        public static Char ToChar( [CanBeNull] this Object obj, IFormatProvider provider )
            => Convert.ToChar( obj, provider );
    }
}