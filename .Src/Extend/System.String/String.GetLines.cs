#region Usings

using System;
using System.Collections.Generic;
using System.IO;
using JetBrains.Annotations;

#endregion

namespace Extend
{
    public static partial class StringEx
    {
        /// <summary>
        ///     Enumerates all lines in the given string.
        /// </summary>
        /// <param name="value">The string whose lines are to be enumerated.</param>
        /// <exception cref="ArgumentNullException">value can not be null.</exception>
        /// <returns>An enumerable sequence of lines in this string.</returns>
        [NotNull]
        [Pure]
        [PublicAPI]
        public static IEnumerable<String> GetLines( [NotNull] this String value )
        {
            value.ThrowIfNull( nameof( value ) );

            using ( var reader = new StringReader( value ) )
            {
                String line;
                while ( ( line = reader.ReadLine() ) != null )
                    yield return line;
            }
        }
    }
}