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
        /// <param name="str">The <see cref="String" /> to check.</param>
        /// <returns>A value of true if the given <see cref="String" /> is empty, otherwise false.</returns>
        public static Boolean IsEmpty( this String str ) => String.IsNullOrEmpty( str ) || String.IsNullOrWhiteSpace( str );
    }
}