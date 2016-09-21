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
        ///     Returns the start of the given year with time set to "00:00:00:000".
        /// </summary>
        /// <param name="year">The year to get the start of.</param>
        /// <returns>Returns the start of the given year with time set to "00:00:00:000".</returns>
        [Pure]
        [PublicAPI]
        public static DateTime StartOfYear( this DateTime year )
            => new DateTime( year.Year, 1, 1 );
    }
}