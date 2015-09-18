#region Usings

using System;

#endregion

namespace Extend
{
    /// <summary>
    ///     Class containing some extension methods for <see cref="object" />.
    /// </summary>
    public static partial class ObjectEx
    {
        /// <summary>
        ///     Converts the given object to a date time.
        /// </summary>
        /// <exception cref="ArgumentNullException">The object can not be null.</exception>
        /// <param name="obj">The object to convert.</param>
        /// <returns>The date time.</returns>
        public static DateTime ToDateTime( this Object obj )
        {
            obj.ThrowIfNull(nameof(obj));

            return Convert.ToDateTime( obj );
        }

        /// <summary>
        ///     Converts the given object to a date time.
        /// </summary>
        /// <exception cref="ArgumentNullException">The object can not be null.</exception>
        /// <exception cref="ArgumentNullException">The format provider can not be null.</exception>
        /// <param name="obj">The object to convert.</param>
        /// <param name="formatProvider">The format provider.</param>
        /// <returns>The date time.</returns>
        public static DateTime ToDateTime( this Object obj, IFormatProvider formatProvider )
        {
            obj.ThrowIfNull(nameof(obj));
            formatProvider.ThrowIfNull(nameof(formatProvider));

            return Convert.ToDateTime( obj, formatProvider );
        }
    }
}