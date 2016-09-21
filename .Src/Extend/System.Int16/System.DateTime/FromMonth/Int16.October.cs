#region Usings

using System;
using JetBrains.Annotations;

#endregion

namespace Extend
{
    /// <summary>
    ///     Class containing some extension methods for <see cref="short" />.
    /// </summary>
    public static partial class Int16Ex
    {
        /// <summary>
        ///     Returns a date-time representing the specified day in October
        ///     in the specified year.
        /// </summary>
        /// <param name="day">The day.</param>
        /// <param name="year">The year.</param>
        /// <returns>Return a date-time representing the specified day in October in the specified year.</returns>
        [Pure]
        [PublicAPI]
        public static DateTime October( this Int16 day, Int16 year )
            => new DateTime( year, 10, day );
    }
}