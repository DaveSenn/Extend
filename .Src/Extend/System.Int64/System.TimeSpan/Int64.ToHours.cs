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
        ///     Returns the given Int64 value as hours.
        /// </summary>
        /// <param name="value">The Int64 value.</param>
        /// <returns>Returns the given Int64 value as hours.</returns>
        public static TimeSpan ToHours( this Int64 value )
        {
            return TimeSpan.FromHours( value );
        }
    }
}