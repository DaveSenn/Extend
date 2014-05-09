#region Using

using System;

#endregion

namespace PortableExtensions
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
        public static TimeSpan ToMinutes( this Double value )
        {
            return TimeSpan.FromMinutes( value );
        }
    }
}