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
        ///     Returns the first day of the current week.
        ///     Note: This method uses the given day as first day of the week.
        ///     Default is Monday.
        /// </summary>
        /// <param name="week">The week to return the start of.</param>
        /// <param name="firstDayOfWeek">The first day of the week. Default is Monday.</param>
        /// <returns>Returns the first day of the current week.</returns>
        public static DateTime StartOfWeek( this DateTime week, DayOfWeek firstDayOfWeek = DayOfWeek.Monday )
        {
            var currentDay = week.DayOfWeek;
            var daysPassed = currentDay - firstDayOfWeek;

            if ( daysPassed < 0 )
                daysPassed += 7;

            var startOfWeek = week.AddDays( -daysPassed );

            return new DateTime( startOfWeek.Year, startOfWeek.Month, startOfWeek.Day );
        }
    }
}