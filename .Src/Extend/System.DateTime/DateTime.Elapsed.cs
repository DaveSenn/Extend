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
        ///     Calculates the elapsed time between the given date time value and DateTime.Now.
        /// </summary>
        /// <param name="dateTime">The date time value.</param>
        /// <returns>Returns the elapsed time between the given date time value and DateTime.Now.</returns>
        [Pure]
        [PublicAPI]
        public static TimeSpan Elapsed( this DateTime dateTime )
            => DateTime.Now - dateTime;
    }
}