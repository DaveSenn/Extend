#region Using

using System;

#endregion

namespace PortableExtensions
{
    /// <summary>
    ///     Class containing some extension methods for <see cref="int" />.
    /// </summary>
    public static partial class Int32Ex
    {
        /// <summary>
        ///     Returns the number of days in the specified month of the specified year.
        /// </summary>
        /// <param name="year">The year.</param>
        /// <param name="month">The month.</param>
        /// <returns>
        ///     Returns the number of days of the specified month.
        ///     For example February (2), the return value is 28 or 29 depending upon whether is a leap year.
        /// </returns>
        public static Int32 DaysInMonth( this Int32 year, Int32 month )
        {
            return DateTime.DaysInMonth( year, month );
        }
    }
}