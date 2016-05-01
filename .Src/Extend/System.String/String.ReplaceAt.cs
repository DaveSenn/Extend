#region Usings

using System;
using JetBrains.Annotations;

#endregion

namespace Extend
{
    public static partial class StringEx
    {
        /// <summary>
        ///     Replaces a single character at the specified position with the specified replacement character.
        /// </summary>
        /// <exception cref="ArgumentNullException">value can not be null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">index doesn't refer to a valid position within the string.</exception>
        /// <param name="value">The string in which a character will be replaced.</param>
        /// <param name="index">The position of the character to replace.</param>
        /// <param name="replace">The replacement character.</param>
        /// <returns>Returns the string with the replaced character.</returns>
        [NotNull]
        [Pure]
        [PublicAPI]
        public static String ReplaceAt( [NotNull] this String value, Int32 index, Char replace )
        {
            value.ThrowIfNull( nameof( value ) );

            if ( index < 0 || value.Length <= index )
                throw new ArgumentOutOfRangeException( nameof( index ), index, "The given index is out of range." );

            var chars = value.ToCharArray();
            chars[index] = replace;

            return new String( chars );
        }
    }
}