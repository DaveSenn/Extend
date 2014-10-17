#region Usings

using System;

#endregion

namespace PortableExtensions
{
    /// <summary>
    ///     Class containing some extension methods for <see cref="int" />.
    /// </summary>
    public static partial class Int32Ex
    {
        /// <summary>
        ///     Checks if the Int32 value is a factor of the specified factor number.
        /// </summary>
        /// <param name="value">The Int32 value to check.</param>
        /// <param name="factorNumer">The factor number.</param>
        /// <returns>Returns true if the value is a factor of the specified factor number, otherwise false.</returns>
        public static Boolean FactorOf ( this Int32 value, Int32 factorNumer )
        {
            return factorNumer % value == 0;
        }
    }
}