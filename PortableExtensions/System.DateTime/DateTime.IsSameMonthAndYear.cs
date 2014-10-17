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
        ///     Gets whether the given date-time values are the same month and year.
        /// </summary>
        /// <param name="dateTime">The first date-time value.</param>
        /// <param name="otherDateTime">The second date-time value.</param>
        /// <returns>Returns true if the given date-time values are the same month and year, otherwise false.</returns>
        public static Boolean IsSameMonthAndYear ( this DateTime dateTime, DateTime otherDateTime )
        {
            return dateTime.Year == otherDateTime.Year && dateTime.Month == otherDateTime.Month;
        }
    }
}