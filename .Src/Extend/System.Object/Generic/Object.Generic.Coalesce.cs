#region Usings

using System;
using System.Linq;
using JetBrains.Annotations;

#endregion

namespace Extend
{
    /// <summary>
    ///     Class containing some extension methods for <see cref="object" />.
    /// </summary>
    public static partial class ObjectEx
    {
        /// <summary>
        ///     Return the first not null value (including <paramref name="value" />).
        /// </summary>
        /// <exception cref="ArgumentNullException">The values can not be null.</exception>
        /// <exception cref="InvalidOperationException">The array only contains null value.</exception>
        /// <typeparam name="T">The type of the values.</typeparam>
        /// <param name="value">The first value..</param>
        /// <param name="values">A list of values.</param>
        /// <returns>Returns the first not null value.</returns>
        [CanBeNull]
        [PublicAPI]
        [Pure]
        public static T Coalesce<T>( [CanBeNull] this T value, [NotNull] [ItemCanBeNull] params T[] values ) where T : class
        {
            if ( value != null )
                return value;

            values.ThrowIfNull( nameof( values ) );

            return values.First( x => x != null );
        }

        /// <summary>
        ///     Return the first not null value (including <paramref name="value" />).
        /// </summary>
        /// <typeparam name="T">The type of the values.</typeparam>
        /// <param name="value">The first value.</param>
        /// <param name="value0">The second value.</param>
        /// <returns>Returns the first not null value.</returns>
        [CanBeNull]
        [PublicAPI]
        [Pure]
        public static T Coalesce<T>( [CanBeNull] this T value, [CanBeNull] T value0 ) where T : class
            => value ?? value0;
    }
}