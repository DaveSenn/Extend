#region Usings

using System;
using JetBrains.Annotations;

#endregion

namespace Extend
{
    public static partial class StringEx
    {
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
        [StringFormatMethod( "format" )]
        [Pure]
        [NotNull]
        [PublicAPI]
        public static String F( [NotNull] this String format, [NotNull] params Object[] args )
        {
            format.ThrowIfNull( nameof(format) );
            args.ThrowIfNull( nameof(args) );

            return String.Format( format, args );
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
        [StringFormatMethod( "format" )]
        [Pure]
        [NotNull]
        [PublicAPI]
        public static String F( [NotNull] this String format, [NotNull] IFormatProvider formatProvider, [NotNull] params Object[] args )
        {
            format.ThrowIfNull( nameof(format) );
            formatProvider.ThrowIfNull( nameof(formatProvider) );
            args.ThrowIfNull( nameof(args) );

            return String.Format( formatProvider, format, args );
        }
    }
}