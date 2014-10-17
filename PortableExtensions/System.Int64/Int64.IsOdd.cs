#region Usings

using System;

#endregion

namespace PortableExtensions
{
    /// <summary>
    ///     Class containing some extension methods for <see cref="int" />.
    /// </summary>
    public static partial class Int64Ex
    {
        /// <summary>
        ///     Checks if the Int64 is odd.
        /// </summary>
        /// <param name="value">The Int64 to check.</param>
        /// <returns>Returns true if the Int64 is odd, otherwise false.</returns>
        public static Boolean IsOdd ( this Int64 value )
        {
            return value % 2 != 0;
        }
    }
}