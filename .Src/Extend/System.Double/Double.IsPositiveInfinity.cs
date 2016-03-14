﻿#region Usings

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
        ///     Returns whether the specified number evaluates to positive infinity.
        /// </summary>
        /// <param name="value">The double to check.</param>
        /// <returns>Returns true if the given double is positive infinity, otherwise false.</returns>
        public static Boolean IsPositiveInfinity( this Double value ) => Double.IsPositiveInfinity( value );
    }
}