#region Usings

using System;

#endregion

namespace Extend
{
    /// <summary>
    ///     Class containing some extension methods for <see cref="short" />.
    /// </summary>
    public static partial class Int32Ex
    {
        /// <summary>
        ///     Returns a date-time representing the specified day in July
        ///     in the specified year.
        /// </summary>
        /// <param name="day">The day.</param>
        /// <param name="year">The year.</param>
        /// <returns>Return a date-time representing the specified day in July in the specified year.</returns>
        public static DateTime July( this Int32 day, Int32 year )
        {
            return new DateTime( year, 7, day );
        }
    }
}