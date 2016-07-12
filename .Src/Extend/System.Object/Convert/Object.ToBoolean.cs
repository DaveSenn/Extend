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
        ///     Converts the value of a specified object to an equivalent Boolean value.
        /// </summary>
        /// <exception cref="FormatException">
        ///     value is a string that does not equal <see cref="System.Boolean.TrueString" /> or
        ///     <see cref="System.Boolean.FalseString" />.
        /// </exception>
        /// <exception cref="InvalidCastException">
        ///     value does not implement the IConvertible interface.
        ///     The conversion of value to a <see cref="System.Boolean" /> is not supported.
        /// </exception>
        /// <param name="obj">An object that implements the System.IConvertible interface, or null..</param>
        /// <returns>
        ///     true or false, which reflects the value returned by invoking the
        ///     System.IConvertible.ToBoolean(System.IFormatProvider) method for the underlying type of value.
        ///     If value is null, the method returns false.
        /// </returns>
        [PublicAPI]
        [Pure]
        public static Boolean ToBoolean( [CanBeNull] this Object obj )
            => Convert.ToBoolean( obj );

        /// <summary>
        ///     Converts the value of the specified object to an equivalent Boolean value, using the specified culture-specific
        ///     formatting information.
        /// </summary>
        /// <exception cref="FormatException">
        ///     value is a string that does not equal <see cref="System.Boolean.TrueString" /> or
        ///     <see cref="System.Boolean.FalseString" />.
        /// </exception>
        /// <exception cref="InvalidCastException">
        ///     value does not implement the IConvertible interface.
        ///     The conversion of value to a <see cref="System.Boolean" /> is not supported.
        /// </exception>
        /// <param name="obj">An object that implements the System.IConvertible interface, or null.</param>
        /// <param name="formatProvider">The format provider.</param>
        /// <returns>
        ///     true or false, which reflects the value returned by invoking the
        ///     System.IConvertible.ToBoolean(System.IFormatProvider) method for the underlying type of value.
        ///     If value is null, the method returns false.
        /// </returns>
        [PublicAPI]
        [Pure]
        public static Boolean ToBoolean( [CanBeNull] this Object obj, IFormatProvider formatProvider )
            => Convert.ToBoolean( obj, formatProvider );
    }
}