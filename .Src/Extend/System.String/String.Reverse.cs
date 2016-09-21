#region Usings

using System;
using JetBrains.Annotations;

#endregion

namespace Extend
{
    public static partial class StringEx
    {
        /// <summary>
        ///     Reverses the given string.
        /// </summary>
        /// <exception cref="ArgumentNullException">The string can not be null.</exception>
        /// <param name="s">The string to reverse.</param>
        /// <returns>Returns the reversed string.</returns>
        [NotNull]
        [Pure]
        [PublicAPI]
        public static String Reverse( [NotNull] this String s )
        {
            s.ThrowIfNull( nameof( s ) );

            return s.Length <= 1
                ? s
                : new String( s.ToCharArray()
                               .Reverse() );
        }
    }
}