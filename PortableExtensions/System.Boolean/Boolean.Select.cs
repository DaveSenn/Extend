#region Usings

using System;

#endregion

namespace PortableExtensions
{
    /// <summary>
    ///     Class containing some extension methods for <see cref="bool" />.
    /// </summary>
    public static partial class BooleanEx
    {
        /// <summary>
        ///     Returns the true or false value based on the given Boolean value.
        /// </summary>
        /// <param name="value">The Boolean to check</param>
        /// <param name="trueValue">The true value to be returned if the given value is true.</param>
        /// <param name="falseValue">The false value to be returned if the given value is false.</param>
        /// <returns>The true value if the given Boolean is true, otherwise the false value.</returns>
        public static T SelectValue<T> ( this Boolean value, T trueValue, T falseValue )
        {
            return value ? trueValue : falseValue;
        }
    }
}