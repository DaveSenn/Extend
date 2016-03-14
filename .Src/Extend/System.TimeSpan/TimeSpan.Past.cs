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
        ///     Subtracts the specified time span to the current date time.
        /// </summary>
        /// <param name="timeSpan">The time span to subtract.</param>
        /// <returns>Returns the current date time with the specified time span subtracted from it.</returns>
        public static DateTime Past( this TimeSpan timeSpan ) => DateTime.Now.Subtract( timeSpan );
    }
}