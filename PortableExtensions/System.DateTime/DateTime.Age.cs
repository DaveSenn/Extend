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
        /// <param name="dateTime">The date time value.</param>
        /// <returns>The difference between the year of the current and the given date time.</returns>
        public static Int32 Age( this DateTime dateTime )
        {
            if ( DateTime.Today.Month < dateTime.Month
                 || DateTime.Today.Month == dateTime.Month && DateTime.Today.Day < dateTime.Day )
                return DateTime.Today.Year - dateTime.Year - 1;

            return DateTime.Today.Year - dateTime.Year;
        }
    }
}