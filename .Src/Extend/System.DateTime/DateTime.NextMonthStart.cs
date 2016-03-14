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
        ///     Returns the first day of the next month, based on the given date-time value.
        /// </summary>
        /// <param name="dateTime">The date-time value.</param>
        /// <returns>Returns the first day of the next month, based on the given date-time value.</returns>
        public static DateTime NextMonthStart( this DateTime dateTime ) => dateTime.AddMonths( 1 )
                                                                                   .StartOfMonth();
    }
}