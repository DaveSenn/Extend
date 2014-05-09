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
        //replace
        /// <summary>
        ///     Returns a String array containing the substrings in this string that are delimited by elements of a specified
        ///     String array. A parameter specifies whether to return empty array elements.
        /// </summary>
        /// <exception cref="ArgumentNullException">The string can not be null.</exception>
        /// <exception cref="ArgumentNullException">The separator can not be null.</exception>
        /// <param name="str">The string to split.</param>
        /// <param name="separator">A string that delimit the substrings in this string.</param>
        /// <param name="stringSplitOption">
        ///     Specify RemoveEmptyEntries to omit empty array elements from the array returned, or None to include
        ///     empty array elements in the array returned.
        /// </param>
        /// <returns>
        ///     An array whose elements contain the substrings in this string that are delimited by the separator.
        /// </returns>
        public static String[] Split( this String str, String separator,
                                      StringSplitOptions stringSplitOption = StringSplitOptions.None )
        {
            str.ThrowIfNull( () => str );
            separator.ThrowIfNull( () => separator );

            return str.Split( new[]
            {
                separator
            }, stringSplitOption );
        }

        //replace
        /// <summary>
        ///     Returns a String array containing the substrings in this string that are delimited by elements of a specified
        ///     String array. A parameter specifies whether to return empty array elements.
        /// </summary>
        /// <exception cref="ArgumentNullException">The string can not be null.</exception>
        /// <exception cref="ArgumentNullException">The separator can not be null.</exception>
        /// <param name="str">The string to split.</param>
        /// <param name="separators">A list of strings which delimit the substrings in this string.</param>
        /// <param name="stringSplitOption">
        ///     Specify RemoveEmptyEntries to omit empty array elements from the array returned, or None to include
        ///     empty array elements in the array returned.
        /// </param>
        /// <returns>
        ///     An array whose elements contain the substrings in this string that are delimited by the separator.
        /// </returns>
        public static String[] Split( this String str, StringSplitOptions stringSplitOption, params String[] separators )
        {
            str.ThrowIfNull( () => str );
            separators.ThrowIfNull( () => separators );

            return str.Split( separators, stringSplitOption );
        }
    }
}