#region Usings

using System;

#endregion

namespace Extend
{
    public static partial class StringEx
    {
        /// <summary>
        ///     Appends the given text to the string.
        ///     Adds a newline before <paramref name="append" />, if <paramref name="target" /> is not null.
        /// </summary>
        /// <param name="target">The string to append to.</param>
        /// <param name="append">The string to append.</param>
        /// <param name="newLine">The new line string to use.</param>
        /// <returns>Returns the concatenated string.</returns>
        public static String AppendWithNewLineIfNotEmpty( this String target, String append, String newLine = null )
        {
            newLine = newLine ?? Environment.NewLine;

            if ( target.IsNotEmpty() )
                target += newLine;

            return target + append;
        }
    }
}