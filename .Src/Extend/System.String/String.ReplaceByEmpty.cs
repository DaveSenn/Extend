#region Usings

using System;
using JetBrains.Annotations;

#endregion

namespace Extend
{
    public static partial class StringEx
    {
        /// <summary>
        ///     Replace all given values by an empty string.
        /// </summary>
        /// <exception cref="ArgumentNullException">s can not be null.</exception>
        /// <exception cref="ArgumentNullException">values can not be null.</exception>
        /// <param name="s">The input string.</param>
        /// <param name="values">A list of all values to replace.</param>
        /// <returns>Returns a string with all specified values replaced by an empty string.</returns>
        [NotNull]
        [Pure]
        [PublicAPI]
        public static String ReplaceByEmpty( [NotNull] this String s, [NotNull] params String[] values )
        {
            s.ThrowIfNull( nameof( s ) );
            values.ThrowIfNull( nameof( values ) );

            values.ForEach( x => s = s.Replace( x, String.Empty ) );
            return s;
        }
    }
}