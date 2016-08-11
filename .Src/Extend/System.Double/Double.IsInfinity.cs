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
        ///     Returns whether the specified number evaluates to negative or positive infinity.
        /// </summary>
        /// <param name="value">The double to check.</param>
        /// <returns>Returns true if the given double is infinity, otherwise false.</returns>
        [PublicAPI]
        [Pure]
        public static Boolean IsInfinity( this Double value )
            => Double.IsInfinity( value );
    }
}