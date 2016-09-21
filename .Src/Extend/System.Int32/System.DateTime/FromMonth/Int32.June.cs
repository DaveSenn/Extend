#region Usings

using System;
using JetBrains.Annotations;

#endregion

namespace Extend
{
    /// <summary>
    ///     Class containing some extension methods for <see cref="short" />.
    /// </summary>
    public static partial class Int32Ex
    {
        /// <summary>
        ///     Returns a date-time representing the specified day in June
        ///     in the specified year.
        /// </summary>
        /// <param name="day">The day.</param>
        /// <param name="year">The year.</param>
        /// <returns>Return a date-time representing the specified day in June in the specified year.</returns>
        [Pure]
        [PublicAPI]
        public static DateTime June( this Int32 day, Int32 year )
            => new DateTime( year, 6, day );
    }
}