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
        ///     Returns the last day of the given week.
        /// </summary>
        /// <param name="week">The week to get the last day of.</param>
        /// <returns>Returns the last day of the given week.</returns>
        public static DateTime LastDayOfWeek ( this DateTime week )
        {
            return week.DayOfWeek == DayOfWeek.Sunday
                ? new DateTime( week.Year, week.Month, week.Day )
                : new DateTime( week.Year, week.Month, week.Day ).AddDays( 7 - (Int32) week.DayOfWeek );
        }
    }
}