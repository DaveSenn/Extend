#region Using

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
        ///     Returns the minimum value.
        /// </summary>
        /// <exception cref="ArgumentNullException">values can not be null.</exception>
        /// <typeparam name="TSource">The type of the values.</typeparam>
        /// <param name="value">The first value.</param>
        /// <param name="values">The other values.</param>
        /// <returns>Returns the minimum value.</returns>
        public static TSource Minimum<TSource>( this TSource value, params TSource[] values )
        {
            values.ThrowIfNull( () => values );

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
        public static TResult Minimum<TSource, TResult>( this TSource value,
                                                         Func<TSource, TResult> selector,
                                                         params TSource[] values )
        {
            values.ThrowIfNull( () => values );
            selector.ThrowIfNull( () => selector );

            var list = values.ToList();
            list.Add( value );
            return list.Min( selector );
        }
    }
}