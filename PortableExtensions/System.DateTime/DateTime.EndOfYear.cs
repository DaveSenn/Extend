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
        ///     Returns the last moment ("23:59:59:999") of the year represented by the given date time.
        /// </summary>
        /// <param name="year">The year to return the end of.</param>
        /// <returns>Returns the last moment ("23:59:59:999") of the year represented by the given date time.</returns>
        public static DateTime EndOfYear( this DateTime year )
        {
            return new DateTime(year.Year, 12, 31, 23, 59, 59, 999);
        }
    }
}