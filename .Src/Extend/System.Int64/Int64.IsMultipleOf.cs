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
        ///     Checks if the Int64 value is a multiple of the given factor.
        /// </summary>
        /// <exception cref="DivideByZeroException">factor is 0.</exception>
        /// <param name="value">The Int64 to check.</param>
        /// <param name="factor">The factor.</param>
        /// <returns>>Returns true if the Int64 value is a multiple of the given factor.</returns>
        [PublicAPI]
        [Pure]
        public static Boolean IsMultipleOf( this Int64 value, Int64 factor )
            => value != 0 && value % factor == 0;
    }
}