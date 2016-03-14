﻿#region Usings

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
        ///     Returns the start of the given day ("00:00:00:000").
        /// </summary>
        /// <param name="day">The day to get the start of.</param>
        /// <returns>Returns the start of the given day ("00:00:00:000").</returns>
        public static DateTime StartOfDay( this DateTime day ) => new DateTime( day.Year, day.Month, day.Day );
    }
}