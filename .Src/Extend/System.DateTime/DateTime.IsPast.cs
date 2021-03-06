﻿#region Usings

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
        ///     Checks if the date time value is in the past.
        /// </summary>
        /// <param name="dateTime">The date time to check.</param>
        /// <returns>Returns true if the value is in the past, otherwise false.</returns>
        [Pure]
        [PublicAPI]
        public static Boolean IsPast( this DateTime dateTime )
            => dateTime < DateTime.Now;
    }
}