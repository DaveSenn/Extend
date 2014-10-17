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
        ///     Returns the given Int64 value as day.
        /// </summary>
        /// <param name="value">The Int64 value.</param>
        /// <returns>Returns the given Int64 value as days.</returns>
        public static TimeSpan ToDays ( this Int64 value )
        {
            return TimeSpan.FromDays( value );
        }
    }
}