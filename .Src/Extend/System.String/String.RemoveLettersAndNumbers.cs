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
        ///     Removes all letters and numbers from the given string.
        /// </summary>
        /// <exception cref="ArgumentNullException">s can not be null.</exception>
        /// <param name="s">The input string.</param>
        /// <returns>The given string without any letters or numbers.</returns>
        [NotNull]
        [Pure]
        [PublicAPI]
        public static String RemoveLettersAndNumbers( [NotNull] this String s )
        {
            s.ThrowIfNull( nameof(s) );

            return new String( s.ToCharArray()
                                .Where( x => !x.IsNumber() && !x.IsLetter() )
                                .ToArray() );
        }
    }
}