#region Usings

using System;
using System.Linq;
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
        /// Returns the date in year month ordinal format
        /// </summary>
        [Pure]
        [PublicAPI]
		public static string ToOrdinalMonthYear(this DateTime date)
        {
            string suffix;
            if (new[] { 11, 12, 13 }.Contains(date.Day))
            {
                suffix = "th";
            }
            else if (date.Day % 10 == 1)
            {
                suffix = "st";
            }
            else if (date.Day % 10 == 2)
            {
                suffix = "nd";
            }
            else if (date.Day % 10 == 3)
            {
                suffix = "rd";
            }
            else
            {
                suffix = "th";
            }
            return string.Format("{0:MMMM} {1}{2}, {0:yyyy}", date, date.Day, suffix);
        }
    }
}