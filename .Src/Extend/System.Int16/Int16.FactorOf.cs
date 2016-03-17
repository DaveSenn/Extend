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
        ///     Checks if the Int16 value is a factor of the specified factor number.
        /// </summary>
        /// <param name="value">The Int16 value to check.</param>
        /// <param name="factorNumer">The factor number.</param>
        /// <returns>Returns true if the value is a factor of the specified factor number, otherwise false.</returns>
        public static Boolean FactorOf( this Int16 value, Int16 factorNumer ) => factorNumer % value == 0;
    }
}