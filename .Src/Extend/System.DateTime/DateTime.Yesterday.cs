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
        ///     Subtracts a day to the given date dateTime value.
        /// </summary>
        /// <param name="dateTime">The date dateTime to decrease.</param>
        /// <returns>Yesterday date at same dateTime.</returns>
        public static DateTime Yesterday( this DateTime dateTime ) => dateTime.AddDays( -1 );
    }
}