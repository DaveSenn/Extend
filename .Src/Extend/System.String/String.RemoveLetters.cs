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
        ///     Removes all letters from the given string.
        /// </summary>
        /// <exception cref="ArgumentNullException">The string can not be null.</exception>
        /// <param name="str">The input string.</param>
        /// <returns>The given string without any letters.</returns>
        [NotNull]
        [Pure]
        [PublicAPI]
        public static String RemoveLetters( [NotNull] this String str )
        {
            str.ThrowIfNull( nameof( str ) );

            return new String( str.ToCharArray()
                                  .Where( x => !x.IsLetter() )
                                  .ToArray() );
        }
    }
}