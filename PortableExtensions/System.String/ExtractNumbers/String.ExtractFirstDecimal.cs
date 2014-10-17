#region Usings

using System;

#endregion

namespace PortableExtensions
{
    public static partial class StringEx
    {
        /// <summary>
        ///     Extracts the first Decimal from the the given string.
        /// </summary>
        /// <exception cref="ArgumentNullException">The value can not be null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Invalid start index.</exception>
        /// <param name="value">The string to extract the decimal from.</param>
        /// <param name="startIndex">The start index of the string.</param>
        /// <returns>The extracted decimal.</returns>
        public static Decimal ExtractFirstDecimal ( this String value, Int32 startIndex = 0 )
        {
            return ExtractFloatingNumber( value, startIndex ).ToDecimal();
        }
    }
}