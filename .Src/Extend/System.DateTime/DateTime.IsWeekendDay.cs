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
        ///     Checks if the given day is a weekend day (Saturday or Sunday).
        /// </summary>
        /// <param name="day">The day to check.</param>
        /// <returns>Returns true if the day is a weekend day, otherwise false.</returns>
        public static Boolean IsWeekendDay( this DateTime day )
        {
            return day.DayOfWeek == DayOfWeek.Saturday || day.DayOfWeek == DayOfWeek.Sunday;
        }
    }
}