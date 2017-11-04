#region Usings

using System;
using JetBrains.Annotations;

#endregion

namespace Extend
{
    public static partial class StringEx
    {
        /// <summary>
        ///     Converts a string to an enumeration.
        /// </summary>
        /// <exception cref="ArgumentNullException">The value can not be null.</exception>
        /// <typeparam name="T">The type of the enumeration.</typeparam>
        /// <param name="value">The String value to convert.</param>
        /// <param name="ignoreCase">Determines whether or not to ignore the casing of the string.</param>
        /// <returns>Returns the converted enumeration value.</returns>
        [Pure]
        [PublicAPI]
        public static T ToEnum<T>( [NotNull] this String value, Boolean ignoreCase = true ) where T : struct
        {
            value.ThrowIfNull( nameof(value) );

            return (T) Enum.Parse( typeof(T), value, ignoreCase );
        }
    }
}