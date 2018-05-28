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
        ///     Returns the last moment of the day ("23:59:59:999") represented by the given date time value.
        /// </summary>
        /// <param name="day">The day to get the end of.</param>
        /// <returns>Returns the last moment of the day ("23:59:59:999") represented by the given date time value.</returns>
        [Pure]
        [PublicAPI]
        public static DateTime EndOfDay( this DateTime day )
            => day
               .Date.AddDays( 1 )
               .Subtract( 1.ToMilliseconds() );
    }
}