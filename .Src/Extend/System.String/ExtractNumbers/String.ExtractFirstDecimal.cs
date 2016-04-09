#region Usings

using System;
using JetBrains.Annotations;

#endregion

namespace Extend
{
    public static partial class StringEx
    {
        /// <summary>
        ///     Extracts the first Decimal from the given string.
        /// </summary>
        /// <exception cref="ArgumentNullException">The value can not be null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Invalid start index.</exception>
        /// <param name="value">The string to extract the decimal from.</param>
        /// <param name="startIndex">The start index of the string.</param>
        /// <returns>The extracted decimal.</returns>
        [Pure]
        [PublicAPI]
        public static Decimal ExtractFirstDecimal( [NotNull] this String value, Int32 startIndex = 0 )
            => ExtractFloatingNumber( value, startIndex )
                .ToDecimal();
    }
}