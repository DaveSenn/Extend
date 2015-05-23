#region Usings

using System;

#endregion

namespace Extend
{
    /// <summary>
    ///     Class containing some extension methods for <see cref="short" />.
    /// </summary>
    public static partial class Int16Ex
    {
        /// <summary>
        ///     Checks if the Int16 value is a multiple of the given factor.
        /// </summary>
        /// <param name="value">The Int16 to check.</param>
        /// <param name="factor">The factor.</param>
        /// <returns>>Returns true if the Int16 value is a multiple of the given factor.</returns>
        public static Boolean IsMultipleOf( this Int16 value, Int16 factor )
        {
            return value % factor == 0;
        }
    }
}