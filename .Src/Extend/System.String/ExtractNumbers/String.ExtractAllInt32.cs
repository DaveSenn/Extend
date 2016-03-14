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
        ///     Extracts all Int32 from the given string.
        /// </summary>
        /// <exception cref="ArgumentNullException">The value can not be null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Invalid start index.</exception>
        /// <param name="value">The string to extract the decimal from.</param>
        /// <param name="startIndex">The start index of the string.</param>
        /// <returns>The extracted Int32.</returns>
        public static List<Int32> ExtractAllInt32( this String value, Int32 startIndex = 0 ) => new List<Int32>( ExtractAllNumbers( value, startIndex )
                                                                                                                     .Select( x => x.ToInt32() ) );
    }
}