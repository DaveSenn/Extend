#region Usings

using System;
using JetBrains.Annotations;

#endregion

namespace Extend
{
    public static partial class StringEx
    {
        /// <summary>
        ///     Converts the given string to a GUID.
        /// </summary>
        /// <exception cref="ArgumentNullException">The value can not be null.</exception>
        /// <param name="value">The string to convert.</param>
        /// <param name="defaultValue">
        ///     The default value, returned if the parsing fails. If not provided default will be
        ///     <see cref="Guid.Empty" />.
        /// </param>
        /// <returns>Returns the converted GUID.</returns>
        [Pure]
        [PublicAPI]
        public static Guid SaveToGuid( [NotNull] this String value, Guid? defaultValue = null )
        {
            value.ThrowIfNull( nameof( value ) );

            Guid outValue;
            return value.TryParsGuid( out outValue ) ? outValue : ( defaultValue ?? outValue );
        }
    }
}