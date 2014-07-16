#region Using

using System;

#endregion

namespace PortableExtensions
{
    /// <summary>
    ///     Class containing some extension methods for <see cref="string" />.
    /// </summary>
    public static partial class StringEx
    {
        /// <summary>
        ///     Splits the given string at each line break (<see cref="Environment.NewLine" />).
        /// </summary>
        /// <example>value can not be null.</example>
        /// <param name="value">The string to split.</param>
        /// <param name="stringSplitOptions">
        ///     <see cref="System.StringSplitOptions.RemoveEmptyEntries" /> to omit empty array elements
        ///     from the array returned; or System.StringSplitOptions.None to include empty
        ///     array elements in the array returned.
        /// </param>
        /// <returns>
        ///     Returns an array whose elements contain the substrings in this string that are delimited by
        ///     <see cref="Environment.NewLine" />.
        /// </returns>
        public static String[] SplitLines( this String value, StringSplitOptions stringSplitOptions )
        {
            value.ThrowIfNull( () => value );

            return value.Split( new[]
            {
                Environment.NewLine
            },
                                stringSplitOptions );
        }

        /// <summary>
        ///     Splits the given string at each line break (<see cref="Environment.NewLine" />).
        /// </summary>
        /// <example>value can not be null.</example>
        /// <param name="value">The string to split.</param>
        /// <returns>
        ///     Returns an array whose elements contain the substrings in this string that are delimited by
        ///     <see cref="Environment.NewLine" />.
        /// </returns>
        public static String[] SplitLines( this String value )
        {
            return value.SplitLines( StringSplitOptions.RemoveEmptyEntries );
        }
    }
}