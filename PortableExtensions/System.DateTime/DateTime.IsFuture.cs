#region Usings

using System;

#endregion

namespace PortableExtensions
{
    /// <summary>
    ///     Class containing some extension methods for <see cref="DateTime" />.
    /// </summary>
    public static partial class DateTimeEx
    {
        /// <summary>
        ///     Checks if the date time value is in the future.
        /// </summary>
        /// <param name="dateTime">The @date time to check.</param>
        /// <returns>Returns true if the value is in the future, otherwise false.</returns>
        public static Boolean IsFuture( this DateTime dateTime )
        {
            return dateTime > DateTime.Now;
        }
    }
}