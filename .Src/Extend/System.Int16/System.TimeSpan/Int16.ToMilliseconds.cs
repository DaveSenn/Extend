#region Usings

using System;
using JetBrains.Annotations;

#endregion

namespace Extend
{
    /// <summary>
    ///     Class containing some extension methods for <see cref="short" />.
    /// </summary>
    public static partial class Int16Ex
    {
        /// <summary>
        ///     Returns a <see cref="TimeSpan" /> that represents a specified number of milliseconds, where  the specification is
        ///     accurate
        ///     to the nearest millisecond.
        /// </summary>
        /// <exception cref="OverflowException">
        ///     value is less than <see cref="TimeSpan.MinValue" /> or greater than <see cref="TimeSpan.MaxValue" />.
        /// </exception>
        /// <param name="value">A number of milliseconds.</param>
        /// <returns>Returns a <see cref="TimeSpan" /> representing the given value.</returns>
        [Pure]
        [PublicAPI]
        public static TimeSpan ToMilliseconds( this Int16 value )
            => TimeSpan.FromMilliseconds( value );
    }
}