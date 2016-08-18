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
        ///     Checks whether the given date time value is at afternoon or not.
        /// </summary>
        /// <param name="dateTime">The date time to check.</param>
        /// <returns>Returns true if the date time value is at afternoon, otherwise false.</returns>
        [Pure]
        [PublicAPI]
        public static Boolean IsAfternoon( this DateTime dateTime )
            => dateTime.TimeOfDay.TotalHours >= 12;
    }
}