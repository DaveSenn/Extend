#region Usings

using System;
using JetBrains.Annotations;

#endregion

namespace Extend
{
    public static partial class StringEx
    {
        /// <summary>
        ///     Compares the given strings using <see cref="StringComparison.OrdinalIgnoreCase" />.
        /// </summary>
        /// <param name="value">The first string to compare.</param>
        /// <param name="compareValue">The second string to compare.</param>
        /// <returns>Returns true if the given strings are equals, otherwise false.</returns>
        [Pure]
        [PublicAPI]
        public static Boolean CompareOrdinalIgnoreCase( [CanBeNull] this String value, [CanBeNull] String compareValue )
            => String.Compare( value, compareValue, StringComparison.OrdinalIgnoreCase ) == 0;
    }
}