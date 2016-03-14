﻿#region Usings

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
        ///     Checks if the Int32 is odd.
        /// </summary>
        /// <param name="value">The Int32 to check.</param>
        /// <returns>Returns true if the Int32 is odd, otherwise false.</returns>
        public static Boolean IsOdd( this Int32 value ) => value % 2 != 0;
    }
}