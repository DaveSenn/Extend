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
        ///     Checks if the string is alpha.
        /// </summary>
        /// <exception cref="ArgumentNullException">The string can not be null.</exception>
        /// <param name="str">The string to check.</param>
        /// <returns>Returns true if the string is alpha only, otherwise false.</returns>
        [Pure]
        [PublicAPI]
        public static Boolean IsAlpha( [NotNull] this String str )
        {
            str.ThrowIfNull( nameof(str) );

            return str.ToCharArray()
                      .All( x => x.IsLetter() );
        }
    }
}