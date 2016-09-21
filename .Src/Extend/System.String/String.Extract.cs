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
        ///     Extracts parts of the input string, based on the predicate given.
        /// </summary>
        /// <exception cref="ArgumentNullException">The string can not be null.</exception>
        /// <exception cref="ArgumentNullException">The predicate can not be null.</exception>
        /// <param name="str">The string to extract.</param>
        /// <param name="predicate">The predicate.</param>
        /// <returns>The extracted parts of the input string.</returns>
        [Pure]
        [PublicAPI]
        public static String Extract( [NotNull] this String str, [NotNull] Func<Char, Boolean> predicate )
        {
            str.ThrowIfNull( nameof( str ) );
            predicate.ThrowIfNull( nameof( predicate ) );

            return new String( str.ToCharArray()
                                  .Where( predicate )
                                  .ToArray() );
        }
    }
}