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
        ///     If all values are null, returns a default value.
        /// </summary>
        /// <exception cref="ArgumentNullException">values can not be null.</exception>
        /// <exception cref="ArgumentNullException">defaultValue can not be null.</exception>
        /// <typeparam name="T">The type of the values.</typeparam>
        /// <param name="value">The first value.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <param name="values">A list of values.</param>
        /// <returns>Returns the first not null value.</returns>
        [NotNull]
        [PublicAPI]
        [Pure]
        public static T CoalesceOrDefault<T>( [CanBeNull] this T value, [NotNull] T defaultValue, [NotNull] [ItemCanBeNull] params T[] values ) where T : class
        {
            defaultValue.ThrowIfNull( nameof( defaultValue ) );
            values.ThrowIfNull( nameof( values ) );

            if ( value != null )
                return value;

            var notNullValues = values
                .Where( x => x != null )
                .ToList();

            return notNullValues.Any() ? notNullValues.First() : defaultValue;
        }

        /// <summary>
        ///     Return the first not null value (including <paramref name="value" />).
        ///     If all values are null, returns a default value.
        /// </summary>
        /// <exception cref="ArgumentNullException">values can not be null.</exception>
        /// <exception cref="ArgumentNullException">defaultValueFactory can not be null.</exception>
        /// <typeparam name="T">The type of the values.</typeparam>
        /// <param name="value">The first value.</param>
        /// <param name="defaultValueFactory">The default value factory.</param>
        /// <param name="values">A list of values.</param>
        /// <returns>Returns the first not null value.</returns>
        [NotNull]
        [PublicAPI]
        [Pure]
        public static T CoalesceOrDefault<T>( [CanBeNull] this T value, [NotNull] Func<T> defaultValueFactory, [NotNull] [ItemCanBeNull] params T[] values )
            where T : class
        {
            defaultValueFactory.ThrowIfNull( nameof( defaultValueFactory ) );
            values.ThrowIfNull( nameof( values ) );

            if ( value != null )
                return value;

            var notNullValues = values
                .Where( x => x != null )
                .ToList();
            return notNullValues.Any() ? notNullValues.First() : defaultValueFactory();
        }
    }
}