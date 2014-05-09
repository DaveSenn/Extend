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
        ///     Subtracts a day to the given date time value.
        /// </summary>
        /// <param name="dateTime">The date time to decrease.</param>
        /// <returns>Yesterday date at same time.</returns>
        public static DateTime Yesterday( this DateTime dateTime )
        {
            return dateTime.AddDays( -1 );
        }
    }
}