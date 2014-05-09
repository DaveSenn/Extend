#region Using

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
        ///     Returns the given Int32 value as minutes.
        /// </summary>
        /// <param name="value">The Int32 value.</param>
        /// <returns>Returns the given Int32 value as minutes.</returns>
        public static TimeSpan ToMinutes( this Int32 value )
        {
            return TimeSpan.FromMinutes( value );
        }
    }
}