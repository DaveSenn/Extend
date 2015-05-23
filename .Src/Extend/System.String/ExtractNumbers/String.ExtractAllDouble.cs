#region Usings

using System;
using System.Collections.Generic;
using System.Linq;

#endregion

namespace Extend
{
    public static partial class StringEx
    {
        /// <summary>
        ///     Extracts all Doubles from the the given string.
        /// </summary>
        /// <exception cref="ArgumentNullException">The value can not be null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Invalid start index.</exception>
        /// <param name="value">The string to extract the doubles from.</param>
        /// <param name="startIndex">The start index of the string.</param>
        /// <returns>The extracted doubles.</returns>
        public static List<Double> ExtractAllDouble( this String value, Int32 startIndex = 0 )
        {
            return new List<Double>( ExtractAllFloatingNumbers( value, startIndex )
                                         .Select( x => x.ToDouble() ) );
        }
    }
}