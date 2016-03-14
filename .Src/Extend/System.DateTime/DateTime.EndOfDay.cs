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
        ///     Returns the last moment of the day ("23:59:59:999") represented by the given date time value.
        /// </summary>
        /// <param name="day">The day to get the end of.</param>
        /// <returns>Returns the last moment of the day ("23:59:59:999") represented by the given date time value.</returns>
        public static DateTime EndOfDay( this DateTime day ) => new DateTime( day.Year, day.Month, day.Day ).AddDays( 1 )
                                                                                                            .Subtract( 1.ToMilliseconds() );
    }
}