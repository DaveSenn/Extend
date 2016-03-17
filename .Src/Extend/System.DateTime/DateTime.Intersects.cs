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
        ///     Checks if the two date ranges intersects.
        /// </summary>
        /// <param name="startDate">The start date.</param>
        /// <param name="endDate">The end date.</param>
        /// <param name="intersectingStartDate">The intersecting start date.</param>
        /// <param name="intersectingEndDate">The intersecting end date.</param>
        /// <returns>Returns true if the two date ranges intersects, otherwise false.</returns>
        public static Boolean Intersects( this DateTime startDate,
                                          DateTime endDate,
                                          DateTime intersectingStartDate,
                                          DateTime intersectingEndDate ) => intersectingEndDate >= startDate && intersectingStartDate <= endDate;
    }
}