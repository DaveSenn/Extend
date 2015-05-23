#region Usings

using System;

#endregion

namespace PortableExtensions
{
    public static partial class StringEx
    {
        /// <summary>
        ///     Compares the given strings using <see cref="StringComparison.OrdinalIgnoreCase" />.
        /// </summary>
        /// <param name="value">The first string to compare.</param>
        /// <param name="compareValue">The second string to compare.</param>
        /// <returns>Returns true if the given strings are equals, otherwise false.</returns>
        public static Boolean CompareOrdinalIgnoreCase( this String value, String compareValue )
        {
            return String.Compare( value, compareValue, StringComparison.OrdinalIgnoreCase ) == 0;
        }
    }
}