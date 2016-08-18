#region Usings

using System;
using JetBrains.Annotations;

#endregion

namespace Extend
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
        [Pure]
        [PublicAPI]
        public static DateTime LastDayOfWeek( this DateTime week )
            => week.DayOfWeek == DayOfWeek.Sunday
                ? new DateTime( week.Year, week.Month, week.Day )
                : new DateTime( week.Year, week.Month, week.Day ).AddDays( 7 - (Int32) week.DayOfWeek );
    }
}