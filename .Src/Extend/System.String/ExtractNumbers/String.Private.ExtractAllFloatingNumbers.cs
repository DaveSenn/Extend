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
        ///     Extracts all floating point numbers from the given string.
        /// </summary>
        /// <exception cref="ArgumentNullException">The value can not be null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Invalid start index.</exception>
        /// <param name="value">The string to extract the decimal from.</param>
        /// <param name="startIndex">The start index of the string.</param>
        /// <returns>The extracted floating point numbers as strings.</returns>
        // ReSharper disable once ReturnTypeCanBeEnumerable.Local
        [NotNull]
        [Pure]
        [PublicAPI]
        private static List<String> ExtractAllFloatingNumbers( [NotNull] this String value, Int32 startIndex = 0 )
        {
            value.ThrowIfNull( nameof(value) );

            if ( startIndex >= value.Length || startIndex < 0 )
                throw new ArgumentOutOfRangeException( nameof(value), "Invalid start index." );

            var chars = value.Substring( startIndex )
                             .ToCharArray();
            var decimals = new List<String>();

            var sb = new StringBuilder();
            for ( var i = 0; i < chars.Length; i++ )
                if ( chars[i]
                    .IsDigit() )
                {
                    if ( sb.Length == 0 && i > 0 && chars[i - 1] == '-' )
                        sb.Append( '-' );
                    sb.Append( chars[i] );
                }
                else if ( chars[i] == '.' && !sb.ToString()
                                                .Contains( "." ) && sb.Length > 0 )
                    sb.Append( '.' );
                else if ( sb.Length > 0 )
                {
                    decimals.Add( sb.ToString() );
                    sb.Clear();
                }

            if ( sb.Length > 0 )
                decimals.Add( sb.ToString() );

            return decimals;
        }
    }
}