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
        ///     Checks if the given day is a week day (MOnday - Friday).
        /// </summary>
        /// <param name="day">The day to check.</param>
        /// <returns>Returns true if the day is a week day, otherwise false.</returns>
        public static Boolean IsWeekdDay( this DateTime day ) => day.DayOfWeek != DayOfWeek.Saturday && day.DayOfWeek != DayOfWeek.Sunday;
    }
}