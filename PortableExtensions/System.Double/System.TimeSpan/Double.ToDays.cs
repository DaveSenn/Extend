#region Usings

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
        ///     Returns the given Double value as day.
        /// </summary>
        /// <param name="value">The Double value.</param>
        /// <returns>Returns the given Double value as days.</returns>
        public static TimeSpan ToDays ( this Double value )
        {
            return TimeSpan.FromDays( value );
        }
    }
}