#region Usings

using System;
using JetBrains.Annotations;

#endregion

namespace Extend
{
    /// <summary>
    ///     Class containing some extension methods for <see cref="Random" />.
    /// </summary>
    public static partial class RandomEx
    {
        /// <summary>
        ///     Returns randomly true or false.
        /// </summary>
        /// <exception cref="ArgumentNullException">random can not be null.</exception>
        /// <param name="random">The random to use.</param>
        /// <returns>Returns true or false (random value).</returns>
        [Pure]
        [PublicAPI]
        public static Boolean CoinToss( [NotNull] this Random random )
        {
            random.ThrowIfNull( nameof(random) );

            return random.Next( 2 ) == 0;
        }
    }
}