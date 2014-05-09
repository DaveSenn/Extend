#region Using

using System;

#endregion

namespace PortableExtensions
{
    /// <summary>
    ///     Class containing some extension methods for <see cref="short" />.
    /// </summary>
    public static partial class Int16Ex
    {
        /// <summary>
        ///     Checks if the Int16 is odd.
        /// </summary>
        /// <param name="value">The Int16 to check.</param>
        /// <returns>Returns true if the Int16 is odd, otherwise false.</returns>
        public static Boolean IsOdd( this Int16 value )
        {
            return value % 2 != 0;
        }
    }
}