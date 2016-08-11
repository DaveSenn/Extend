#region Usings

using System;
using JetBrains.Annotations;

#endregion

namespace Extend
{
    /// <summary>
    ///     Class containing some extension methods for <see cref="double" />.
    /// </summary>
    public static partial class DoubleEx
    {
        /// <summary>
        ///     Returns the given Double value as minutes.
        /// </summary>
        /// <param name="value">The Double value.</param>
        /// <returns>Returns the given Double value as minutes.</returns>
        [Pure]
        [PublicAPI]
        public static TimeSpan ToMinutes( this Double value )
            => TimeSpan.FromMinutes( value );
    }
}