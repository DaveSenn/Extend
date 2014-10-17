#region Usings

using System;
using System.Collections.Generic;
using System.Linq;

#endregion

namespace PortableExtensions
{
    public static partial class StringEx
    {
        /// <summary>
        ///     Extracts all Int64 from the the given string.
        /// </summary>
        /// <exception cref="ArgumentNullException">The value can not be null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Invalid start index.</exception>
        /// <param name="value">The string to extract the decimal from.</param>
        /// <param name="startIndex">The start index of the string.</param>
        /// <returns>The extracted Int64.</returns>
        public static List<Int64> ExtractAllInt64 ( this String value, Int32 startIndex = 0 )
        {
            return new List<Int64>( ExtractAllNumbers( value, startIndex ).Select( x => x.ToInt64() ) );
        }
    }
}