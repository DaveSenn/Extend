#region Usings

using System;
using JetBrains.Annotations;

#endregion

namespace Extend
{
    /// <summary>
    ///     Class containing some extension methods for <see cref="double" />.
    /// </summary>
    public static partial class DoubleEx
    {
        /// <summary>
        ///     Returns whether the specified value is not a number.
        /// </summary>
        /// <param name="value">The double to check.</param>
        /// <returns>Returns true if the value is not a number, otherwise false.</returns>
        [PublicAPI]
        [Pure]
        public static Boolean IsNaN( this Double value )
            => Double.IsNaN( value );
    }
}