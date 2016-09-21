#region Usings

using System;
using JetBrains.Annotations;

#endregion

namespace Extend
{
    public static partial class StringEx
    {
        /// <summary>
        ///     Concatenates all given strings.
        /// </summary>
        /// <exception cref="ArgumentNullException">strings can not be null.</exception>
        /// <param name="str">The first string to concatenate.</param>
        /// <param name="strings">All strings to concatenate.</param>
        /// <returns>The concatenation of all strings.</returns>
        [Pure]
        [NotNull]
        [PublicAPI]
        public static String ConcatAll( this String str, [NotNull] params String[] strings )
        {
            strings.ThrowIfNull( nameof( strings ) );

            return String.Concat( str, String.Concat( strings ) );
        }

        /// <summary>
        ///     Concatenates all given strings.
        /// </summary>
        /// <exception cref="ArgumentNullException">strings can not be null.</exception>
        /// <param name="strings">All strings to concatenate.</param>
        /// <returns>The concatenation of all strings.</returns>
        [Pure]
        [NotNull]
        [PublicAPI]
        public static String ConcatAll( [NotNull] this String[] strings )
        {
            strings.ThrowIfNull( nameof( strings ) );

            return String.Concat( strings );
        }

        /// <summary>
        ///     Concatenates all given values.
        /// </summary>
        /// <exception cref="ArgumentNullException">values can not be null.</exception>
        /// <param name="str">The first string to concatenate.</param>
        /// <param name="values">All values to concatenate.</param>
        /// <returns>The concatenation of all values.</returns>
        [Pure]
        [NotNull]
        [PublicAPI]
        public static String ConcatAll( this String str, [NotNull] params Object[] values )
        {
            values.ThrowIfNull( nameof( values ) );

            return String.Concat( str, String.Concat( values ) );
        }

        /// <summary>
        ///     Concatenates all given values.
        /// </summary>
        /// <exception cref="ArgumentNullException">values can not be null.</exception>
        /// <param name="values">All values to concatenate.</param>
        /// <returns>The concatenation of all values.</returns>
        [Pure]
        [NotNull]
        [PublicAPI]
        public static String ConcatAll( [NotNull] this Object[] values )
        {
            values.ThrowIfNull( nameof( values ) );

            return String.Concat( values );
        }
    }
}