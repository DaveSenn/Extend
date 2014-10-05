#region Using

using System;

#endregion

namespace PortableExtensions
{
    public static partial class StringEx
    {
        /// <summary>
        ///     Converts a string to an enumeration.
        /// </summary>
        /// <exception cref="ArgumentNullException">The value can not be null.</exception>
        /// <typeparam name="T">The type of the enumeration.</typeparam>
        /// <param name="value">The String value to convert.</param>
        /// <param name="ignoreCase">Determines whether or not to ignore the casing of the string.</param>
        /// <returns>Returns the converted enumeration value.</returns>
        public static T ToEnum<T>( this String value, Boolean ignoreCase = true ) where T : struct
        {
            value.ThrowIfNull( () => value );

            return (T) Enum.Parse( typeof ( T ), value, ignoreCase );
        }
    }
}