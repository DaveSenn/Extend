#region Usings

using System;
using System.Globalization;

#endregion

namespace PortableExtensions
{
    public static partial class StringEx
    {
        /// <summary>
        ///     Replaces one or more format items in a specified string with the string representation of a specified object.
        /// </summary>
        /// <exception cref="ArgumentNullException">The format string can not be null.</exception>
        /// <param name="format">The <see cref="String" /> containing the format items.</param>
        /// <param name="arg0">The first argument.</param>
        /// <returns>
        ///     A copy of format in which the format items have been replaced by the <see cref="String"></see>
        ///     representation of the corresponding argument.
        /// </returns>
        public static String F( this String format, Object arg0 )
        {
            format.ThrowIfNull( () => format );

            return String.Format( format, arg0 );
        }

        /// <summary>
        ///     Replaces one or more format items in a specified string with the string representation of a specified object.
        /// </summary>
        /// <exception cref="ArgumentNullException">The format string can not be null.</exception>
        /// <param name="format">The <see cref="String" /> containing the format items.</param>
        /// <param name="arg0">The first argument.</param>
        /// <param name="arg1">The second argument.</param>
        /// <returns>
        ///     A copy of format in which the format items have been replaced by the <see cref="String"></see>
        ///     representation of the corresponding argument.
        /// </returns>
        public static String F( this String format, Object arg0, Object arg1 )
        {
            format.ThrowIfNull( () => format );

            return String.Format( format, arg0, arg1 );
        }

        /// <summary>
        ///     Replaces one or more format items in a specified string with the string representation of a specified object.
        /// </summary>
        /// <exception cref="ArgumentNullException">The format string can not be null.</exception>
        /// <param name="format">The <see cref="String" /> containing the format items.</param>
        /// <param name="arg0">The first argument.</param>
        /// <param name="arg1">The second argument.</param>
        /// <param name="arg2">The third argument.</param>
        /// <returns>
        ///     A copy of format in which the format items have been replaced by the <see cref="String"></see>
        ///     representation of the corresponding argument.
        /// </returns>
        public static String F( this String format, Object arg0, Object arg1, Object arg2 )
        {
            format.ThrowIfNull( () => format );

            return String.Format( format, arg0, arg1, arg2 );
        }

        /// <summary>
        ///     Replaces the format item in a specified <see cref="String" /> with the <see cref="String" /> representation of a
        ///     corresponding <see cref="Object" /> in a specified array.
        /// </summary>
        /// <exception cref="ArgumentNullException">The format string can not be null.</exception>
        /// <exception cref="ArgumentNullException">The arguments can not be null.</exception>
        /// <exception cref="FormatException">
        ///     Format is invalid.-or- The index of a format item is less than zero, or greater than
        ///     or equal to the length of the args array.
        /// </exception>
        /// <param name="format">The <see cref="String" /> containing the format items.</param>
        /// <param name="args">The array containing all the corresponding values.</param>
        /// <returns>
        ///     A copy of format in which the format items have been replaced by the <see cref="String"></see>
        ///     representation of the corresponding objects in <paramref name="args" />.
        /// </returns>
        public static String F( this String format, params Object[] args )
        {
            format.ThrowIfNull( () => format );
            args.ThrowIfNull( () => args );

            return String.Format( CultureInfo.InvariantCulture, format, args );
        }

        /// <summary>
        ///     Replaces the format item in a specified <see cref="String" /> with the <see cref="String" /> representation of a
        ///     corresponding <see cref="Object" /> in a specified array.
        /// </summary>
        /// <exception cref="ArgumentNullException">The format string can not be null.</exception>
        /// <exception cref="ArgumentNullException">The arguments can not be null.</exception>
        /// <exception cref="FormatException">
        ///     Format is invalid.-or- The index of a format item is less than zero, or greater than
        ///     or equal to the length of the args array.
        /// </exception>
        /// <param name="format">The <see cref="String" /> containing the format items.</param>
        /// <param name="args">The array containing all the corresponding values.</param>
        /// <param name="formatProvider">The format provider.</param>
        /// <returns>
        ///     A copy of format in which the format items have been replaced by the <see cref="String"></see>
        ///     representation of the corresponding objects in <paramref name="args" />.
        /// </returns>
        public static String F( this String format, IFormatProvider formatProvider, params Object[] args )
        {
            format.ThrowIfNull( () => format );
            formatProvider.ThrowIfNull( () => formatProvider );
            args.ThrowIfNull( () => args );

            return String.Format( formatProvider, format, args );
        }
    }
}