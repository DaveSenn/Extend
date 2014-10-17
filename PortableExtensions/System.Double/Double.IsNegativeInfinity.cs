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
        ///     Returns whether the specified number evaluates to negative infinity.
        /// </summary>
        /// <param name="value">The double to check.</param>
        /// <returns>Returns true if the given double is negative infinity, otherwise false.</returns>
        public static Boolean IsNegativeInfinity ( this Double value )
        {
            return Double.IsNegativeInfinity( value );
        }
    }
}