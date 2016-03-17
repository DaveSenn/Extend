#region Usings

using System;

#endregion

namespace Extend
{
    public static partial class StringEx
    {
        /// <summary>
        ///     Compares the given strings using <see cref="StringComparison.Ordinal" />.
        /// </summary>
        /// <param name="value">The first string to compare.</param>
        /// <param name="compareValue">The second string to compare.</param>
        /// <returns>Returns true if the given strings are equals, otherwise false.</returns>
        public static Boolean CompareOrdinal( this String value, String compareValue ) => String.Compare( value, compareValue, StringComparison.Ordinal ) == 0;
    }
}