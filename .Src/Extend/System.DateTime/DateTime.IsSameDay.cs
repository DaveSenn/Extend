#region Usings

using System;

#endregion

namespace Extend
{
    /// <summary>
    ///     Class containing some extension methods for <see cref="DateTime" />.
    /// </summary>
    public static partial class DateTimeEx
    {
        /// <summary>
        ///     Gets whether the given date-time values are the same day.
        /// </summary>
        /// <param name="dateTime">The first date-time value.</param>
        /// <param name="otherDateTime">The second date-time value.</param>
        /// <returns>Returns true if the given date-time values are the same day, otherwise false.</returns>
        public static Boolean IsSameDay( this DateTime dateTime, DateTime otherDateTime )
        {
            return dateTime.Date == otherDateTime.Date;
        }
    }
}