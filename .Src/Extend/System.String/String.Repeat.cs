#region Usings

using System;
using System.Text;
using JetBrains.Annotations;

#endregion

namespace Extend
{
    public static partial class StringEx
    {
        /// <summary>
        ///     Repeats the given string a specified number of times.
        /// </summary>
        /// <param name="s">The input string.</param>
        /// <param name="repeatCount">The number of repeats.</param>
        /// <returns>Returns the repeated string.</returns>
        [NotNull]
        [Pure]
        [PublicAPI]
        public static String Repeat( this String s, Int32 repeatCount )
        {
            if ( s.IsEmpty() )
                return String.Empty;

            if ( s.Length == 1 )
                return new String( s[0], repeatCount );

            var sb = new StringBuilder( repeatCount * s.Length );
            while ( repeatCount-- > 0 )
                sb.Append( s );

            return sb.ToString();
        }
    }
}