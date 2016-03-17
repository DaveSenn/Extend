#region Usings

using System;

#endregion

namespace Extend
{
    /// <summary>
    ///     Class containing some extension methods for <see cref="TimeSpan" />.
    /// </summary>
    public static partial class TimeSpanEx
    {
        /// <summary>
        ///     Adds the given time span to the current date time.
        /// </summary>
        /// <param name="timeSpan">The time span to add.</param>
        /// <returns>Returns the current date time with the specified time span added to it.</returns>
        public static DateTime Future( this TimeSpan timeSpan ) => DateTime.Now.Add( timeSpan );
    }
}