﻿#region Usings

using System;

#endregion

namespace Extend
{
    public static partial class StringEx
    {
        /// <summary>
        ///     Gets whether the given <see cref="String" /> is empty or not.
        /// </summary>
        /// <param name="input">The <see cref="String" /> to check.</param>
        /// <returns>A value of true if the given <see cref="String" /> is not empty, otherwise false.</returns>
        public static Boolean IsNotEmpty( this String input ) => !IsEmpty( input );
    }
}