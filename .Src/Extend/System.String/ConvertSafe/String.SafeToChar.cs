#region Usings

using System;
using JetBrains.Annotations;

#endregion

namespace Extend
{
    public static partial class StringEx
    {
        /// <summary>
        ///     Converts the value of the specified string to its equivalent Unicode character.
        /// </summary>
        /// <param name="value">A string that contains a single character.</param>
        /// <param name="defaultValue">The default value, returned if the parsing fails.</param>
        /// <returns>Returns the converted value, or the given default value if the conversion failed.</returns>
        [Pure]
        [PublicAPI]
        public static Char SafeToChar( [CanBeNull] this String value, Char defaultValue = default(Char) )
            => value.TryParsChar( out var outValue ) ? outValue : defaultValue;
    }
}