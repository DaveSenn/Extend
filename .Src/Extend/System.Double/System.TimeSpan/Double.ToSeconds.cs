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
        ///     Returns the given Double value as seconds.
        /// </summary>
        /// <param name="value">The Double value.</param>
        /// <returns>Returns the given Double value as seconds.</returns>
        public static TimeSpan ToSeconds( this Double value ) => TimeSpan.FromSeconds( value );
    }
}