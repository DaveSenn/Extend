#region Usings

using System;
using JetBrains.Annotations;

#endregion

namespace Extend
{
    public static partial class StringEx
    {
        /// <summary>
        ///     Gets the character of the given string at the specified position.
        /// </summary>
        /// <exception cref="ArgumentNullException">value can not be null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">The given index is out of range.</exception>
        /// <param name="value">The string.</param>
        /// <param name="index">The index.</param>
        /// <returns>Returns the character at the specified position.</returns>
        [Pure]
        [PublicAPI]
        public static Char CharAt( [NotNull] this String value, Int32 index )
        {
            value.ThrowIfNull( nameof( value ) );

            if ( index < 0 || value.Length <= index )
                throw new ArgumentOutOfRangeException( nameof( index ), index, "The given index is out of range." );

            return value[index];
        }
    }
}