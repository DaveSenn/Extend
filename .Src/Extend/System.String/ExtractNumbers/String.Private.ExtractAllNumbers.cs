#region Usings

using System;
using System.Collections.Generic;
using System.Text;
using JetBrains.Annotations;

#endregion

namespace Extend
{
    public static partial class StringEx
    {
        /// <summary>
        ///     Extracts all numbers from the given string.
        /// </summary>
        /// <exception cref="ArgumentNullException">The value can not be null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Invalid start index.</exception>
        /// <param name="value">The string to extract the decimal from.</param>
        /// <param name="startIndex">The start index of the string.</param>
        /// <returns>The extracted numbers as string.</returns>
        [NotNull]
        [Pure]
        [PublicAPI]
        private static List<String> ExtractAllNumbers( [NotNull] this String value, Int32 startIndex = 0 )
        {
            value.ThrowIfNull( nameof(value) );

            if ( startIndex >= value.Length || startIndex < 0 )
                throw new ArgumentOutOfRangeException( nameof(value), "Invalid start index." );

            var chars = value.Substring( startIndex )
                             .ToCharArray();
            var numbers = new List<String>();

            var sb = new StringBuilder();
            for ( var i = 0; i < chars.Length; i++ )
                if ( chars[i]
                    .IsDigit() )
                {
                    if ( sb.Length == 0 && i > 0 && chars[i - 1] == '-' )
                        sb.Append( '-' );
                    sb.Append( chars[i] );
                }
                else if ( sb.Length > 0 )
                {
                    numbers.Add( sb.ToString() );
                    sb.Clear();
                }

            if ( sb.Length > 0 )
                numbers.Add( sb.ToString() );

            return numbers;
        }
    }
}