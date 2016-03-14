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
        ///     Extracts all Int16 from the the given string.
        /// </summary>
        /// <exception cref="ArgumentNullException">The value can not be null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Invalid start index.</exception>
        /// <param name="value">The string to extract the decimal from.</param>
        /// <param name="startIndex">The start index of the string.</param>
        /// <returns>The extracted Int16.</returns>
        public static List<Int16> ExtractAllInt16( this String value, Int32 startIndex = 0 ) => new List<Int16>( ExtractAllNumbers( value, startIndex )
                                                                                                                     .Select( x => x.ToInt16() ) );
    }
}