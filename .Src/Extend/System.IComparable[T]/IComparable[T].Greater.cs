#region Usings

using System;

#endregion

namespace PortableExtensions
{
    /// <summary>
    ///     Class containing some extension methods for <see cref="IComparable{T}" />.
    /// </summary>
    // ReSharper disable once InconsistentNaming
    public static partial class IComparableTEx
    {
        /// <summary>
        ///     Checks if the value is greater than the given compare value.
        /// </summary>
        /// <exception cref="ArgumentNullException">The value can not be null.</exception>
        /// <exception cref="ArgumentNullException">The compare value can not be null.</exception>
        /// <param name="value">The value to check.</param>
        /// <param name="compareValue">The value to compare with.</param>
        /// <returns>
        ///     Returns true if the value is greater than the given compare value,
        ///     otherwise false.
        /// </returns>
        public static Boolean Greater<T>( this T value, T compareValue ) where T : IComparable<T>
        {
            value.ThrowIfNull( () => value );
            compareValue.ThrowIfNull( () => compareValue );

            return value.CompareTo( compareValue ) > 0;
        }
    }
}