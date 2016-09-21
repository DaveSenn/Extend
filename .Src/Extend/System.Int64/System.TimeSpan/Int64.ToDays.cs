#region Usings

using System;
using JetBrains.Annotations;

#endregion

namespace Extend
{
    /// <summary>
    ///     Class containing some extension methods for <see cref="long" />.
    /// </summary>
    public static partial class Int64Ex
    {
        /// <summary>
        ///     Returns a <see cref="TimeSpan" /> that represents a specified number of days, where the specification is accurate
        ///     to the nearest millisecond.
        /// </summary>
        /// <exception cref="OverflowException">
        ///     value is less than <see cref="TimeSpan.MinValue" /> or greater than <see cref="TimeSpan.MaxValue" />.
        /// </exception>
        /// <param name="value">A number of days.</param>
        /// <returns>Returns a <see cref="TimeSpan" /> representing the given value.</returns>
        [Pure]
        [PublicAPI]
        public static TimeSpan ToDays( this Int64 value )
            => TimeSpan.FromDays( value );
    }
}