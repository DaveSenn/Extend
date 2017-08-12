#region Usings

using System;
using JetBrains.Annotations;

#endregion

namespace Extend
{
    public static partial class StringEx
    {
        /// <summary>
        ///     Tries to convert the specified string representation of a logical value to
        ///     its <see cref="Boolean" /> equivalent.
        /// </summary>
        /// <param name="value">A string containing the value to convert.</param>
        /// <param name="defaultValue">The default value, returned if the conversion fails.</param>
        /// <returns>Returns the converted value, or the given default value if the conversion failed.</returns>
        [Pure]
        [PublicAPI]
        public static Boolean SaveToBoolean( [CanBeNull] this String value, Boolean defaultValue = default(Boolean) ) 
            => value.TryParsBoolean(out Boolean outValue) ? outValue : defaultValue;
    }
}