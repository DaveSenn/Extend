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
        ///     Gets the next week day, based on the given day.
        /// </summary>
        /// <param name="day">The day.</param>
        /// <returns>Returns the next week day (can be <paramref name="day" /> if the given day is a week day).</returns>
        public static DateTime NextWeekDay ( this DateTime day )
        {
            while ( day.IsWeekendDay() )
                day = day.Add( 1.ToDays() );
            return day;
        }
    }
}