#region Using

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
        ///     Calculates the difference between the year of the current and the given date time.
        /// </summary>
        /// <remarks>
        /// <paramref name="now"/> can be samller than <paramref name="dateTime"/>, which results in negative results.
        /// </remarks>
        /// <param name="dateTime">The date time value.</param>
        /// <param name="now">The 'current' date used to caluculate the age, or null tu use <see cref="DateTime.Now" />.</param>
        /// <returns>The difference between the year of the current and the given date time.</returns>
        public static Int32 Age(this DateTime dateTime, DateTime? now = null)
        {
            var currentDate = now ?? DateTime.Now;

            if (dateTime.Year == currentDate.Year)
                return 0;

            var age = currentDate.Year - dateTime.Year;

            if (dateTime > currentDate && (currentDate.Month > dateTime.Month || currentDate.Day > dateTime.Day))
                age++;
            else if ((currentDate.Month < dateTime.Month || (currentDate.Month == dateTime.Month && currentDate.Day < dateTime.Day)))
                age--;

            return age;
        }
    }
}