#region Usings

using System;
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
        ///     Returns the start of the given month (with time set to "00:00:00:000").
        /// </summary>
        /// <param name="month">The month to get the start of.</param>
        /// <returns>Returns the start of the given month (with time set to "00:00:00:000").</returns>
        [Pure]
        [PublicAPI]
        public static DateTime StartOfMonth( this DateTime month )
            => new DateTime( month.Year, month.Month, 1 );
    }
}