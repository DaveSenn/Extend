#region Usings

using System;

#endregion

namespace Extend
{
    /// <summary>
    ///     Class containing some extension methods for <see cref="int" />.
    /// </summary>
    public static partial class Int32Ex
    {
        /// <summary>
        ///     Returns the given Int32 value as seconds.
        /// </summary>
        /// <param name="value">The Int32 value.</param>
        /// <returns>Returns the given Int32 value as seconds.</returns>
        public static TimeSpan ToSeconds( this Int32 value ) => TimeSpan.FromSeconds( value );
    }
}