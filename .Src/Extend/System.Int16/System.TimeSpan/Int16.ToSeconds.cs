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
        ///     Returns the given Int16 value as seconds.
        /// </summary>
        /// <param name="value">The Int16 value.</param>
        /// <returns>Returns the given Int16 value as seconds.</returns>
        public static TimeSpan ToSeconds( this Int16 value )
        {
            return TimeSpan.FromSeconds( value );
        }
    }
}