#region Usings

using System;
using System.Text;

#endregion

namespace Extend
{
    /// <summary>
    ///     Class containing some extension methods for <see cref="StringBuilder" />.
    /// </summary>
    public static class StringBuilderEx
    {
        /// <summary>
        ///     Appends a formated line to the given string builder.
        /// </summary>
        /// <exception cref="ArgumentNullException">The string builder can not be null.</exception>
        /// <exception cref="ArgumentNullException">The format can not be null.</exception>
        /// <exception cref="ArgumentNullException">The arguments can not be null.</exception>
        /// <param name="sb">The string builder to append the line to.</param>
        /// <param name="format">The <see cref="String" /> containing the format items.</param>
        /// <param name="args">The array containing all the corresponding values.</param>
        /// <returns>Returns the string builder.</returns>
        public static StringBuilder AppendLineFormat( this StringBuilder sb, String format, params Object[] args )
        {
            sb.ThrowIfNull( () => sb );
            format.ThrowIfNull( () => format );
            args.ThrowIfNull( () => args );

            return sb.AppendLine( format.F( args ) );
        }

        /// <summary>
        ///     Appends a formated line to the given string builder.
        /// </summary>
        /// <exception cref="ArgumentNullException">The string builder can not be null.</exception>
        /// <exception cref="ArgumentNullException">The format can not be null.</exception>
        /// <param name="sb">The string builder to append the line to.</param>
        /// <param name="format">The <see cref="String" /> containing the format items.</param>
        /// <param name="arg0">The first argument.</param>
        /// <param name="arg1">The second argument.</param>
        /// <param name="arg2">The third argument.</param>
        /// <returns>Returns the string builder.</returns>
        public static StringBuilder AppendLineFormat( this StringBuilder sb,
                                                      String format,
                                                      Object arg0,
                                                      Object arg1,
                                                      Object arg2 )
        {
            sb.ThrowIfNull( () => sb );
            format.ThrowIfNull( () => format );

            return sb.AppendLine( format.F( arg0, arg1, arg2 ) );
        }

        /// <summary>
        ///     Appends a formated line to the given string builder.
        /// </summary>
        /// <exception cref="ArgumentNullException">The string builder can not be null.</exception>
        /// <exception cref="ArgumentNullException">The format can not be null.</exception>
        /// <param name="sb">The string builder to append the line to.</param>
        /// <param name="format">The <see cref="String" /> containing the format items.</param>
        /// <param name="arg0">The first argument.</param>
        /// <param name="arg1">The second argument.</param>
        /// <returns>Returns the string builder.</returns>
        public static StringBuilder AppendLineFormat( this StringBuilder sb, String format, Object arg0, Object arg1 )
        {
            sb.ThrowIfNull( () => sb );
            format.ThrowIfNull( () => format );

            return sb.AppendLine( format.F( arg0, arg1 ) );
        }

        /// <summary>
        ///     Appends a formated line to the given string builder.
        /// </summary>
        /// <exception cref="ArgumentNullException">The string builder can not be null.</exception>
        /// <exception cref="ArgumentNullException">The format can not be null.</exception>
        /// <param name="sb">The string builder to append the line to.</param>
        /// <param name="format">The <see cref="String" /> containing the format items.</param>
        /// <param name="arg0">The first argument.</param>
        /// <returns>Returns the string builder.</returns>
        public static StringBuilder AppendLineFormat( this StringBuilder sb, String format, Object arg0 )
        {
            sb.ThrowIfNull( () => sb );
            format.ThrowIfNull( () => format );

            return sb.AppendLine( format.F( arg0 ) );
        }
    }
}