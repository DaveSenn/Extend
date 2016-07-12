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
        ///     Returns the given Int64 value as day.
        /// </summary>
        /// <exception cref="OverflowException">
        ///     value is less than <see cref="System.TimeSpan.MinValue" /> or greater than <see cref="System.TimeSpan.MaxValue" />.
        /// </exception>
        /// <param name="value">The Int64 value.</param>
        /// <returns>Returns the given Int64 value as days.</returns>
        [Pure]
        [PublicAPI]
        public static TimeSpan ToDays( this Int64 value )
            => TimeSpan.FromDays( value );
    }
}