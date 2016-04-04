#region Usings

using System;
using JetBrains.Annotations;

#endregion

namespace Extend
{
    /// <summary>
    ///     Class containing some extension methods for <see cref="string" />.
    /// </summary>
    [PublicAPI]
    public static partial class StringEx
    {
        /// <summary>
        ///     Converts the given string to a boolean.
        /// </summary>
        /// <remarks>
        ///     The framework does not know a culture specific convert method, so does this library.
        /// </remarks>
        /// <exception cref="ArgumentNullException">The value can not be null.</exception>
        /// <exception cref="FormatException">Value is not equal to System.Boolean.TrueString or System.Boolean.FalseString.</exception>
        /// <param name="value">The string to convert.</param>
        /// <returns>Returns the boolean.</returns>
        [Pure]
        [PublicAPI]
        public static Boolean ToBoolean( [NotNull] this String value )
        {
            value.ThrowIfNull( nameof( value ) );

            return Boolean.Parse( value );
        }
    }
}