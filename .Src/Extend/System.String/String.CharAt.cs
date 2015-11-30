#region Usings

using System;

#endregion

namespace Extend
{
    public static partial class StringEx
    {
        /// <summary>
        ///     Gets the chareacter of the given string at the specified position.
        /// </summary>
        /// <exception cref="ArgumentNullException">value can not be null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">The given index is out of range.</exception>
        /// <param name="value">The string.</param>
        /// <param name="index">The index.</param>
        /// <returns>Returns the character at the specified position.</returns>
        public static Char CharAt( this String value, Int32 index )
        {
            value.ThrowIfNull( nameof( value ) );

            if ( index < 0 || value.Length <= index )
                throw new ArgumentOutOfRangeException( nameof( index ), index, "The given index is out of range." );

            return value[index];
        }
    }
}