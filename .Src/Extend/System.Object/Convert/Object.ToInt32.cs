#region Usings

using System;
using System.Globalization;

#endregion

namespace Extend
{
    /// <summary>
    ///     Class containing some extension methods for <see cref="object" />.
    /// </summary>
    public static partial class ObjectEx
    {
        /// <summary>
        ///     Converts the given object to a Int32.
        /// </summary>
        /// <exception cref="ArgumentNullException">The object can not be null.</exception>
        /// <param name="obj">The object to convert.</param>
        /// <returns>The Int32.</returns>
        public static Int32 ToInt32( this Object obj )
        {
            obj.ThrowIfNull( nameof( obj ) );

            return Convert.ToInt32( obj, CultureInfo.CurrentCulture );
        }

        /// <summary>
        ///     Converts the given object to a Int32.
        /// </summary>
        /// <exception cref="ArgumentNullException">The object can not be null.</exception>
        /// <exception cref="ArgumentNullException">The format provider can not be null.</exception>
        /// <param name="obj">The object to convert.</param>
        /// <param name="formatProvider">The format provider.</param>
        /// <returns>The Int32.</returns>
        public static Int32 ToInt32( this Object obj, IFormatProvider formatProvider )
        {
            obj.ThrowIfNull( nameof( obj ) );
            formatProvider.ThrowIfNull( nameof( formatProvider ) );

            return Convert.ToInt32( obj, formatProvider );
        }
    }
}