#region Usings

using System;

#endregion

namespace PortableExtensions
{
    /// <summary>
    ///     Class containing some extension methods for <see cref="Random" />.
    /// </summary>
    public static partial class RandomEx
    {
        /// <summary>
        ///     Returns randomly true or false.
        /// </summary>
        /// <exception cref="ArgumentNullException">The random can not be null.</exception>
        /// <param name="random">The random to use.</param>
        /// <returns>Returns true or false (random value).</returns>
        public static Boolean CoinToss ( this Random random )
        {
            random.ThrowIfNull( () => random );

            return random.Next( 2 ) == 0;
        }
    }
}