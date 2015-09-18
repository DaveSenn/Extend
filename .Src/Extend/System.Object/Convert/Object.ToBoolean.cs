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
        ///     Converts the given object to a boolean.
        /// </summary>
        /// <exception cref="ArgumentNullException">The object can not be null.</exception>
        /// <param name="obj">The object to convert.</param>
        /// <returns>The boolean.</returns>
        public static Boolean ToBoolean( this Object obj )
        {
            obj.ThrowIfNull( nameof( obj ) );

            return Convert.ToBoolean( obj, CultureInfo.CurrentCulture );
        }

        /// <summary>
        ///     Converts the given object to a boolean.
        /// </summary>
        /// <exception cref="ArgumentNullException">The object can not be null.</exception>
        /// <exception cref="ArgumentNullException">The format provider can not be null.</exception>
        /// <param name="obj">The object to convert.</param>
        /// <param name="formatProvider">The format provider.</param>
        /// <returns>The boolean.</returns>
        public static Boolean ToBoolean( this Object obj, IFormatProvider formatProvider )
        {
            obj.ThrowIfNull( nameof( obj ) );
            formatProvider.ThrowIfNull( nameof( formatProvider ) );

            return Convert.ToBoolean( obj, formatProvider );
        }
    }
}