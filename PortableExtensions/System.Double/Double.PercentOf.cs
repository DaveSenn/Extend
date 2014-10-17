#region Usings

using System;

#endregion

namespace PortableExtensions
{
    /// <summary>
    ///     Class containing some extension methods for <see cref="double" />.
    /// </summary>
    public static partial class DoubleEx
    {
        /// <summary>
        ///     Gets the percentage of the number.
        /// </summary>
        /// <exception cref="DivideByZeroException">The number must be greater than zero.</exception>
        /// <param name="number">The number.</param>
        /// <param name="total">The total value.</param>
        /// <returns>Returns the percentage of the number.</returns>
        public static Double PercentOf ( this Double number, Int32 total )
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
        public static Double PercentOf ( this Double number, Double total )
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
        public static Double PercentOf ( this Double number, Int64 total )
        {
            if ( number <= 0 )
                throw new DivideByZeroException();

            return total / number * 100;
        }
    }
}