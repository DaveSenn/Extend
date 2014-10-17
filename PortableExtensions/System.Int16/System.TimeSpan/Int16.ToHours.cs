#region Usings

using System;

#endregion

namespace PortableExtensions
{
    /// <summary>
    ///     Class containing some extension methods for <see cref="short" />.
    /// </summary>
    public static partial class Int16Ex
    {
        /// <summary>
        ///     Returns the given Int16 value as hours.
        /// </summary>
        /// <param name="value">The Int16 value.</param>
        /// <returns>Returns the given Int16 value as hours.</returns>
        public static TimeSpan ToHours ( this Int16 value )
        {
            return TimeSpan.FromHours( value );
        }
    }
}