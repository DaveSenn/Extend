#region Usings

using System;

#endregion

namespace Extend
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
        public static Boolean IsOdd( this Int64 value ) => value % 2 != 0;
    }
}