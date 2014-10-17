#region Usings

using System;
using System.Text;

#endregion

namespace PortableExtensions
{
    public static partial class StringEx
    {
        /// <summary>
        ///     Repeats the given string a specified number of times.
        /// </summary>
        /// <param name="str">The input string.</param>
        /// <param name="repeatCount">The number of repeats.</param>
        /// <returns>The repeated string.</returns>
        public static String Repeat ( this String str, Int32 repeatCount )
        {
            if ( str.IsEmpty() )
                return String.Empty;

            if ( str.Length == 1 )
                return new String( str [0], repeatCount );

            var sb = new StringBuilder( repeatCount * str.Length );
            while ( repeatCount-- > 0 )
                sb.Append( str );

            return sb.ToString();
        }
    }
}