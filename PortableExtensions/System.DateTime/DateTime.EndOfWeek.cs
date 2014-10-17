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
        ///     Returns the last day of the current week.
        ///     Note: This method uses the given day as last day of the week.
        ///     Default is Sunday.
        /// </summary>
        /// <param name="week">The week to return the end of.</param>
        /// <param name="lastDayOfWeek">The last day of the week. Default is Sunday.</param>
        /// <returns>Returns the last day of the current week.</returns>
        public static DateTime EndOfWeek ( this DateTime week, DayOfWeek lastDayOfWeek = DayOfWeek.Sunday )
        {
            var currentDay = week.DayOfWeek;
            var daysLeft = lastDayOfWeek - currentDay;

            if ( daysLeft < 0 )
                daysLeft += 7;

            var endOfWeek = week.AddDays( daysLeft );

            return
                new DateTime( endOfWeek.Year, endOfWeek.Month, endOfWeek.Day ).AddDays( 1 )
                                                                              .Subtract( 1.ToMilliseconds() );
        }
    }
}