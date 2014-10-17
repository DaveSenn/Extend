#region Usings

using System;

#endregion

namespace PortableExtensions
{
    /// <summary>
    ///     Class containing some extension methods for <see cref="DateTime" />.
    /// </summary>
    public static partial class DateTimeEx
    {
        /// <summary>
        ///     Checks if the time is equals to the given time.
        /// </summary>
        /// <param name="time">The time to check.</param>
        /// <param name="timeToCompare">The time to compare.</param>
        /// <returns>Returns true if the time is equals, otherwise false.</returns>
        public static Boolean IsTimeEquals ( this DateTime time, DateTime timeToCompare )
        {
            return time.TimeOfDay == timeToCompare.TimeOfDay;
        }
    }
}