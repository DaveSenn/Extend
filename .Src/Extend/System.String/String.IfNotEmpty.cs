#region Usings

using System;
using JetBrains.Annotations;

#endregion

namespace Extend
{
    public static partial class StringEx
    {
        /// <summary>
        ///     Returns the input value if it's not empty, otherwise the alternative value.
        /// </summary>
        /// <param name="value">The input string.</param>
        /// <param name="alternativeValue">The alternative value.</param>
        /// <returns>The input or the alternative value.</returns>
        [CanBeNull]
        [Pure]
        [PublicAPI]
        public static String IfNotEmpty( [CanBeNull] this String value, [CanBeNull] String alternativeValue )
            => !value.IsEmpty() ? value : alternativeValue;
    }
}