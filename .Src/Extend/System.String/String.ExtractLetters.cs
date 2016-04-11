#region Usings

using System;
using System.Linq;
using JetBrains.Annotations;

#endregion

namespace Extend
{
    public static partial class StringEx
    {
        /// <summary>
        ///     Extracts all letters of the input string.
        /// </summary>
        /// <exception cref="ArgumentNullException">The string can not be null.</exception>
        /// <param name="str">The string to extract the letters from.</param>
        /// <returns>The extracted letters.</returns>
        [Pure]
        [NotNull]
        [PublicAPI]
        public static String ExtractLetters( [NotNull] this String str )
        {
            str.ThrowIfNull( nameof( str ) );

            return new String( str.ToCharArray()
                                  .Where( x => x.IsLetter() )
                                  .ToArray() );
        }
    }
}