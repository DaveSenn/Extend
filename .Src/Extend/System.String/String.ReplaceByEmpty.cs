#region Usings

using System;

#endregion

namespace Extend
{
    public static partial class StringEx
    {
        /// <summary>
        ///     Replace all given values by an empty string.
        /// </summary>
        /// <exception cref="ArgumentNullException">The string can not be null.</exception>
        /// <exception cref="ArgumentNullException">The values can not be null.</exception>
        /// <param name="str">The input string.</param>
        /// <param name="values">A list of all values to replace.</param>
        /// <returns>A string with all specified values replaced by an empty string.</returns>
        public static String ReplaceByEmpty( this String str, params String[] values )
        {
            str.ThrowIfNull(nameof(str));
            values.ThrowIfNull(nameof(values));

            values.ForEach( x => str = str.Replace( x, "" ) );
            return str;
        }
    }
}