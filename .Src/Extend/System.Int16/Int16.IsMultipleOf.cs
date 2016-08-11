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
        ///     Checks if the Int16 value is a multiple of the given factor.
        /// </summary>
        /// <exception cref="DivideByZeroException">factor is 0.</exception>
        /// <param name="value">The Int16 to check.</param>
        /// <param name="factor">The factor.</param>
        /// <returns>>Returns true if the Int16 value is a multiple of the given factor.</returns>
        [PublicAPI]
        [Pure]
        public static Boolean IsMultipleOf( this Int16 value, Int16 factor )
            => value != 0 && value % factor == 0;
    }
}