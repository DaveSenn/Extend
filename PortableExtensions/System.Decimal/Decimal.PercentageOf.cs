#region Usings

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
        ///     Gets the specified percentage of the number.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <param name="percent">The percent.</param>
        /// <returns>Returns the specified percentage of the number</returns>
        public static Decimal PercentageOf ( this Decimal number, Int32 percent )
        {
            return number * percent / 100;
        }

        /// <summary>
        ///     Gets the specified percentage of the number.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <param name="percent">The percent.</param>
        /// <returns>Returns the specified percentage of the number</returns>
        public static Decimal PercentageOf ( this Decimal number, Decimal percent )
        {
            return number * percent / 100;
        }

        /// <summary>
        ///     Gets the specified percentage of the number.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <param name="percent">The percent.</param>
        /// <returns>Returns the specified percentage of the number</returns>
        public static Decimal PercentageOf ( this Decimal number, Int64 percent )
        {
            return number * percent / 100;
        }
    }
}