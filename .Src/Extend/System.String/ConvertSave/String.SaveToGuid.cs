#region Usings

using System;
using JetBrains.Annotations;

#endregion

namespace Extend
{
    public static partial class StringEx
    {
        /// <summary>
        ///     Converts the string representation of a GUID to the equivalent <see cref="Guid" /> structure.
        /// </summary>
        /// <param name="value">The string to convert.</param>
        /// <param name="defaultValue">
        ///     The default value, returned if the parsing fails. If not provided default will be
        ///     <see cref="Guid.Empty" />.
        /// </param>
        /// <returns>Returns the converted value, or the given default value if the conversion failed.</returns>
        [Pure]
        [PublicAPI]
        public static Guid SaveToGuid( [CanBeNull] this String value, Guid defaultValue = default(Guid) )
            => value.TryParsGuid( out Guid outValue ) ? outValue : defaultValue;
    }
}