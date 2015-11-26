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
        ///     Gets a value indicating whether the given date-time value is the last day of the month represented in
        ///     <paramref name="dateTime" />.
        /// </summary>
        /// <param name="dateTime">The date-time value.</param>
        /// <returns>Returns a value of true if the given date-time value is the last day of the month.</returns>
        public static Boolean IsLastDayOfMonth( this DateTime dateTime )
        {
            return DateTime.DaysInMonth( dateTime.Year, dateTime.Month ) == dateTime.Day;
        }
    }
}