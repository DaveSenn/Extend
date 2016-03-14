#region Usings

using System;

#endregion

namespace Extend
{
    /// <summary>
    ///     Class containing some extension methods for <see cref="short" />.
    /// </summary>
    public static partial class Int16Ex
    {
        /// <summary>
        ///     Returns whether the given year is a leap year or not.
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>Returns true if the year is a leap year, otherwise false.</returns>
        public static Boolean IsLeapYear( this Int16 year ) => DateTime.IsLeapYear( year );
    }
}