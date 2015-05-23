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
        ///     Calculates the difference between the year of the current and the given date time.
        /// </summary>
        /// <remarks>
        ///     <paramref name="now" /> can be smaller than <paramref name="dateTime" />, which results in negative results.
        ///     Source from: http://stackoverflow.com/questions/9/how-do-i-calculate-someones-age-in-c
        /// </remarks>
        /// <param name="dateTime">The date time value.</param>
        /// <param name="now">The 'current' date used to calculate the age, or null tu use <see cref="DateTime.Now" />.</param>
        /// <returns>The difference between the year of the current and the given date time.</returns>
        public static Int32 Age( this DateTime dateTime, DateTime? now = null )
        {
            var currentDate = now ?? DateTime.Now;
            if ( dateTime.Year == currentDate.Year )
                return 0;

            var a = ( currentDate.Year * 100 + currentDate.Month ) * 100 + currentDate.Day;
            var b = ( dateTime.Year * 100 + dateTime.Month ) * 100 + dateTime.Day;

            return ( a - b ) / 10000;
        }
    }
}