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
        ///     Returns the start of the given month (with time set to "00:00:00:000").
        /// </summary>
        /// <param name="month">The month to get the start of.</param>
        /// <returns>Returns the start of the given month (with time set to "00:00:00:000").</returns>
        public static DateTime StartOfMonth ( this DateTime month )
        {
            return new DateTime( month.Year, month.Month, 1 );
        }
    }
}