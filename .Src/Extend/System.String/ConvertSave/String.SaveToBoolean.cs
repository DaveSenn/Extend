#region Usings

using System;
using JetBrains.Annotations;

#endregion

namespace Extend
{
    public static partial class StringEx
    {
        /// <summary>
        ///     Converts the given string to a boolean.
        /// </summary>
        /// <exception cref="ArgumentNullException">The value can not be null.</exception>
        /// <param name="value">The string to convert.</param>
        /// <param name="defaultValue">The default value, returned if the parsing fails.</param>
        /// <returns>The boolean.</returns>
        [Pure]
        [PublicAPI]
        public static Boolean SaveToBoolean( [NotNull] this String value, Boolean? defaultValue = null )
        {
            value.ThrowIfNull( nameof( value ) );

            Boolean outValue;
            return value.TryParsBoolean( out outValue ) ? outValue : ( defaultValue ?? outValue );
        }
    }
}