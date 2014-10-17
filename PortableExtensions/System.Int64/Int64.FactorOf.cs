#region Usings

using System;

#endregion

namespace PortableExtensions
{
    /// <summary>
    ///     Class containing some extension methods for <see cref="long" />.
    /// </summary>
    public static partial class Int64Ex
    {
        /// <summary>
        ///     Checks if the Int64 value is a factor of the specified factor number.
        /// </summary>
        /// <param name="value">The Int64 value to check.</param>
        /// <param name="factorNumer">The factor number.</param>
        /// <returns>Returns true if the value is a factor of the specified factor number, otherwise false.</returns>
        public static Boolean FactorOf ( this Int64 value, Int64 factorNumer )
        {
            return factorNumer % value == 0;
        }
    }
}