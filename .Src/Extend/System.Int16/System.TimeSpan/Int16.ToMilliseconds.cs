#region Usings

using System;

#endregion

namespace Extend
{
    /// <summary>
    ///     Class containing some extension methods for <see cref="short" />.
    /// </summary>
    public static partial class Int16Ex
    {
        /// <summary>
        ///     Returns the given Int16 value as milliseconds.
        /// </summary>
        /// <param name="value">The Int16 value.</param>
        /// <returns>Returns the given Int16 value as milliseconds.</returns>
        public static TimeSpan ToMilliseconds( this Int16 value ) => TimeSpan.FromMilliseconds( value );
    }
}