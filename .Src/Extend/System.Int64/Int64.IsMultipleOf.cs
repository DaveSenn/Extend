#region Usings

using System;

#endregion

namespace Extend
{
    /// <summary>
    ///     Class containing some extension methods for <see cref="long" />.
    /// </summary>
    public static partial class Int64Ex
    {
        /// <summary>
        ///     Checks if the Int64 value is a multiple of the given factor.
        /// </summary>
        /// <param name="value">The Int64 to check.</param>
        /// <param name="factor">The factor.</param>
        /// <returns>>Returns true if the Int64 value is a multiple of the given factor.</returns>
        public static Boolean IsMultipleOf( this Int64 value, Int64 factor ) => value % factor == 0;
    }
}