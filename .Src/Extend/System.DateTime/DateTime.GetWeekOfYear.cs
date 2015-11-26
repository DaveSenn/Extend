#region Usings

using System;
using System.Globalization;

#endregion

namespace Extend
{
    /// <summary>
    ///     Class containing some extension methods for <see cref="DateTime" />.
    /// </summary>
    public static partial class DateTimeEx
    {
        /// <summary>
        ///     Gets the week-number of the given date-time value.
        /// </summary>
        /// <remarks>
        ///     This implementation is ISO 8601 compatible see: https://en.wikipedia.org/wiki/ISO_8601.
        ///     For .Net details see: http://stackoverflow.com/questions/11154673/get-the-correct-week-number-of-a-given-date
        ///     This presumes that weeks start with Monday.
        ///     Week 1 is the 1st week of the year with a Thursday in it.
        /// </remarks>
        /// <param name="dateTime">The date-time value.</param>
        /// <returns>Returns the number of the given week.</returns>
        public static Int32 GetWeekOfYear( this DateTime dateTime )
        {
            // Seriously cheat.  If its Monday, Tuesday or Wednesday, then it'll 
            // be the same week# as whatever Thursday, Friday or Saturday are,
            // and we always get those right
            var day = CultureInfo.InvariantCulture.Calendar.GetDayOfWeek( dateTime );
            if ( day >= DayOfWeek.Monday && day <= DayOfWeek.Wednesday )
                dateTime = dateTime.AddDays( 3 );

            // Return the week of our adjusted day
            return CultureInfo.InvariantCulture.Calendar.GetWeekOfYear( dateTime, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday );
        }
    }
}