#region Using

using System;

#endregion

namespace PortableExtensions
{
    /// <summary>
    ///     Class containing some extension methods for <see cref="short" />.
    /// </summary>
    public static partial class Int64Ex
    {
        /// <summary>
        ///     Gets the specified percentage of the number.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <param name="percent">The percent.</param>
        /// <returns>Returns the specified percentage of the number</returns>
        public static Double PercentageOf( this Int64 number, Int32 percent )
        {
            if (number <= 0)
                throw new DivideByZeroException("The number must be greater than zero.");

            return (Double) number * percent / 100;
        }

        /// <summary>
        ///     Gets the specified percentage of the number.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <param name="percent">The percent.</param>
        /// <returns>Returns the specified percentage of the number</returns>
        public static Decimal PercentageOf( this Int64 number, Decimal percent )
        {
            if (number <= 0)
                throw new DivideByZeroException("The number must be greater than zero.");

            return number * percent / 100;
        }

        /// <summary>
        ///     Gets the specified percentage of the number.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <param name="percent">The percent.</param>
        /// <returns>Returns the specified percentage of the number</returns>
        public static Double PercentageOf( this Int64 number, Double percent )
        {
            if (number <= 0)
                throw new DivideByZeroException("The number must be greater than zero.");

            return number * percent / 100;
        }

        /// <summary>
        ///     Gets the specified percentage of the number.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <param name="percent">The percent.</param>
        /// <returns>Returns the specified percentage of the number</returns>
        public static Double PercentageOf( this Int64 number, Int64 percent )
        {
            if (number <= 0)
                throw new DivideByZeroException("The number must be greater than zero.");

            return (Double) number * percent / 100;
        }
    }
}