#region Usings

using System;

#endregion

namespace Extend
{
    /// <summary>
    ///     Class containing some extension methods for <see cref="int" />.
    /// </summary>
    public static partial class Int32Ex
    {
        /// <summary>
        ///     Returns whether the given year is a leap year or not.
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>Returns true if the year is a leap year, otherwise false.</returns>
        public static Boolean IsLeapYear( this Int32 year )
        {
            return DateTime.IsLeapYear( year );
        }
    }
}