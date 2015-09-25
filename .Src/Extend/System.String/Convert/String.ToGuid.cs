#region Usings

using System;

#endregion

namespace Extend
{
    public static partial class StringEx
    {
        /// <summary>
        ///     Converts the given string to a GUID.
        /// </summary>
        /// <exception cref="ArgumentNullException">The value can not be null.</exception>
        /// <exception cref="FormatException">value is not in a recognized format.</exception>
        /// <param name="value">The string to convert.</param>
        /// <returns>Returns the converted GUID.</returns>
        public static Guid ToGuid( this String value )
        {
            value.ThrowIfNull( nameof( value ) );

            return Guid.Parse( value );
        }
    }
}