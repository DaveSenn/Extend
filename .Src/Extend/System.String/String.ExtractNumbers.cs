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
        ///     Extracts all numbers of the input string.
        /// </summary>
        /// <exception cref="ArgumentNullException">The string can not be null.</exception>
        /// <param name="str">The string to extract the numbers from.</param>
        /// <returns>The extracted numbers.</returns>
        [Pure]
        [NotNull]
        [PublicAPI]
        public static String ExtractNumbers( [NotNull] this String str )
        {
            str.ThrowIfNull( nameof( str ) );

            return new String( str.ToCharArray()
                                  .Where( x => x.IsNumber() )
                                  .ToArray() );
        }
    }
}