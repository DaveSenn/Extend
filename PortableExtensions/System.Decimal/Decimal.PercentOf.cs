#region Using

using System;

#endregion

namespace PortableExtensions
{
    /// <summary>
    ///     Class containing some extension methods for <see cref="decimal" />.
    /// </summary>
    public static partial class DecimalEx
    {
        /// <summary>
        ///     Gets the percentage of the number.
        /// </summary>
        /// <exception cref="DivideByZeroException">The number must be greater than zero.</exception>
        /// <param name="number">The number.</param>
        /// <param name="total">The total value.</param>
        /// <returns>Returns the percentage of the number.</returns>
        public static Decimal PercentOf( this Decimal number, Int32 total )
        {
            if ( number <= 0 )
                throw new DivideByZeroException();

            return total / number * 100;
        }

        /// <summary>
        ///     Gets the percentage of the number.
        /// </summary>
        /// <exception cref="DivideByZeroException">The number must be greater than zero.</exception>
        /// <param name="number">The number.</param>
        /// <param name="total">The total value.</param>
        /// <returns>Returns the percentage of the number.</returns>
        public static Decimal PercentOf( this Decimal number, Decimal total )
        {
            if ( number <= 0 )
                throw new DivideByZeroException();

            return total / number * 100;
        }

        /// <summary>
        ///     Gets the percentage of the number.
        /// </summary>
        /// <exception cref="DivideByZeroException">The number must be greater than zero.</exception>
        /// <param name="number">The number.</param>
        /// <param name="total">The total value.</param>
        /// <returns>Returns the percentage of the number.</returns>
        public static Decimal PercentOf( this Decimal number, Int64 total )
        {
            if ( number <= 0 )
                throw new DivideByZeroException();

            return total / number * 100;
        }
    }
}