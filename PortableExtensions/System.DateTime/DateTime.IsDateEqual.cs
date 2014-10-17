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
        ///     Checks if the date is equals to the given date.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <param name="dateToCompare">Date to compare.</param>
        /// <returns>Returns true if the date is equals to the given date, otherwise false.</returns>
        public static Boolean IsDateEqual ( this DateTime date, DateTime dateToCompare )
        {
            return date.Date == dateToCompare.Date;
        }
    }
}