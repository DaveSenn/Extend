#region Usings

using System;
using System.Linq;
using JetBrains.Annotations;

#endregion

namespace Extend
{
    /// <summary>
    ///     Class containing some extension methods for <see cref="int" />.
    /// </summary>
    public static partial class DecimalEx
    {
        /// <summary>
        ///     Computes the sum of a sequence of the given values.
        /// </summary>
        /// <exception cref="OverflowException">The sum is larger than <see cref="Decimal.MaxValue" /></exception>
        /// <exception cref="ArgumentNullException">values can not be null.</exception>
        /// <param name="value">The first value.</param>
        /// <param name="values">The other values.</param>
        /// <returns>Returns the sum of the values.</returns>
        [PublicAPI]
        [Pure]
        public static Decimal Sum( this Decimal value, [NotNull] params Decimal[] values )
        {
            values.ThrowIfNull( nameof(values) );

            var list = values.ToList();
            list.Add( value );
            return list.Sum();
        }

        /// <summary>
        ///     Computes the sum of a sequence of the given values.
        /// </summary>
        /// <exception cref="OverflowException">The sum is larger than <see cref="Decimal.MaxValue" /></exception>
        /// <exception cref="ArgumentNullException">values can not be null.</exception>
        /// <param name="value">The first value.</param>
        /// <param name="values">The other values.</param>
        /// <returns>Returns the sum of the values.</returns>
        [PublicAPI]
        [Pure]
        [CanBeNull]
        public static Decimal? Sum( [CanBeNull] this Decimal? value, [NotNull] params Decimal?[] values )
        {
            values.ThrowIfNull( nameof(values) );

            var list = values.ToList();
            list.Add( value );
            return list.Sum();
        }

        /// <summary>
        ///     Computes the sum of the sequence of <see cref="Decimal" /> values that are obtained
        ///     by invoking a transform function on each element of the input sequence.
        /// </summary>
        /// <exception cref="OverflowException">The sum is larger than <see cref="Decimal.MaxValue" /></exception>
        /// <exception cref="ArgumentNullException">selector can not be null.</exception>
        /// <typeparam name="TSource">The type of the source values.</typeparam>
        /// <param name="value">The first value.</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <param name="values">The other values.</param>
        /// <returns>Returns the sum of the projected values.</returns>
        [PublicAPI]
        [Pure]
        public static Decimal Sum<TSource>( [CanBeNull] this TSource value, [NotNull] Func<TSource, Decimal> selector, [NotNull] params TSource[] values )
        {
            selector.ThrowIfNull( nameof(selector) );
            values.ThrowIfNull( nameof(values) );

            var list = values.ToList();
            list.Add( value );
            return list.Sum( selector );
        }

        /// <summary>
        ///     Computes the sum of the sequence of nullable <see cref="Decimal" /> values that are obtained
        ///     by invoking a transform function on each element of the input sequence.
        /// </summary>
        /// <exception cref="OverflowException">The sum is larger than <see cref="Decimal.MaxValue" /></exception>
        /// <exception cref="ArgumentNullException">selector can not be null.</exception>
        /// <typeparam name="TSource">The type of the source values.</typeparam>
        /// <param name="value">The first value.</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <param name="values">The other values.</param>
        /// <returns>Returns the sum of the projected values.</returns>
        [PublicAPI]
        [Pure]
        [CanBeNull]
        public static Decimal? Sum<TSource>( [CanBeNull] this TSource value,
                                             [NotNull] Func<TSource, Decimal?> selector,
                                             [NotNull] params TSource[] values )
        {
            selector.ThrowIfNull( nameof(selector) );
            values.ThrowIfNull( nameof(values) );

            var list = values.ToList();
            list.Add( value );
            return list.Sum( selector );
        }
    }
}