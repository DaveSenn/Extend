#region Usings

using System;
using JetBrains.Annotations;

#endregion

namespace Extend
{
    /// <summary>
    ///     Class containing some extension methods for <see cref="short" />.
    /// </summary>
    public static partial class Int16Ex
    {
        /// <summary>
        ///     Gets the specified percentage of the number.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <param name="percent">The percent.</param>
        /// <returns>Returns the specified percentage of the number</returns>
        [Pure]
        [PublicAPI]
        public static Double PercentageOf( this Int16 number, Int32 percent )
            => (Double) number * percent / 100;

        /// <summary>
        ///     Gets the specified percentage of the number.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <param name="percent">The percent.</param>
        /// <returns>Returns the specified percentage of the number</returns>
        [Pure]
        [PublicAPI]
        public static Decimal PercentageOf( this Int16 number, Decimal percent )
            => number * percent / 100;

        /// <summary>
        ///     Gets the specified percentage of the number.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <param name="percent">The percent.</param>
        /// <returns>Returns the specified percentage of the number</returns>
        [Pure]
        [PublicAPI]
        public static Double PercentageOf( this Int16 number, Double percent )
            => number * percent / 100;

        /// <summary>
        ///     Gets the specified percentage of the number.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <param name="percent">The percent.</param>
        /// <returns>Returns the specified percentage of the number</returns>
        [Pure]
        [PublicAPI]
        public static Double PercentageOf( this Int16 number, Int64 percent )
            => (Double) number * percent / 100;
    }
}