#region Usings

using System;
using System.Linq;

#endregion

namespace PortableExtensions
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
        /// <exception cref="ArgumentNullException">The values can not be null.</exception>
        /// <typeparam name="T">The type of the values.</typeparam>
        /// <param name="value">The first value.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <param name="values">A list of values.</param>
        /// <returns>Returns the first not null value.</returns>
        public static T CoalesceOrDefault<T> ( this T value, T defaultValue, params T[] values ) where T : class
        {
            if ( value != null )
                return value;

            values.ThrowIfNull( () => values );

            var notNullValues = values.Where( x => x != null );
            if ( notNullValues.Any() )
                return notNullValues.First();

            defaultValue.ThrowIfNull( () => defaultValue );
            return defaultValue;
        }

        /// <summary>
        ///     Return the first not null value (including <paramref name="value" />).
        ///     If all values are null, returns a default value.
        /// </summary>
        /// <exception cref="ArgumentNullException">The values can not be null.</exception>
        /// <typeparam name="T">The type of the values.</typeparam>
        /// <param name="value">The first value.</param>
        /// <param name="defaultValueFactory">The default value factory.</param>
        /// <param name="values">A list of values.</param>
        /// <returns>Returns the first not null value.</returns>
        public static T CoalesceOrDefault<T> ( this T value, Func<T> defaultValueFactory, params T[] values )
            where T : class
        {
            if ( value != null )
                return value;

            values.ThrowIfNull( () => values );

            var notNullValues = values.Where( x => x != null );
            if ( notNullValues.Any() )
                return notNullValues.First();

            defaultValueFactory.ThrowIfNull( () => defaultValueFactory );
            return defaultValueFactory();
        }
    }
}