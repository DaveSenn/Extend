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
        ///     Checks is the date time value is morning.
        /// </summary>
        /// <param name="dateTime">The date time to check.</param>
        /// <returns>Returns true if the date time is morning, otherwise false.</returns>
        [Pure]
        [PublicAPI]
        public static Boolean IsMorning( this DateTime dateTime )
            => dateTime.TimeOfDay.TotalHours < 12;
    }
}