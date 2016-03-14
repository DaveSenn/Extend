#region Usings

using System;

#endregion

namespace Extend
{
    /// <summary>
    ///     Class containing some extension methods for <see cref="double" />.
    /// </summary>
    public static partial class DoubleEx
    {
        /// <summary>
        ///     Returns the given Double value as hours.
        /// </summary>
        /// <param name="value">The Double value.</param>
        /// <returns>Returns the given Double value as hours.</returns>
        public static TimeSpan ToHours( this Double value ) => TimeSpan.FromHours( value );
    }
}