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
        ///     Returns the minimum value.
        /// </summary>
        /// <exception cref="ArgumentNullException">values can not be null.</exception>
        /// <typeparam name="TSource">The type of the values.</typeparam>
        /// <param name="value">The first value.</param>
        /// <param name="values">The other values.</param>
        /// <returns>Returns the minimum value.</returns>
        [NotNull]
        [Pure]
        [PublicAPI]
        public static TSource Minimum<TSource>( [CanBeNull] this TSource value, [NotNull] params TSource[] values )
        {
            values.ThrowIfNull( nameof( values ) );

            var list = values.ToList();
            list.Add( value );
            return list.Min();
        }

        /// <summary>
        ///     Returns the minimum value.
        /// </summary>
        /// <exception cref="ArgumentNullException">values can not be null.</exception>
        /// <exception cref="ArgumentNullException">selector can not be null.</exception>
        /// <typeparam name="TSource">The type of the values.</typeparam>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="value">The first value.</param>
        /// <param name="values">The other values.</param>
        /// <param name="selector"> A transform function to apply to each element.</param>
        /// <returns>Returns the minimum value.</returns>
        [NotNull]
        [Pure]
        [PublicAPI]
        public static TResult Minimum<TSource, TResult>( [CanBeNull] this TSource value,
                                                         [NotNull] Func<TSource, TResult> selector,
                                                         [NotNull] params TSource[] values )
        {
            values.ThrowIfNull( nameof( values ) );
            selector.ThrowIfNull( nameof( selector ) );

            var list = values.ToList();
            list.Add( value );
            return list.Min( selector );
        }
    }
}