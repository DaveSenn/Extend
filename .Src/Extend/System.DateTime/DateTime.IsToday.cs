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
        ///     Checks if the given date time is today.
        /// </summary>
        /// <param name="dateTime">The date time to check.</param>
        /// <returns>Returns true if the date time value is today, otherwise false.</returns>
        public static Boolean IsToday( this DateTime dateTime ) => dateTime.Date == DateTime.Today;
    }
}