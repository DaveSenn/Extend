﻿#region Usings

using System;
using System.Collections.Generic;
using System.Linq;

#endregion

namespace Extend
{
    public static partial class StringEx
    {
        /// <summary>
        ///     Extracts all Decimals from the given string.
        /// </summary>
        /// <exception cref="ArgumentNullException">The value can not be null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Invalid start index.</exception>
        /// <param name="value">The string to extract the decimals from.</param>
        /// <param name="startIndex">The start index of the string.</param>
        /// <returns>The extracted decimals.</returns>
        public static List<Decimal> ExtractAllDecimal( this String value, Int32 startIndex = 0 ) => new List<Decimal>( ExtractAllFloatingNumbers( value, startIndex )
                                                                                                                           .Select( x => x.ToDecimal() ) );
    }
}