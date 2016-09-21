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
        ///     Returns the last moment ("23:59:59:999") of the month represented by the given date time value.
        /// </summary>
        /// <param name="month">The @this to act on.</param>
        /// <returns>Returns the last moment ("23:59:59:999") of the month represented by the given date time value.</returns>
        [Pure]
        [PublicAPI]
        public static DateTime EndOfMonth( this DateTime month )
            => new DateTime( month.Year, month.Month, 1 )
                .AddMonths( 1 )
                .Subtract( 1.ToMilliseconds() );
    }
}